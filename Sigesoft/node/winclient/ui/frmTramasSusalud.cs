using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sigesoft.Node.WinClient.BE.Custom;
using Sigesoft.Node.WinClient.BLL;
using Sigesoft.Common;
using Sigesoft.Node.WinClient.BE;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid.DocumentExport;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using Sigesoft.Node.Contasol.Integration;
using NetPdf;

namespace Sigesoft.Node.WinClient.UI
{
    public partial class frmTramasSusalud : Form
    {
        string strFilterExpression;
        object lista;
        object listaUps;
        object listaproc;
        List<TramasList> _objData = new List<TramasList>();

        List<ServiciosTramas> _objDataLista = new List<ServiciosTramas>();

        List<ServiciosTramas> ListServiciosTramas = new List<ServiciosTramas>();

        TramasBL _objTramasBL = new TramasBL();
        public frmTramasSusalud()
        {
            InitializeComponent();
            OperationResult objOperationResult = new OperationResult();
            PacientBL _PacientBL = new PacientBL();
            using (new LoadingClass.PleaseWait(this.Location, "Data CIE10..."))
            {
                lista = _PacientBL.LlenarDxsTramas(ref objOperationResult);
            };
            using (new LoadingClass.PleaseWait(this.Location, "Data UPS..."))
            {
                listaUps = _PacientBL.LlenarListaUps(ref objOperationResult);
            };
            using (new LoadingClass.PleaseWait(this.Location, "Data Procedimientos..."))
            {
                listaproc = _PacientBL.LlenarListaProc(ref objOperationResult);
            };
            
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string tabName = utcSusalud.SelectedTab.Text;

            var fecha= grService.Selected.Rows[0].Cells["fechaservicio"].Value.ToString();
            var servicio = grService.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
            var hospitId =  grService.Selected.Rows[0].Cells["HospId"].Value == null?"" : grService.Selected.Rows[0].Cells["HospId"].Value.ToString();
            var validador = grService.Selected.Rows[0].Cells["Value1"].Value.ToString();
            string cpmsId = null;
            string procedimiento = null;
            string _ServiceComponentId = null;
            string _DiagnosticRepositoryId = null;

            if (tabName == "Ambulatorio" )
            {
                _DiagnosticRepositoryId = grService.Selected.Rows[0].Cells["Value3"].Value.ToString();
            }
            else if (tabName == "Procedimientos")
            {
                cpmsId = grService.Selected.Rows[0].Cells["v_CodigoCPMS"].Value.ToString();
                procedimiento = grService.Selected.Rows[0].Cells["v_DescripcionCPMS"].Value.ToString();
                _ServiceComponentId = grService.Selected.Rows[0].Cells["Value2"].Value.ToString();

            }


            DateTime parsedDate = DateTime.Parse(fecha);
            var genero= grService.Selected.Rows[0].Cells["genero"].Value.ToString() == "M"?"MASCULINO":"FEMENINO";
            var edad= grService.Selected.Rows[0].Cells["edad"].Value.ToString();
            frmRegistroEmAmHos frmRegistroEm = new frmRegistroEmAmHos(tabName, string.Empty, "New", parsedDate, genero, edad, lista, listaUps, listaproc, servicio,
                hospitId, validador, cpmsId, procedimiento, _ServiceComponentId, _DiagnosticRepositoryId);
            frmRegistroEm.Text = "Registrar: " + tabName;
            if (tabName == "Ambulatorio" || tabName == "Emergencia" || tabName == "Partos")
            {
                frmRegistroEm.Size = new Size(638, 196);
            }
            else if (tabName == "Hospitalización")
            {
                frmRegistroEm.Size = new Size(638, 236);
            }
            else if (tabName == "Procedimientos / Cirugía")
            {
                frmRegistroEm.Size = new Size(638, 300);
            }
            else if (tabName == "Procedimientos")
            {
                frmRegistroEm.Size = new Size(638, 236);
            }
            frmRegistroEm.Show();
            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            //btnFilter_Click(sender, e);
            this.BindGrid();
        }

        //public void btnFilter_Click(object sender, EventArgs e)
        //{
        //    OperationResult objOperationResult = new OperationResult();
        //    if (dtpDateTimeStar.Value > dptDateTimeEnd.Value)
        //    {
        //        MessageBox.Show("La Fecha inicial no puede ser mayor a la final:" + System.Environment.NewLine + objOperationResult.ExceptionMessage, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    List<string> Filters = new List<string>();
        //    if (!string.IsNullOrEmpty(txtPacient.Text)) Filters.Add("v_DiseasesName.Contains(\"" + txtPacient.Text.Trim() + "\")");

        //    //Filters.Add("i_IsDeleted == 0");
        //    strFilterExpression = null;
        //    if (Filters.Count > 0)
        //    {
        //        foreach (string item in Filters)
        //        {
        //            strFilterExpression = strFilterExpression + item + " && ";
        //        }
        //        strFilterExpression = strFilterExpression.Substring(0, strFilterExpression.Length - 4);
        //    }

        //    this.BindGrid();
        //    btnAgregar.Enabled = false;
        //    btnEditar.Enabled = false;
        //    btnEliminar.Enabled = false;
        //}

        public void btnFilter_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            if (dtpDateTimeStar.Value > dptDateTimeEnd.Value)
            {
                MessageBox.Show("La Fecha inicial no puede ser mayor a la final:" + System.Environment.NewLine + objOperationResult.ExceptionMessage, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<string> Filters = new List<string>();
            if (!string.IsNullOrEmpty(txtPacient.Text)) Filters.Add("v_DiseasesName.Contains(\"" + txtPacient.Text.Trim() + "\")");

            //Filters.Add("i_IsDeleted == 0");
            strFilterExpression = null;
            if (Filters.Count > 0)
            {
                foreach (string item in Filters)
                {
                    strFilterExpression = strFilterExpression + item + " && ";
                }
                strFilterExpression = strFilterExpression.Substring(0, strFilterExpression.Length - 4);
            }

            this.BindGrid();
            btnAgregar.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }


        private void BindGrid()
        {
            var objDataService = GetDataServices(0, null, "v_ServiceId ASC", strFilterExpression);
            ListServiciosTramas = objDataService;
            grService.DataSource = objDataService;
            lblServices.Text = string.Format("Se encontraron {0} registros.", objDataService.Count());
            //this.grService.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            //
            string tabName = utcSusalud.SelectedTab.Text;

            if (tabName == "Ambulatorio")
            {
                var objData = GetData(0, null, "d_FechaIngreso ASC", strFilterExpression);
                grAmbulatorio.DataSource = objData;

                lblRecordCount.Text = string.Format("Se encontraron {0} registros.", objData.Count());
                if (objData.Count() >= 1)
                {
                    btnExportAmbulatorio.Enabled = true;
                }
                else
                {
                    btnExportAmbulatorio.Enabled = false;
                }

                //this.grAmbulatorio.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else if (tabName == "Emergencia")
            {
                var objData = GetData(0, null, "d_FechaIngreso ASC", strFilterExpression);
                grEmergencia.DataSource = objData;

                lblRecordCount1.Text = string.Format("Se encontraron {0} registros.", objData.Count());
                if (objData.Count() >= 1)
                {
                    btnExportEmergencia.Enabled = true;
                }
                else
                {
                    btnExportEmergencia.Enabled = false;
                }

                this.grEmergencia.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else if (tabName == "Hospitalización")
            {
                var objData = GetData(0, null, "d_FechaIngreso ASC", strFilterExpression);
                grHospitalizacion.DataSource = objData;

                lblRecordCount2.Text = string.Format("Se encontraron {0} registros.", objData.Count());
                if (objData.Count() >= 1)
                {
                    btnExportHospitalizacion.Enabled = true;
                }
                else
                {
                    btnExportHospitalizacion.Enabled = false;
                }

                //this.grHospitalizacion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else if (tabName == "Procedimientos / Cirugía")
            {
                var objData = GetData(0, null, "d_FechaIngreso ASC", strFilterExpression);
                grProcedimientosCirugia.DataSource = objData;

                //lblRecordCount3.Text = string.Format("Se encontraron {0} registros.", objData.Count());
                if (objData.Count() >= 1)
                {
                    btnExportProcedimientosCirugias.Enabled = true;
                }
                else
                {
                    btnExportProcedimientosCirugias.Enabled = false;
                }

                //this.grProcedimientosCirugia.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else if (tabName == "Procedimientos")
            {
                var objData = GetData(0, null, "d_FechaIngreso ASC", strFilterExpression);
                grProcedimientos.DataSource = objData;

                label3.Text = string.Format("Se encontraron {0} registros.", objData.Count());
                if (objData.Count() >= 1)
                {
                    btnExportProcedimientos.Enabled = true;
                }
                else
                {
                    btnExportProcedimientos.Enabled = false;
                }

                this.grProcedimientos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else if (tabName == "Partos")
            {
                var objData = GetData(0, null, "d_FechaIngreso ASC", strFilterExpression);
                grPartos.DataSource = objData;

                lblRecordCount4.Text = string.Format("Se encontraron {0} registros.", objData.Count());
                if (objData.Count() >= 1)
                {
                    btnExportartos.Enabled = true;
                }
                else
                {
                    btnExportartos.Enabled = false;
                }

                //this.grPartos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            
        }

        private List<TramasList> GetData(int pintPageIndex, int? pintPageSize, string pstrSortExpression, string pstrFilterExpression)
        {
            OperationResult objOperationResult = new OperationResult();
            DateTime? pdatBeginDate = dtpDateTimeStar.Value.Date;
            DateTime? pdatEndDate = dptDateTimeEnd.Value.Date.AddDays(1);

            string tabName = utcSusalud.SelectedTab.Text;

            if (tabName == "Ambulatorio")
            {
                _objData = _objTramasBL.GettramasPageAndFilteredAmbulatorio(ref objOperationResult, pintPageIndex, pintPageSize, pstrSortExpression, pstrFilterExpression, pdatBeginDate, pdatEndDate);
            }
            else if (tabName == "Emergencia")
            {
                _objData = _objTramasBL.GettramasPageAndFilteredEmergencia(ref objOperationResult, pintPageIndex, pintPageSize, pstrSortExpression, pstrFilterExpression, pdatBeginDate, pdatEndDate);
            }
            else if (tabName == "Partos")
            {
                _objData = _objTramasBL.GettramasPageAndFilteredPartos(ref objOperationResult, pintPageIndex, pintPageSize, pstrSortExpression, pstrFilterExpression, pdatBeginDate, pdatEndDate);
            }
            else if (tabName == "Hospitalización")
            {
                _objData = _objTramasBL.GettramasPageAndFilteredHospitalizacion(ref objOperationResult, pintPageIndex, pintPageSize, pstrSortExpression, pstrFilterExpression, pdatBeginDate, pdatEndDate);
            }
            else if (tabName == "Procedimientos / Cirugía")
            {
                _objData = _objTramasBL.GettramasPageAndFilteredProcedimientosCirugia(ref objOperationResult, pintPageIndex, pintPageSize, pstrSortExpression, pstrFilterExpression, pdatBeginDate, pdatEndDate);
            }
            else if (tabName == "Procedimientos")
            {
                _objData = _objTramasBL.GettramasPageAndFilteredProcedimientos(ref objOperationResult, pintPageIndex, pintPageSize, pstrSortExpression, pstrFilterExpression, pdatBeginDate, pdatEndDate);
            }

            if (objOperationResult.Success != 1)
            {
                MessageBox.Show("Error en operación:" + System.Environment.NewLine + objOperationResult.ExceptionMessage, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _objData;
        }

        private List<ServiciosTramas> GetDataServices(int pintPageIndex, int? pintPageSize, string pstrSortExpression, string pstrFilterExpression)
        {

            OperationResult objOperationResult = new OperationResult();
            DateTime? pdatBeginDate = dtpDateTimeStar.Value.Date;
            DateTime? pdatEndDate = dptDateTimeEnd.Value.Date.AddDays(1);
            //_objDataLista = new List<ServiceList>();
            string tabName = utcSusalud.SelectedTab.Text;

            if (tabName == "Ambulatorio")
            {
                //this.grService.DisplayLayout.Reset();

                _objDataLista = new ServiceBL().GetServiceForTramasPageAndFilteredAmbulatorio(ref objOperationResult, pintPageIndex, pintPageSize, pstrSortExpression, pstrFilterExpression, pdatBeginDate, pdatEndDate);

                grService.DisplayLayout.Bands[0].Columns["v_componentId"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["d_BirthDate"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["Examen"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["v_CodigoCPMS"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["v_DescripcionCPMS"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["i_TramaCargada"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["HospId"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["TramaHosp"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["TramaSop"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["Value3"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["Value4"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["Value5"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["v_componentId"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["i_TramaCargada"].Hidden = true;

                //grService.DisplayLayout.Bands[0].Columns["Trama"].Hidden = true;

                grService.DisplayLayout.Bands[0].Columns["CIE_10"].Hidden = false;
                grService.DisplayLayout.Bands[0].Columns["Diagnostico"].Hidden = false;
                grService.DisplayLayout.Bands[0].Columns["Value1"].Hidden = false;
                grService.DisplayLayout.Bands[0].Columns["Value2"].Hidden = false;


                grService.DisplayLayout.Bands[0].Columns["v_ServiceId"].Header.VisiblePosition = 0;
                grService.DisplayLayout.Bands[0].Columns["nombre"].Header.VisiblePosition = 1;
                grService.DisplayLayout.Bands[0].Columns["genero"].Header.VisiblePosition = 2;
                grService.DisplayLayout.Bands[0].Columns["fechaservicio"].Header.VisiblePosition = 3;
                grService.DisplayLayout.Bands[0].Columns["edad"].Header.VisiblePosition = 4;
                grService.DisplayLayout.Bands[0].Columns["tipoServicio"].Header.VisiblePosition = 5;
                grService.DisplayLayout.Bands[0].Columns["Medico"].Header.VisiblePosition = 6;
                grService.DisplayLayout.Bands[0].Columns["Protocolo"].Header.VisiblePosition = 7;
                grService.DisplayLayout.Bands[0].Columns["CIE_10"].Header.VisiblePosition = 8;
                grService.DisplayLayout.Bands[0].Columns["Diagnostico"].Header.VisiblePosition = 9;
                grService.DisplayLayout.Bands[0].Columns["Value1"].Header.VisiblePosition = 10;
                grService.DisplayLayout.Bands[0].Columns["Value2"].Header.VisiblePosition = 11;
                grService.DisplayLayout.Bands[0].Columns["i_TramaCargadaProc"].Header.VisiblePosition = 12;
                grService.DisplayLayout.Bands[0].Columns["v_TramaId"].Header.VisiblePosition = 13;

                grService.DisplayLayout.Bands[0].Columns["Value1"].Header.Caption = "CIE-BASE";
                grService.DisplayLayout.Bands[0].Columns["Value2"].Header.Caption = "DX-BASE";

            
            }
            else if (tabName == "Emergencia")
            {
                _objDataLista = new ServiceBL().GetServiceForTramasPageAndFilteredEmergencia(ref objOperationResult, pintPageIndex, pintPageSize, pstrSortExpression, pstrFilterExpression, pdatBeginDate, pdatEndDate);
            }
            else if (tabName == "Partos")
            {
                _objDataLista = new ServiceBL().GetServiceForTramasPageAndFilteredPartos(ref objOperationResult, pintPageIndex, pintPageSize, pstrSortExpression, pstrFilterExpression, pdatBeginDate, pdatEndDate);
            }
            else if (tabName == "Hospitalización")
            {
                _objDataLista = new ServiceBL().GetServiceForTramasPageAndFilteredHospitalizacion(ref objOperationResult, pintPageIndex, pintPageSize, pstrSortExpression, pstrFilterExpression, pdatBeginDate, pdatEndDate);
            }
            else if (tabName == "Procedimientos / Cirugía")
            {
                _objDataLista = new ServiceBL().GetServiceForTramasPageAndFilteredProcedimientosCirugias(ref objOperationResult, pintPageIndex, pintPageSize, pstrSortExpression, pstrFilterExpression, pdatBeginDate, pdatEndDate);
            }
            else if (tabName == "Procedimientos")
            {
                //this.grService.DisplayLayout.Reset();

                _objDataLista = new ServiceBL().GetServiceForTramasPageAndFilteredProcedimientos(ref objOperationResult, pintPageIndex, pintPageSize, pstrSortExpression, pstrFilterExpression, pdatBeginDate, pdatEndDate);

                grService.DisplayLayout.Bands[0].Columns["d_BirthDate"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["v_componentId"].Hidden = true;
                //grService.DisplayLayout.Bands[0].Columns["Trama"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["CIE_10"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["Diagnostico"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["HospId"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["TramaHosp"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["TramaSop"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["Value1"].Hidden = true;
                //grService.DisplayLayout.Bands[0].Columns["Value2"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["Value3"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["Value4"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["Value5"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["i_TramaCargada"].Hidden = true;
                grService.DisplayLayout.Bands[0].Columns["v_componentId"].Hidden = true;

                //revisar para regresar
                grService.DisplayLayout.Bands[0].Columns["Examen"].Hidden = false;
                grService.DisplayLayout.Bands[0].Columns["v_CodigoCPMS"].Hidden = false;
                grService.DisplayLayout.Bands[0].Columns["v_DescripcionCPMS"].Hidden = false;

                grService.DisplayLayout.Bands[0].Columns["v_ServiceId"].Header.VisiblePosition = 0;
                grService.DisplayLayout.Bands[0].Columns["nombre"].Header.VisiblePosition = 1;
                grService.DisplayLayout.Bands[0].Columns["genero"].Header.VisiblePosition = 2;
                grService.DisplayLayout.Bands[0].Columns["fechaservicio"].Header.VisiblePosition = 3;
                grService.DisplayLayout.Bands[0].Columns["edad"].Header.VisiblePosition = 4;
                grService.DisplayLayout.Bands[0].Columns["tipoServicio"].Header.VisiblePosition = 5;
                grService.DisplayLayout.Bands[0].Columns["Examen"].Header.VisiblePosition = 6;
                grService.DisplayLayout.Bands[0].Columns["Protocolo"].Header.VisiblePosition = 7;
                grService.DisplayLayout.Bands[0].Columns["v_CodigoCPMS"].Header.VisiblePosition = 8;
                grService.DisplayLayout.Bands[0].Columns["v_DescripcionCPMS"].Header.VisiblePosition = 9;
                grService.DisplayLayout.Bands[0].Columns["Medico"].Header.VisiblePosition = 10;
                grService.DisplayLayout.Bands[0].Columns["i_TramaCargadaProc"].Header.VisiblePosition = 11;
                grService.DisplayLayout.Bands[0].Columns["v_TramaId"].Header.VisiblePosition = 12;


            }

            if (objOperationResult.Success != 1)
            {
                MessageBox.Show("Error en operación:" + System.Environment.NewLine + objOperationResult.ExceptionMessage, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _objDataLista;
        }
        private void btnExportAmbulatorio_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "";
            NombreArchivo = "Reporte Datos Ambulatorio del " + dtpDateTimeStar.Text + " al " + dptDateTimeEnd.Text + "-tramas";
            NombreArchivo = NombreArchivo.Replace("/", "_");
            NombreArchivo = NombreArchivo.Replace(":", "_");

            saveFileDialog1.FileName = NombreArchivo;
            saveFileDialog1.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter1.Export(this.grAmbulatorio, saveFileDialog1.FileName);
                MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnExportEmergencia_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "";
            NombreArchivo = "Reporte Datos Emergencia del " + dtpDateTimeStar.Text + " al " + dptDateTimeEnd.Text + "-tramas";
            NombreArchivo = NombreArchivo.Replace("/", "_");
            NombreArchivo = NombreArchivo.Replace(":", "_");

            saveFileDialog1.FileName = NombreArchivo;
            saveFileDialog1.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter1.Export(this.grEmergencia, saveFileDialog1.FileName);
                MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnExportHospitalizacion_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "";
            NombreArchivo = "Reporte Datos Hospitalización del " + dtpDateTimeStar.Text + " al " + dptDateTimeEnd.Text + "-tramas";
            NombreArchivo = NombreArchivo.Replace("/", "_");
            NombreArchivo = NombreArchivo.Replace(":", "_");

            saveFileDialog1.FileName = NombreArchivo;
            saveFileDialog1.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter1.Export(this.grHospitalizacion, saveFileDialog1.FileName);
                MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnExportProcedimientosCirugias_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "";
            NombreArchivo = "Reporte Datos Procedimientos/Cirugía del " + dtpDateTimeStar.Text + " al " + dptDateTimeEnd.Text + "-tramas";
            NombreArchivo = NombreArchivo.Replace("/", "_");
            NombreArchivo = NombreArchivo.Replace(":", "_");

            saveFileDialog1.FileName = NombreArchivo;
            saveFileDialog1.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter1.Export(this.grProcedimientosCirugia, saveFileDialog1.FileName);
                MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnExportartos_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "";
            NombreArchivo = "Reporte Datos Partos del " + dtpDateTimeStar.Text + " al " + dptDateTimeEnd.Text + "-tramas";
            NombreArchivo = NombreArchivo.Replace("/", "_");
            NombreArchivo = NombreArchivo.Replace(":", "_");

            saveFileDialog1.FileName = NombreArchivo;
            saveFileDialog1.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter1.Export(this.grPartos, saveFileDialog1.FileName);
                MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            frmExportTramas frm = new frmExportTramas();
            frm.Show();
        }

        private void frmTramasSusalud_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGenerar.Enabled = true;

            btnExportAmbulatorio.Enabled = false;
            btnExportEmergencia.Enabled = false;
            btnExportHospitalizacion.Enabled = false;
            btnExportProcedimientosCirugias.Enabled = false;
            btnExportartos.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                OperationResult objOperationResult = new OperationResult();

                string tramaId = null;
                string ServiceId = null;
                string tabName = utcSusalud.SelectedTab.Text;

                if (tabName == "Ambulatorio")
                {
                    tramaId = grAmbulatorio.Selected.Rows[0].Cells["v_TramaId"].Value.ToString();
                    ServiceId = grAmbulatorio.Selected.Rows[0].Cells["v_ServiceId"].Value == null ? "" : grAmbulatorio.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
                }
                else if (tabName == "Emergencia")
                {
                    tramaId = grEmergencia.Selected.Rows[0].Cells["v_TramaId"].Value.ToString();
                    ServiceId = grEmergencia.Selected.Rows[0].Cells["v_ServiceId"].Value == null ?"" : grEmergencia.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
                }
                else if (tabName == "Hospitalización")
                {
                    tramaId = grHospitalizacion.Selected.Rows[0].Cells["v_TramaId"].Value.ToString();
                    ServiceId = grHospitalizacion.Selected.Rows[0].Cells["v_ServiceId"].Value == null ? "" : grHospitalizacion.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
                }
                else if (tabName == "Procedimientos / Cirugía")
                {
                    tramaId = grProcedimientosCirugia.Selected.Rows[0].Cells["v_TramaId"].Value.ToString();
                    ServiceId = grProcedimientosCirugia.Selected.Rows[0].Cells["v_ServiceId"].Value == null ? "" : grProcedimientosCirugia.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
                }
                else if (tabName == "Partos")
                {
                    tramaId = grPartos.Selected.Rows[0].Cells["v_TramaId"].Value.ToString();
                    ServiceId = grPartos.Selected.Rows[0].Cells["v_ServiceId"].Value == null ? "" : grPartos.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
                }


                //string tabName = utcSusalud.SelectedTab.Text;
                frmRegistroEmAmHos frmRegistroEm = new frmRegistroEmAmHos(tabName, tramaId, "Edit", DateTime.Now, string.Empty, string.Empty, lista, listaUps, listaproc, ServiceId, "", "",null,null,null,null);
                frmRegistroEm.Text = "Editar: " + tabName;
                if (tabName == "Ambulatorio" || tabName == "Emergencia" || tabName == "Partos")
                {
                    frmRegistroEm.Size = new Size(638, 196);
                }
                else if (tabName == "Hospitalización")
                {
                    frmRegistroEm.Size = new Size(638, 236);
                }
                else if (tabName == "Procedimientos / Cirugía")
                {
                    frmRegistroEm.Size = new Size(638, 300);
                }
                frmRegistroEm.Show();
                btnAgregar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnFilter_Click(sender, e);
           }
            catch (Exception exception)
            {
                MessageBox.Show("SELECCIONE UNA TRAMA A EDITAR", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnFilter_Click(sender, e);
            }
            //btnFilter_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OperationResult objOperationResult = new OperationResult();

                string tramaId = null;
                string ServiceId = null;
                string HospId = null;
                string DiagnosticRepositoryId = null;
                string ServiceComponentId = null;

                string tabName = utcSusalud.SelectedTab.Text;
                string modo = "";
                if (tabName == "Ambulatorio")
                {
                    tramaId = grAmbulatorio.Selected.Rows[0].Cells["v_TramaId"].Value.ToString();
                    ServiceId = grAmbulatorio.Selected.Rows[0].Cells["v_ServiceId"].Value == null ? "" : grEmergencia.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();

                    DiagnosticRepositoryId = grAmbulatorio.Selected.Rows[0].Cells["v_DiagnosticRepositoryId"].Value == null ? "" : grAmbulatorio.Selected.Rows[0].Cells["v_DiagnosticRepositoryId"].Value.ToString();
                }
                else if (tabName == "Emergencia")
                {
                    tramaId = grEmergencia.Selected.Rows[0].Cells["v_TramaId"].Value.ToString();
                    ServiceId = grEmergencia.Selected.Rows[0].Cells["v_ServiceId"].Value == null ? "" : grEmergencia.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
                }
                else if (tabName == "Hospitalización")
                {
                    tramaId = grHospitalizacion.Selected.Rows[0].Cells["v_TramaId"].Value.ToString();
                    ServiceId = grHospitalizacion.Selected.Rows[0].Cells["v_ServiceId"].Value == null ? "" : grHospitalizacion.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
                    HospId = grHospitalizacion.Selected.Rows[0].Cells["v_ComentaryUpdate"].Value == null ? "" : grHospitalizacion.Selected.Rows[0].Cells["v_ComentaryUpdate"].Value.ToString();

                    modo = "HOSP";
                }
                else if (tabName == "Procedimientos / Cirugía")
                {
                    tramaId = grProcedimientosCirugia.Selected.Rows[0].Cells["v_TramaId"].Value.ToString();
                    ServiceId = grProcedimientosCirugia.Selected.Rows[0].Cells["v_ServiceId"].Value == null ? "" : grProcedimientosCirugia.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
                    HospId = grProcedimientosCirugia.Selected.Rows[0].Cells["v_ComentaryUpdate"].Value == null ? "" : grProcedimientosCirugia.Selected.Rows[0].Cells["v_ComentaryUpdate"].Value.ToString();

                    modo = "SOP";

                }
                else if (tabName == "Procedimientos")
                {
                    tramaId = grProcedimientos.Selected.Rows[0].Cells["v_TramaId"].Value.ToString();
                    ServiceId = grProcedimientos.Selected.Rows[0].Cells["v_ServiceId"].Value == null ? "" : grProcedimientos.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();

                    ServiceComponentId = grProcedimientos.Selected.Rows[0].Cells["v_ServiceComponentId"].Value == null ? "" : grProcedimientos.Selected.Rows[0].Cells["v_ServiceComponentId"].Value.ToString();
                    modo = "SOP";

                }
                else if (tabName == "Partos")
                {
                    tramaId = grPartos.Selected.Rows[0].Cells["v_TramaId"].Value.ToString();
                    ServiceId = grPartos.Selected.Rows[0].Cells["v_ServiceId"].Value == null ? "" : grPartos.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
                }

                DialogResult Result = MessageBox.Show("¿Está seguro de eliminar TRAMA?", "ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (ServiceId != "")
                    {
                        if (tabName == "Ambulatorio")
                        {
                            _objTramasBL.ActualizarDxRepositoryTramaDelete(0, DiagnosticRepositoryId);

                        }
                        else if (tabName == "Procedimientos")
                        {
                            _objTramasBL.ActualizarServiceComponentTramaDelete(0, ServiceComponentId);
                        }
                        else if (tabName == "Hospitalización")
                        {
                            _objTramasBL.ActualizarServicioTrama(ServiceId, 0);
                            _objTramasBL.ActualizarHospTrama(HospId, 0, modo);
                        }
                        else
                        {

                        }

                    }
                    _objTramasBL.DeleteTrama(tramaId, Globals.ClientSession.GetAsList());
                }
                btnAgregar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnFilter_Click(sender, e);
            }
            catch (Exception exception)
            {
                MessageBox.Show("SELECCIONE UNA TRAMA A ELIMINAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnFilter_Click(sender, e);
            }
        }

        private void grService_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            btnAgregar.Enabled = true;
        }

        private void utcSusalud_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void grAmbulatorio_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void grEmergencia_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void grHospitalizacion_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void grProcedimientosCirugia_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void grPartos_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnExportarServicios_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "";
            NombreArchivo = "Reporte Servicios desde " + dtpDateTimeStar.Text + " al " + dptDateTimeEnd.Text + " - Tramas";
            NombreArchivo = NombreArchivo.Replace("/", "_");
            NombreArchivo = NombreArchivo.Replace(":", "_");

            saveFileDialog1.FileName = NombreArchivo;
            saveFileDialog1.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter1.Export(this.grService, saveFileDialog1.FileName);
                MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void ultraGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();

            try
            {
                var list = ListServiciosTramas.FindAll(p => p.CIE_10 == "NA" && p.Value1 != "-");
                foreach (var item in list)
                {

                    DateTime parsedDate = item.fechaservicio.Value;

                    int parse_edad = item.edad.Value;
                    int grupoEt = -1;
                    if (parse_edad < 1) { grupoEt = 1; }
                    else if (parse_edad >= 1 && parse_edad <= 4) { grupoEt = 2; }
                    else if (parse_edad >= 5 && parse_edad <= 9) { grupoEt = 3; }
                    else if (parse_edad >= 10 && parse_edad <= 14) { grupoEt = 4; }
                    else if (parse_edad >= 15 && parse_edad <= 19) { grupoEt = 5; }
                    else if (parse_edad >= 20 && parse_edad <= 24) { grupoEt = 6; }
                    else if (parse_edad >= 25 && parse_edad <= 29) { grupoEt = 7; }
                    else if (parse_edad >= 30 && parse_edad <= 34) { grupoEt = 8; }
                    else if (parse_edad >= 35 && parse_edad <= 39) { grupoEt = 9; }
                    else if (parse_edad >= 40 && parse_edad <= 44) { grupoEt = 10; }
                    else if (parse_edad >= 45 && parse_edad <= 49) { grupoEt = 11; }
                    else if (parse_edad >= 50 && parse_edad <= 54) { grupoEt = 12; }
                    else if (parse_edad >= 55 && parse_edad <= 59) { grupoEt = 13; }
                    else if (parse_edad >= 60 && parse_edad <= 64) { grupoEt = 14; }
                    else if (parse_edad >= 65) { grupoEt = 15; }

                    tramasDto _tramaDto = new tramasDto();

                    _tramaDto.v_TipoRegistro = "Ambulatorio";
                    _tramaDto.d_FechaIngreso = parsedDate;
                    _tramaDto.i_Genero = item.genero == "M" ? 1 : 2;
                    _tramaDto.i_GrupoEtario = grupoEt;
                    _tramaDto.v_DiseasesName = item.Value2;
                    _tramaDto.v_CIE10Id = item.Value1;
                    _tramaDto.v_ServiceId = item.v_ServiceId;
                    _tramaDto.v_DiagnosticRepositoryId = item.Value3;

                    string idTrama = _objTramasBL.AddTramas(ref objOperationResult, _tramaDto, Globals.ClientSession.GetAsList());
                    _objTramasBL.ActualizarDxRepositoryTrama(1, item.Value3, idTrama);
                }

                MessageBox.Show("Registro Exitoso de " + list.Count() + " servicios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("REVISE LOS REGISTROS A GUARDAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
            }
        }

        private void btnExportProcedimientos_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "";
            NombreArchivo = "Reporte Datos Procedimientos del " + dtpDateTimeStar.Text + " al " + dptDateTimeEnd.Text + "-tramas";
            NombreArchivo = NombreArchivo.Replace("/", "_");
            NombreArchivo = NombreArchivo.Replace(":", "_");

            saveFileDialog1.FileName = NombreArchivo;
            saveFileDialog1.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter1.Export(this.grProcedimientos, saveFileDialog1.FileName);
                MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grService_InitializeRow_1(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            //i_TramaCargada
            var banda = e.Row.Band.Index.ToString();
            var row = e.Row;
            if (banda == "0")
            {
                if (row.Band.Index.ToString() == "0")
                {
                    string tabName = utcSusalud.SelectedTab.Text;

                    if (tabName == "Ambulatorio" || tabName == "Procedimientos")
                    {

                        if (e.Row.Cells["i_TramaCargadaProc"].Value.ToString() == "1" && e.Row.Cells["v_TramaId"].Value.ToString() != "-")
                        {
                            e.Row.Appearance.BackColor = Color.Yellow;
                            e.Row.Appearance.BackColor2 = Color.White;
                            //Y doy el efecto degradado vertical
                            e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                        }
                        else if (e.Row.Cells["i_TramaCargada"].Value.ToString() == "1" && e.Row.Cells["Value1"].Value.ToString() != "HOSP"
                                                                                  && e.Row.Cells["Value1"].Value.ToString() != "SOP"
                                                                                  && e.Row.Cells["Value1"].Value.ToString() != "SOP_NO")
                        {
                            e.Row.Appearance.BackColor = Color.Yellow;
                            e.Row.Appearance.BackColor2 = Color.White;
                            //Y doy el efecto degradado vertical
                            e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                        }
                        else if (e.Row.Cells["TramaHosp"].Value.ToString() == "1" && e.Row.Cells["Value1"].Value.ToString() == "HOSP")
                        {
                            e.Row.Appearance.BackColor = Color.LightBlue;
                            e.Row.Appearance.BackColor2 = Color.White;
                            //Y doy el efecto degradado vertical
                            e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                        }
                        else if (e.Row.Cells["TramaSop"].Value.ToString() == "1" && e.Row.Cells["Value1"].Value.ToString() == "SOP")
                        {
                            e.Row.Appearance.BackColor = Color.GreenYellow;
                            e.Row.Appearance.BackColor2 = Color.White;
                            //Y doy el efecto degradado vertical
                            e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                        }
                        else if (e.Row.Cells["i_TramaCargada"].Value.ToString() == "1" && e.Row.Cells["Value1"].Value.ToString() == "SOP_NO")
                        {
                            e.Row.Appearance.BackColor = Color.LightYellow;
                            e.Row.Appearance.BackColor2 = Color.White;
                            //Y doy el efecto degradado vertical
                            e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                        }
                        //else if (e.Row.Cells["i_TramaCargada"].Value.ToString() == ((int)ServiceStatus.Culminado).ToString())
                        //{
                        //    e.Row.Appearance.BackColor = Color.GreenYellow;
                        //    e.Row.Appearance.BackColor2 = Color.White;
                        //    //Y doy el efecto degradado vertical
                        //    e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                        //}

                    }
                    if (e.Row.Cells["i_TramaCargada"].Value == null || e.Row.Cells["TramaHosp"].Value == null || e.Row.Cells["TramaSop"].Value == null)
                        return;

                }
            }
        }
        
    }
}
