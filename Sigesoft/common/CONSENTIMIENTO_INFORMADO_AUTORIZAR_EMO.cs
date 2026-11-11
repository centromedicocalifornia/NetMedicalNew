using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Sigesoft.Node.WinClient.BE;

namespace NetPdf
{
    public class CONSENTIMIENTO_INFORMADO_AUTORIZAR_EMO
    {
        // Ancho útil del contenido (deja un margen interior a ambos lados del texto)
        private const float ANCHO_CONTENIDO = 92f;
        private const float SANGRIA_TEXTO = 21f;

        private static void RunFile(string filePDF)
        {
            Process proceso = Process.Start(filePDF);
            proceso.WaitForExit();
            proceso.Close();
        }

        public static void CreateConseitimientoInformadoParaAutorizarEMO(string filePDF, PacientList filiationData,
            PacientList datosPac,
            organizationDto infoEmpresaPropietaria)
        {
            Document document = new Document(PageSize.A4, 30f, 30f, 75f, 65f);
            document.SetPageSize(iTextSharp.text.PageSize.A4);

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePDF, FileMode.Create));
            pdfPage_NEW page = new pdfPage_NEW();
            page.Title = string.Empty;
            writer.PageEvent = page;
            document.Open();

            #region Fonts
            Font fontTitulo = FontFactory.GetFont("Calibri", 11.5f, Font.BOLD, BaseColor.BLACK);
            Font fontTexto = FontFactory.GetFont("Calibri", 10f, Font.NORMAL, BaseColor.BLACK);
            Font fontNegrita = FontFactory.GetFont("Calibri", 10f, Font.BOLD, BaseColor.BLACK);
            Font fontLeyenda = FontFactory.GetFont("Calibri", 6.5f, Font.ITALIC, BaseColor.DARK_GRAY);
            #endregion

            #region Datos
            string tipoDoc;
            switch (datosPac.i_DocTypeId)
            {
                case 2: tipoDoc = "Pasaporte"; break;
                case 3: tipoDoc = "Licencia de Conducir"; break;
                case 4: tipoDoc = "Carné de Extranjería"; break;
                default: tipoDoc = "DNI"; break;
            }

            string nombreCompleto = string.Format("{0} {1} {2}",
                datosPac.v_FirstLastName, datosPac.v_SecondLastName, datosPac.v_FirstName).Trim();
            string nroDocumento = Texto(datosPac.v_DocNumber);
            string ocupacion = Texto(datosPac.v_CurrentOccupation);
            string empresaGeneral = Texto(filiationData.empresa_);
            string centroSalud = Texto(infoEmpresaPropietaria.v_Name);
            string fechaServicio = datosPac.FechaServicio == null
                ? string.Empty
                : datosPac.FechaServicio.ToString().Split(' ')[0];
            #endregion

            #region Titulo
            Paragraph titulo = new Paragraph("CONSENTIMIENTO INFORMADO PARA AUTORIZAR\nEL EXAMEN MÉDICO OCUPACIONAL", fontTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SetLeading(0f, 1.25f);
            titulo.SpacingBefore = 18f;
            titulo.SpacingAfter = 14f;
            document.Add(titulo);
            #endregion

            #region Contenido
            document.Add(CampoSubrayado("YO,", nombreCompleto,
                "(Apellidos y Nombres como aparece en su documento de identidad)",
                fontTexto, fontNegrita, fontLeyenda));

            document.Add(ParrafoJustificado(10f, 8f,
                new Chunk("identificado(a) con " + tipoDoc + " N° ", fontTexto),
                new Chunk(nroDocumento, fontNegrita),
                new Chunk(", con ocupación laboral de ", fontTexto),
                new Chunk(ocupacion, fontNegrita),
                new Chunk(", certifico que he sido informado(a) acerca de la naturaleza y propósito del examen médico " +
                          "ocupacional, así como de las pruebas complementarias determinadas por la empresa ", fontTexto),
                new Chunk(empresaGeneral, fontNegrita),
                new Chunk(", de acuerdo con los peligros y riesgos identificados en mi puesto de trabajo.", fontTexto)));

            document.Add(ParrafoJustificado(0f, 8f,
                new Chunk("En este sentido, en forma consciente y voluntaria, doy mi consentimiento para que se me realice el " +
                          "examen médico ocupacional de acuerdo con la Resolución Ministerial N° 312-2011/MINSA, y doy fe de que " +
                          "la información brindada a ", fontTexto),
                new Chunk(centroSalud, fontNegrita),
                new Chunk(" es verídica.", fontTexto)));

            document.Add(ParrafoJustificado(0f, 12f,
                new Chunk("Asimismo, autorizo a ", fontTexto),
                new Chunk(centroSalud, fontNegrita),
                new Chunk(" para que brinde mi Historia Clínica y toda la información resultante de mi examen médico " +
                          "ocupacional al Médico Ocupacional de mi empresa, a fin de que tenga acceso a mi Historia Clínica, " +
                          "de acuerdo con la N.T. N° 022-MINSA/DGSP-V.02 y la ", fontTexto),
                new Chunk("Ley N° 26842, Ley General de Salud.", fontNegrita)));

            document.Add(CampoFecha(fechaServicio, fontTexto, fontNegrita));
            #endregion

            #region Firma
            PdfPCell cellFirmaTrabajador;
            if (filiationData.FirmaTrabajador != null)
                cellFirmaTrabajador = new PdfPCell(HandlingItextSharp.GetImage(filiationData.FirmaTrabajador, null, null, 125, 50));
            else
                cellFirmaTrabajador = new PdfPCell(new Phrase(" ", fontTexto));

            PdfPCell cellHuellaTrabajador;
            if (filiationData.HuellaTrabajador != null)
                cellHuellaTrabajador = new PdfPCell(HandlingItextSharp.GetImage(filiationData.HuellaTrabajador, null, null, 55, 75));
            else
                cellHuellaTrabajador = new PdfPCell(new Phrase(" ", fontTexto));

            foreach (PdfPCell c in new[] { cellFirmaTrabajador, cellHuellaTrabajador })
            {
                c.HorizontalAlignment = Element.ALIGN_CENTER;
                c.VerticalAlignment = Element.ALIGN_MIDDLE;
                c.MinimumHeight = 90f;
                c.BorderWidth = 0.75f;
            }

            PdfPTable tablaFirma = new PdfPTable(2);
            tablaFirma.WidthPercentage = 70f;
            tablaFirma.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaFirma.SpacingBefore = 30f;
            tablaFirma.KeepTogether = true;
            tablaFirma.SetWidths(new float[] { 60f, 40f });
            tablaFirma.AddCell(cellFirmaTrabajador);
            tablaFirma.AddCell(cellHuellaTrabajador);
            tablaFirma.AddCell(new PdfPCell(new Phrase("FIRMA DEL PACIENTE", fontNegrita)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, FixedHeight = 18f, BorderWidth = 0.75f });
            tablaFirma.AddCell(new PdfPCell(new Phrase("HUELLA DIGITAL", fontNegrita)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, FixedHeight = 18f, BorderWidth = 0.75f });
            document.Add(tablaFirma);
            #endregion

            document.Close();
            writer.Close();
            writer.Dispose();
        }

        #region Helpers

        private static string Texto(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? " " : valor.Trim();
        }

        /// <summary>Párrafo justificado con interlineado cómodo y sangría lateral uniforme.</summary>
        private static Paragraph ParrafoJustificado(float espacioAntes, float espacioDespues, params Chunk[] partes)
        {
            Paragraph p = new Paragraph();
            foreach (Chunk parte in partes)
                p.Add(parte);

            p.Alignment = Element.ALIGN_JUSTIFIED;
            p.SetLeading(0f, 1.4f);
            p.IndentationLeft = SANGRIA_TEXTO;
            p.IndentationRight = SANGRIA_TEXTO;
            p.SpacingBefore = espacioAntes;
            p.SpacingAfter = espacioDespues;
            return p;
        }

        /// <summary>Línea de dato subrayada con etiqueta a la izquierda y leyenda opcional debajo.</summary>
        private static PdfPTable CampoSubrayado(string etiqueta, string valor, string leyenda, Font fontEtiqueta, Font fontValor, Font fontLeyenda)
        {
            PdfPTable tabla = new PdfPTable(2);
            tabla.WidthPercentage = ANCHO_CONTENIDO;
            tabla.HorizontalAlignment = Element.ALIGN_CENTER;
            tabla.SpacingBefore = 4f;
            tabla.SetWidths(new float[] { 6f, 94f });

            tabla.AddCell(new PdfPCell(new Phrase(etiqueta, fontEtiqueta)) { Border = Rectangle.NO_BORDER, VerticalAlignment = Element.ALIGN_BOTTOM, PaddingBottom = 3f });
            tabla.AddCell(new PdfPCell(new Phrase(valor, fontValor))
            {
                Border = Rectangle.BOTTOM_BORDER,
                BorderWidthBottom = 0.6f,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_BOTTOM,
                MinimumHeight = 16f,
                PaddingBottom = 3f
            });

            if (!string.IsNullOrEmpty(leyenda))
            {
                tabla.AddCell(new PdfPCell(new Phrase(" ", fontLeyenda)) { Border = Rectangle.NO_BORDER });
                tabla.AddCell(new PdfPCell(new Phrase(leyenda, fontLeyenda)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 1f });
            }

            return tabla;
        }

        /// <summary>"Fecha: ____" alineado a la izquierda del bloque de texto.</summary>
        private static PdfPTable CampoFecha(string fecha, Font fontEtiqueta, Font fontValor)
        {
            PdfPTable tabla = new PdfPTable(3);
            tabla.WidthPercentage = ANCHO_CONTENIDO;
            tabla.HorizontalAlignment = Element.ALIGN_CENTER;
            tabla.SetWidths(new float[] { 9f, 22f, 69f });

            tabla.AddCell(new PdfPCell(new Phrase("Fecha:", fontEtiqueta)) { Border = Rectangle.NO_BORDER, VerticalAlignment = Element.ALIGN_BOTTOM, PaddingBottom = 3f });
            tabla.AddCell(new PdfPCell(new Phrase(fecha, fontValor)) { Border = Rectangle.BOTTOM_BORDER, BorderWidthBottom = 0.6f, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_BOTTOM, MinimumHeight = 16f, PaddingBottom = 3f });
            tabla.AddCell(new PdfPCell(new Phrase(" ", fontEtiqueta)) { Border = Rectangle.NO_BORDER });
            return tabla;
        }

        #endregion
    }
}
