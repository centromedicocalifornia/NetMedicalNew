using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace Sigesoft.Node.WinClient.UI.Reports
{
    /// <summary>
    /// Soporte para crHistoriaClinicaPsicologica (formato continuo).
    ///
    /// El reporte ahora es UNO solo: la antigua hoja 2 (crHistoriaClinicaPsicologica2) va como
    /// subreporte al final, de modo que el contenido fluye sin salto de hoja forzado.
    ///
    /// Para que el membrete se repita bien en cada página, la imagen de fondo se divide en 3 franjas:
    ///   - banner3_sup.jpg : cabecera (logo + título)   -> Encabezado de página
    ///   - banner3_med.jpg : fondo central (underlay)    -> Encabezado de página (subyacente)
    ///   - banner3_inf.jpg : pie (datos de contacto)     -> Pie de página
    /// Las franjas se generan aquí a partir de banner3.jpg (el mismo banner que usaba el formato),
    /// por lo que si se cambia el banner de la sede se regeneran automáticamente.
    ///
    /// InformePsicologicoOcupacional usa la misma técnica con una cabecera más alta (logo completo
    /// + Nro. de informe): banner3_sup2.jpg / banner3_med2.jpg, y el mismo banner3_inf.jpg.
    /// </summary>
    public static class HistoriaClinicaPsicologicaHelper
    {
        public const string SubreporteHoja2 = "crHistoriaClinicaPsicologica2.rpt";

        private const string BannerOrigen = @"C:\Program Files (x86)\NetMedical\Banner\banner3.jpg";
        private const string CarpetaFranjas = @"C:\ProgramData\NetMedical\Banner";

        // Medidas en twips del diseño (imagen original 11890 x 16821 tw).
        private const int AltoImagenTw = 16821;
        private const int CorteCabeceraTw = 1880;  // alto de la franja de cabecera (Historia Clínica)
        private const int CorteCabecera2Tw = 2200; // alto de la franja de cabecera (Informe Psicológico)
        private const int CortePieTw = 15100;      // inicio de la franja del pie

        private static readonly object _lock = new object();

        /// <summary>
        /// Asigna los datos al reporte principal y al subreporte (hoja 2) y asegura las franjas del banner.
        /// </summary>
        public static void AsignarDatos(ReportDocument rp, DataTable datos)
        {
            PrepararBanner();

            var ds = new DataSet();
            var dt = datos.Copy();
            dt.TableName = "dtHistoriaClinicaPsicologica";
            ds.Tables.Add(dt);
            rp.SetDataSource(ds);

            var ds2 = new DataSet();
            var dt2 = datos.Copy();
            dt2.TableName = "dtHistoriaClinicaPsicologica_2";
            ds2.Tables.Add(dt2);
            rp.Subreports[SubreporteHoja2].SetDataSource(ds2);
        }

        /// <summary>
        /// Genera (o regenera si el banner cambió) las 3 franjas del membrete.
        /// Si falla, el reporte se sigue generando, solo que sin imagen de fondo.
        /// </summary>
        public static void PrepararBanner()
        {
            try
            {
                lock (_lock)
                {
                    if (!File.Exists(BannerOrigen)) return;

                    string sup = Path.Combine(CarpetaFranjas, "banner3_sup.jpg");
                    string med = Path.Combine(CarpetaFranjas, "banner3_med.jpg");
                    string sup2 = Path.Combine(CarpetaFranjas, "banner3_sup2.jpg");
                    string med2 = Path.Combine(CarpetaFranjas, "banner3_med2.jpg");
                    string inf = Path.Combine(CarpetaFranjas, "banner3_inf.jpg");

                    DateTime fechaOrigen = File.GetLastWriteTime(BannerOrigen);
                    if (Array.TrueForAll(new[] { sup, med, sup2, med2, inf },
                            f => File.Exists(f) && File.GetLastWriteTime(f) >= fechaOrigen))
                        return;

                    Directory.CreateDirectory(CarpetaFranjas);

                    using (var original = new Bitmap(BannerOrigen))
                    {
                        Recortar(original, 0, CorteCabeceraTw, sup);
                        Recortar(original, CorteCabeceraTw, CortePieTw, med);
                        Recortar(original, 0, CorteCabecera2Tw, sup2);
                        Recortar(original, CorteCabecera2Tw, CortePieTw, med2);
                        Recortar(original, CortePieTw, AltoImagenTw, inf);
                    }
                }
            }
            catch (Exception)
            {
                // No interrumpir la generación del reporte por el fondo.
            }
        }

        private static void Recortar(Bitmap original, int desdeTw, int hastaTw, string destino)
        {
            int y0 = (int)Math.Round((double)desdeTw * original.Height / AltoImagenTw);
            int y1 = Math.Min(original.Height, (int)Math.Round((double)hastaTw * original.Height / AltoImagenTw));
            var area = new Rectangle(0, y0, original.Width, Math.Max(1, y1 - y0));

            using (var franja = original.Clone(area, original.PixelFormat))
            {
                var codec = Array.Find(ImageCodecInfo.GetImageEncoders(), c => c.FormatID == ImageFormat.Jpeg.Guid);
                var prms = new EncoderParameters(1);
                prms.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 95L);
                string tmp = destino + ".tmp";
                franja.Save(tmp, codec, prms);
                if (File.Exists(destino)) File.Delete(destino);
                File.Move(tmp, destino);
            }
        }
    }
}
