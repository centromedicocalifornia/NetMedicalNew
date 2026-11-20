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
    public class Informe_Psicologico_Resumen
    {
        private static void RunFile(string filePdf)
        {
            Process proceso = Process.Start(filePdf);
            proceso.WaitForExit();
            proceso.Close();
        }

        #region Estilos
        private const float PAD = 4f;          // relleno interno de celdas
        private const float BORDE = 0.75f;     // grosor de recuadros

        private static readonly Font fTitulo = FontFactory.GetFont("Calibri", 13, Font.BOLD, BaseColor.BLACK);
        private static readonly Font fSeccion = FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK);
        private static readonly Font fEtiqueta = FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK);
        private static readonly Font fValor = FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK);
        private static readonly Font fTexto = FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK);

        private static string S(string v) { return string.IsNullOrWhiteSpace(v) ? "" : v.Trim(); }

        private static string Fecha(DateTime? d) { return d.HasValue ? d.Value.ToString("dd/MM/yyyy") : ""; }

        // Celda sin bordes
        private static PdfPCell Celda(string texto, Font f, int colspan = 1, int align = Element.ALIGN_LEFT)
        {
            var c = new PdfPCell(new Phrase(texto ?? "", f))
            {
                Colspan = colspan,
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = align,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                PaddingTop = 3f, PaddingBottom = 4f, PaddingLeft = PAD, PaddingRight = PAD
            };
            return c;
        }

        // Título de sección: recuadro a todo el ancho (mismo estilo que la Historia Clínica)
        private static PdfPTable TituloSeccion(string texto)
        {
            var t = new PdfPTable(1) { WidthPercentage = 100, SpacingBefore = 8f, SpacingAfter = 2f };
            t.AddCell(new PdfPCell(new Phrase(texto, fSeccion))
            {
                BorderWidth = BORDE,
                PaddingTop = 3f, PaddingBottom = 5f, PaddingLeft = PAD,
                VerticalAlignment = Element.ALIGN_MIDDLE
            });
            return t;
        }

        // Bloque de texto libre (respeta saltos de línea, justificado)
        private static PdfPTable BloqueTexto(string texto, float minAltura = 0f)
        {
            var t = new PdfPTable(1) { WidthPercentage = 100 };
            var p = new Paragraph(S(texto).Replace("\r\n", "\n"), fTexto) { Alignment = Element.ALIGN_JUSTIFIED };
            p.SetLeading(0f, 1.25f);
            var c = new PdfPCell { Border = Rectangle.NO_BORDER, PaddingTop = 2f, PaddingBottom = 4f, PaddingLeft = PAD, PaddingRight = PAD };
            if (minAltura > 0) c.MinimumHeight = minAltura;
            c.AddElement(p);
            t.AddCell(c);
            return t;
        }

        // Casilla de marcado:  ETIQUETA ( X )
        private static PdfPCell Casilla(string etiqueta, bool marcado)
        {
            var ph = new Phrase();
            ph.Add(new Chunk(etiqueta + "  ", fEtiqueta));
            ph.Add(new Chunk("( " + (marcado ? "X" : "  ") + " )", fValor));
            return new PdfPCell(ph) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 4f, PaddingBottom = 6f };
        }

        private static bool Marcado(string v) { v = S(v); return v == "1" || v.Equals("X", StringComparison.OrdinalIgnoreCase); }
        #endregion

        #region Reporte informe
        public static void CreateInforme_Psicologico_Resumen(PacientList filiationData, ServiceList DataService,
            List<ServiceComponentList> serviceComponent,
            organizationDto infoEmpresa,
            PacientList datosPac,
            string filePDF)
        {
            // Márgenes: superior deja libre el logo del membrete; inferior, el pie del membrete
            Document document = new Document(PageSize.A4, 40f, 40f, 105f, 90f);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePDF, FileMode.Create));
            pdfPage_NEW page = new pdfPage_NEW();
            page.Title = string.Empty;
            writer.PageEvent = page;
            document.Open();

            ServiceComponentList informe = serviceComponent.Find(p => p.v_ComponentId == Sigesoft.Common.Constants.INFORME_PSICOLOGICO_RESUMEN_ID);
            Func<string, string> campo = id =>
            {
                if (informe == null || informe.ServiceComponentFields == null) return "";
                var f = informe.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == id);
                return f == null ? "" : f.v_Value1;
            };

            #region TÍTULO
            var titulo = new Paragraph("INFORME PSICOLÓGICO", fTitulo) { Alignment = Element.ALIGN_CENTER, SpacingAfter = 6f };
            document.Add(titulo);
            #endregion

            #region I.- DATOS GENERALES
            document.Add(TituloSeccion("I.- DATOS GENERALES:"));

            string sexo = S(datosPac.Genero);
            var datos = new PdfPTable(4) { WidthPercentage = 100 };
            datos.SetWidths(new float[] { 22f, 33f, 20f, 25f });

            datos.AddCell(Celda("Apellidos y Nombres:", fEtiqueta));
            datos.AddCell(Celda(S(datosPac.v_FirstLastName + " " + datosPac.v_SecondLastName + " " + datosPac.v_FirstName), fValor, 3));

            datos.AddCell(Celda("Lugar de Nacimiento:", fEtiqueta));
            datos.AddCell(Celda(S(datosPac.v_BirthPlace), fValor));
            datos.AddCell(Celda("Fecha de Nacimiento:", fEtiqueta));
            datos.AddCell(Celda(Fecha(datosPac.d_Birthdate), fValor));

            datos.AddCell(Celda("Edad:", fEtiqueta));
            datos.AddCell(Celda(datosPac.Edad.HasValue ? datosPac.Edad.Value + " años" : "", fValor));
            datos.AddCell(Celda("Sexo:", fEtiqueta));
            datos.AddCell(Celda(sexo, fValor));

            datos.AddCell(Celda("Grado de Instrucción:", fEtiqueta));
            datos.AddCell(Celda(S(datosPac.GradoInstruccion), fValor, 3));

            datos.AddCell(Celda("Dirección:", fEtiqueta));
            datos.AddCell(Celda(S(datosPac.v_AdressLocation), fValor, 3));

            datos.AddCell(Celda("Fecha de Evaluación:", fEtiqueta));
            datos.AddCell(Celda(Fecha(datosPac.FechaServicio), fValor, 3));
            document.Add(datos);
            #endregion

            #region II.- MOTIVO / III.- PRUEBAS
            document.Add(TituloSeccion("II.- MOTIVO DE EVALUACIÓN:"));
            document.Add(BloqueTexto(campo(Sigesoft.Common.Constants.INFORME_PSICOLOGICO_RESUMEN_EVALUACION)));

            document.Add(TituloSeccion("III.- PRUEBAS APLICADAS:"));
            document.Add(BloqueTexto(campo(Sigesoft.Common.Constants.INFORME_PSICOLOGICO_RESUMEN_PRUEBAS_APLICADAS)));
            #endregion

            #region IV.- RESULTADOS / V.- CONCLUSIONES
            document.Add(TituloSeccion("IV.- RESULTADOS:"));
            document.Add(BloqueTexto(campo(Sigesoft.Common.Constants.INFORME_PSICOLOGICO_RESUMEN_RESULTADOS)));

            document.Add(TituloSeccion("V.- CONCLUSIONES:"));
            document.Add(BloqueTexto(campo(Sigesoft.Common.Constants.INFORME_PSICOLOGICO_RESUMEN_CONCLUSIONES)));
            #endregion

            #region VI.- APTITUD
            document.Add(TituloSeccion("VI.- APTITUD PSICOLÓGICA:"));
            var aptitud = new PdfPTable(3) { WidthPercentage = 100, SpacingBefore = 2f };
            aptitud.AddCell(Casilla("APTO", Marcado(campo(Sigesoft.Common.Constants.INFORME_PSICOLOGICO_RESUMEN_APTO))));
            aptitud.AddCell(Casilla("NO APTO", Marcado(campo(Sigesoft.Common.Constants.INFORME_PSICOLOGICO_RESUMEN_NOAPTO))));
            aptitud.AddCell(Casilla("OBSERVADO", Marcado(campo(Sigesoft.Common.Constants.INFORME_PSICOLOGICO_RESUMEN_OBSERVADO))));
            document.Add(aptitud);
            #endregion

            #region Firma
            var psico = serviceComponent.Find(p => p.i_CategoryId == (int)Sigesoft.Common.Consultorio.Psicología);

            PdfPCell cellFirma;
            if (psico != null && psico.FirmaMedico != null)
                cellFirma = new PdfPCell(HandlingItextSharp.GetImage(psico.FirmaMedico, null, null, 130, 55));
            else
                cellFirma = new PdfPCell(new Phrase(" ", fValor));
            cellFirma.Border = Rectangle.NO_BORDER;
            cellFirma.HorizontalAlignment = Element.ALIGN_CENTER;
            cellFirma.VerticalAlignment = Element.ALIGN_BOTTOM;
            cellFirma.FixedHeight = 62f;

            var firma = new PdfPTable(3) { WidthPercentage = 100, SpacingBefore = 18f, KeepTogether = true };
            firma.SetWidths(new float[] { 30f, 40f, 30f });
            var vacia = new PdfPCell(new Phrase(" ")) { Border = Rectangle.NO_BORDER };
            firma.AddCell(vacia); firma.AddCell(cellFirma); firma.AddCell(vacia);
            firma.AddCell(vacia);
            firma.AddCell(new PdfPCell(new Phrase("FIRMA Y SELLO DEL PSICÓLOGO", fEtiqueta))
            {
                Border = Rectangle.TOP_BORDER, BorderWidthTop = BORDE,
                HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 4f
            });
            firma.AddCell(vacia);
            document.Add(firma);
            #endregion

            document.Close();
            writer.Close();
            writer.Dispose();
        }
        #endregion
    }
}
