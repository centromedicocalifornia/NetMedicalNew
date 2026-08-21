using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sigesoft.Node.WinClient.BLL;
using Sigesoft.Common;

namespace Sigesoft.Node.WinClient.UI
{
    public partial class frmCalendar_Update_Service_Date : Form
    {
        private string _serviceId;

        public frmCalendar_Update_Service_Date(string serviceId, DateTime? pdatServiceDate)
        {
            InitializeComponent();
            _serviceId = serviceId;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm tt";
            
            if (pdatServiceDate.HasValue)
            {
                dateTimePicker1.Value = pdatServiceDate.Value;
            }
            else
            {
                dateTimePicker1.Value = DateTime.Now;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            ServiceBL oServiceBL = new ServiceBL();

            oServiceBL.UpdateServiceDate(ref objOperationResult, _serviceId, dateTimePicker1.Value, Globals.ClientSession.GetAsList());

            if (objOperationResult.Success == 1)
            {
                MessageBox.Show("Se actualizó correctamente.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                 MessageBox.Show(objOperationResult.ExceptionMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
