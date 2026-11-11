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
    public class Autorizacion_Realizacion_Ex_Lumina
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

        public static void CreateAutorizacion_Realizacion_Ex_Lumina(string filePDF,
            PacientList datosPac,
            organizationDto infoEmpresa, PacientList filiationData)
        {
            Document document = new Document(PageSize.A4, 30f, 30f, 75f, 65f);
            document.SetPageSize(iTextSharp.text.PageSize.A4);

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePDF, FileMode.Create));
            pdfPage_NEW page = new pdfPage_NEW();
            page.Title = string.Empty;
            writer.PageEvent = page;
            document.Open();

            #region Fonts
            Font fontTitulo = FontFactory.GetFont("Calibri", 11, Font.BOLD, BaseColor.BLACK);
            Font fontTexto = FontFactory.GetFont("Calibri", 9.5f, Font.NORMAL, BaseColor.BLACK);
            Font fontNegrita = FontFactory.GetFont("Calibri", 9.5f, Font.BOLD, BaseColor.BLACK);
            Font fontLeyenda = FontFactory.GetFont("Calibri", 6.5f, Font.ITALIC, BaseColor.DARK_GRAY);
            #endregion

            #region Datos
            string nombreCompleto = string.Format("{0} {1} {2}",
                datosPac.v_FirstLastName, datosPac.v_SecondLastName, datosPac.v_FirstName).Trim();
            string empresaGeneral = Texto(filiationData.empresa_);
            string nroDocumento = Texto(datosPac.v_DocNumber);
            string domicilio = Texto(datosPac.v_AdressLocation);
            string centroSalud = Texto(infoEmpresa.v_Name);
            string fechaServicio = datosPac.FechaServicio == null
                ? string.Empty
                : datosPac.FechaServicio.ToString().Split(' ')[0];
            #endregion

            #region Titulo
            Paragraph titulo = new Paragraph("\nAUTORIZACIÓN DE REALIZACIÓN DE EXAMEN\nMÉDICO Y LIBERACIÓN DE INFORMACIÓN MÉDICA", fontTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SetLeading(0f, 1.25f);
            titulo.SpacingBefore = 18f;
            titulo.SpacingAfter = 8f;
            document.Add(titulo);
            #endregion

            #region Datos del trabajador
            document.Add(CampoSubrayado("YO,", nombreCompleto,
                "(Apellidos y Nombres como aparece en su documento de identidad)",
                fontTexto, fontNegrita, fontLeyenda));

            document.Add(ParrafoJustificado(5f, 1f,
                new Chunk("Trabajador / Postulante / Contratista de la Empresa ", fontTexto),
                new Chunk(empresaGeneral, fontNegrita),
                new Chunk(", identificado con DNI / Pasaporte / Carné de Extranjería N° ", fontTexto),
                new Chunk(nroDocumento, fontNegrita),
                new Chunk(", con domicilio legal en:", fontTexto)));

            document.Add(CampoSubrayado(null, domicilio, null, fontTexto, fontNegrita, fontLeyenda));

            document.Add(ParrafoJustificado(5f, 1f,
                new Chunk("Declaro que de forma libre y espontánea, autorizo a:", fontTexto)));

            document.Add(CampoSubrayado(null, centroSalud,
                "(Razón Social del Centro de Salud Ocupacional)",
                fontTexto, fontNegrita, fontLeyenda));
            #endregion

            #region Contenido
            document.Add(ParrafoJustificado(6f, 4f,
                new Chunk("a realizar las evaluaciones médicas ocupacionales requeridas por ley, así como a proporcionar " +
                          "información con respecto a mi estado de salud, resultados de exámenes auxiliares y/o resultados de " +
                          "evaluaciones médicas ocupacionales contenidas en mi examen ocupacional, al médico responsable del " +
                          "Área de Salud Ocupacional de la empresa en la cual laboro o laboraré, así como al médico ocupacional " +
                          "de la empresa destino donde se desarrollará el trabajo; debiendo primar en estos procesos el principio de ", fontTexto),
                new Chunk("CONFIDENCIALIDAD.", fontNegrita)));

            document.Add(ParrafoJustificado(0f, 4f,
                new Chunk("La presente autorización se ampara en lo dispuesto en los Artículos 5° (segundo párrafo), 13°, 25°, " +
                          "27° y 29° (tercer párrafo) de la ", fontTexto),
                new Chunk("LEY GENERAL DE SALUD N° 26842.", fontNegrita)));

            document.Add(ParrafoJustificado(0f, 4f,
                new Chunk("De acuerdo con lo dispuesto en la Ley N° 29733 (Ley de Protección de Datos Personales), declaro haber " +
                          "tomado conocimiento de que los exámenes médicos efectuados en la clínica y la información contenida " +
                          "en los mismos tienen como finalidad evaluar mi condición médica para laborar o postular a un puesto de trabajo.", fontTexto)));

            document.Add(ParrafoJustificado(0f, 4f,
                new Chunk("En ese sentido, mediante la suscripción del presente documento, otorgo consentimiento expreso e " +
                          "inequívoco para que ", fontTexto),
                new Chunk(centroSalud, fontNegrita),
                new Chunk(" ejecute el tratamiento de mis datos ", fontTexto),
                new Chunk("personales facilitados, pudiendo esta última informar a la Empresa Contratista. ", fontNegrita),
                new Chunk("Esta declaración autoriza la transferencia de la información de la historia clínica y exámenes " +
                          "médicos confidenciales de conformidad con la Ley N° 26842 (Ley General de Salud) y la Ley N° 29783 " +
                          "(Ley de Seguridad y Salud en el Trabajo y su Reglamento aprobado por Decreto Supremo N° 005-2012-TR).", fontNegrita)));

            document.Add(ParrafoJustificado(0f, 6f,
                new Chunk("Asimismo, según la Ley N° 27269 (Ley de Firmas y Certificados Digitales), ", fontTexto),
                new Chunk("AUTORIZO a " + centroSalud, fontNegrita),
                new Chunk(" el uso de mi firma y/o huella digital en el proceso de mi examen médico ocupacional y en la " +
                          "emisión de mi certificado correspondiente.", fontTexto)));

            document.Add(CampoFecha(fechaServicio, fontTexto, fontNegrita));

            document.Add(ParrafoJustificado(6f, 0f,
                new Chunk("Firmo y dejo mi huella digital voluntariamente en señal de conformidad.", fontTexto)));
            #endregion

            #region Firma
            PdfPCell cellFirmaTrabajador;
            if (filiationData.FirmaTrabajador != null)
                cellFirmaTrabajador = new PdfPCell(HandlingItextSharp.GetImage(filiationData.FirmaTrabajador, null, null, 125, 40));
            else
                cellFirmaTrabajador = new PdfPCell(new Phrase(" ", fontTexto));

            PdfPCell cellHuellaTrabajador;
            if (filiationData.HuellaTrabajador != null)
                cellHuellaTrabajador = new PdfPCell(HandlingItextSharp.GetImage(filiationData.HuellaTrabajador, null, null, 50, 40));
            else
                cellHuellaTrabajador = new PdfPCell(new Phrase(" ", fontTexto));

            foreach (PdfPCell c in new[] { cellFirmaTrabajador, cellHuellaTrabajador })
            {
                c.HorizontalAlignment = Element.ALIGN_CENTER;
                c.VerticalAlignment = Element.ALIGN_MIDDLE;
                c.MinimumHeight = 78f;
                c.BorderWidth = 0.75f;
            }

            PdfPTable tablaFirma = new PdfPTable(2);
            tablaFirma.WidthPercentage = 80f;
            tablaFirma.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaFirma.SpacingBefore = 8f;
            tablaFirma.KeepTogether = true;
            tablaFirma.SetWidths(new float[] { 40f, 40f });
            tablaFirma.AddCell(cellFirmaTrabajador);
            tablaFirma.AddCell(cellHuellaTrabajador);
            tablaFirma.AddCell(new PdfPCell(new Phrase("FIRMA", fontNegrita)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, FixedHeight = 16f, BorderWidth = 0.75f });
            tablaFirma.AddCell(new PdfPCell(new Phrase("HUELLA DIGITAL", fontNegrita)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, FixedHeight = 16f, BorderWidth = 0.75f });
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
            p.SetLeading(0f, 1.2f);
            p.IndentationLeft = SANGRIA_TEXTO;
            p.IndentationRight = SANGRIA_TEXTO;
            p.SpacingBefore = espacioAntes;
            p.SpacingAfter = espacioDespues;
            return p;
        }

        /// <summary>Línea de dato subrayada (con etiqueta opcional a la izquierda y leyenda opcional debajo).</summary>
        private static PdfPTable CampoSubrayado(string etiqueta, string valor, string leyenda, Font fontEtiqueta, Font fontValor, Font fontLeyenda)
        {
            bool conEtiqueta = !string.IsNullOrEmpty(etiqueta);

            PdfPTable tabla = new PdfPTable(conEtiqueta ? 2 : 1);
            tabla.WidthPercentage = ANCHO_CONTENIDO;
            tabla.HorizontalAlignment = Element.ALIGN_CENTER;
            tabla.SpacingBefore = 2f;
            tabla.SpacingAfter = 2f;
            if (conEtiqueta)
                tabla.SetWidths(new float[] { 6f, 94f });

            if (conEtiqueta)
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
                if (conEtiqueta)
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
