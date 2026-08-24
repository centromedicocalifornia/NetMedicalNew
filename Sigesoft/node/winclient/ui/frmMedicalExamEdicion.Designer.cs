namespace Sigesoft.Node.WinClient.UI
{
    partial class frmMedicalExamEdicion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicalExamEdicion));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.Nombre = new System.Windows.Forms.Label();
            this.txtInsertName = new System.Windows.Forms.TextBox();
            this.uvMedicalExamEdit = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.ddlCategoryId = new ComboTreeBox();
            this.ddlDiagnosableId = new System.Windows.Forms.ComboBox();
            this.ddlComponentTypeId = new System.Windows.Forms.ComboBox();
            this.ddlUIIsVisibleId = new System.Windows.Forms.ComboBox();
            this.ddlIsApprovedId = new System.Windows.Forms.ComboBox();
            this.unBasePrice = new System.Windows.Forms.TextBox();
            this.ddlKindOfService = new System.Windows.Forms.ComboBox();
            this.cbRecargable = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAgregarLinea = new System.Windows.Forms.Button();
            this.btnAgregarLineaSAM = new System.Windows.Forms.Button();
            this.txtTarifaSegus = new System.Windows.Forms.TextBox();
            this.txtCodigoSegus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlUnidadProductiva = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.unUIIndex = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.unValidInDays = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.rbDeduciblePay = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.txtProcedId = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbProcedimiento = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uvMedicalExamEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unUIIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unValidInDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProcedimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(65, 24);
            this.Nombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(44, 13);
            this.Nombre.TabIndex = 0;
            this.Nombre.Text = "Nombre";
            // 
            // txtInsertName
            // 
            this.txtInsertName.Location = new System.Drawing.Point(111, 21);
            this.txtInsertName.Margin = new System.Windows.Forms.Padding(2);
            this.txtInsertName.MaxLength = 250;
            this.txtInsertName.Name = "txtInsertName";
            this.txtInsertName.Size = new System.Drawing.Size(554, 20);
            this.txtInsertName.TabIndex = 1;
            this.uvMedicalExamEdit.GetValidationSettings(this.txtInsertName).DataType = typeof(string);
            this.uvMedicalExamEdit.GetValidationSettings(this.txtInsertName).EmptyValueCriteria = Infragistics.Win.Misc.EmptyValueCriteria.NullOrEmptyString;
            this.uvMedicalExamEdit.GetValidationSettings(this.txtInsertName).IsRequired = true;
            // 
            // uvMedicalExamEdit
            // 
            this.uvMedicalExamEdit.MessageBoxIcon = System.Windows.Forms.MessageBoxIcon.None;
            // 
            // ddlCategoryId
            // 
            this.ddlCategoryId.DropDownHeight = 500;
            this.ddlCategoryId.DroppedDown = false;
            this.ddlCategoryId.Location = new System.Drawing.Point(111, 45);
            this.ddlCategoryId.Margin = new System.Windows.Forms.Padding(2);
            this.ddlCategoryId.Name = "ddlCategoryId";
            this.ddlCategoryId.SelectedNode = null;
            this.ddlCategoryId.ShowPath = true;
            this.ddlCategoryId.Size = new System.Drawing.Size(451, 19);
            this.ddlCategoryId.TabIndex = 2;
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlCategoryId).DataType = typeof(string);
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlCategoryId).IsRequired = true;
            this.ddlCategoryId.SelectedNodeChanged += new System.EventHandler(this.ddlCategoryId_SelectedNodeChanged);
            // 
            // ddlDiagnosableId
            // 
            this.ddlDiagnosableId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDiagnosableId.DropDownWidth = 300;
            this.ddlDiagnosableId.FormattingEnabled = true;
            this.ddlDiagnosableId.Location = new System.Drawing.Point(111, 124);
            this.ddlDiagnosableId.Margin = new System.Windows.Forms.Padding(2);
            this.ddlDiagnosableId.Name = "ddlDiagnosableId";
            this.ddlDiagnosableId.Size = new System.Drawing.Size(251, 21);
            this.ddlDiagnosableId.TabIndex = 3;
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlDiagnosableId).Condition = new Infragistics.Win.OperatorCondition(Infragistics.Win.ConditionOperator.NotEquals, "--Seleccionar--", true, typeof(string));
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlDiagnosableId).DataType = typeof(string);
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlDiagnosableId).EmptyValueCriteria = Infragistics.Win.Misc.EmptyValueCriteria.NullOrEmptyString;
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlDiagnosableId).IsRequired = true;
            // 
            // ddlComponentTypeId
            // 
            this.ddlComponentTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlComponentTypeId.DropDownWidth = 300;
            this.ddlComponentTypeId.FormattingEnabled = true;
            this.ddlComponentTypeId.Location = new System.Drawing.Point(111, 150);
            this.ddlComponentTypeId.Margin = new System.Windows.Forms.Padding(2);
            this.ddlComponentTypeId.Name = "ddlComponentTypeId";
            this.ddlComponentTypeId.Size = new System.Drawing.Size(554, 21);
            this.ddlComponentTypeId.TabIndex = 5;
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlComponentTypeId).Condition = new Infragistics.Win.OperatorCondition(Infragistics.Win.ConditionOperator.NotEquals, "--Seleccionar--", true, typeof(string));
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlComponentTypeId).DataType = typeof(string);
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlComponentTypeId).EmptyValueCriteria = Infragistics.Win.Misc.EmptyValueCriteria.NullOrEmptyString;
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlComponentTypeId).IsRequired = true;
            // 
            // ddlUIIsVisibleId
            // 
            this.ddlUIIsVisibleId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUIIsVisibleId.DropDownWidth = 300;
            this.ddlUIIsVisibleId.FormattingEnabled = true;
            this.ddlUIIsVisibleId.Location = new System.Drawing.Point(111, 176);
            this.ddlUIIsVisibleId.Margin = new System.Windows.Forms.Padding(2);
            this.ddlUIIsVisibleId.Name = "ddlUIIsVisibleId";
            this.ddlUIIsVisibleId.Size = new System.Drawing.Size(251, 21);
            this.ddlUIIsVisibleId.TabIndex = 6;
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlUIIsVisibleId).Condition = new Infragistics.Win.OperatorCondition(Infragistics.Win.ConditionOperator.NotEquals, "--Seleccionar--", true, typeof(string));
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlUIIsVisibleId).DataType = typeof(string);
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlUIIsVisibleId).EmptyValueCriteria = Infragistics.Win.Misc.EmptyValueCriteria.NullOrEmptyString;
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlUIIsVisibleId).IsRequired = true;
            // 
            // ddlIsApprovedId
            // 
            this.ddlIsApprovedId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlIsApprovedId.DropDownWidth = 300;
            this.ddlIsApprovedId.FormattingEnabled = true;
            this.ddlIsApprovedId.Location = new System.Drawing.Point(111, 202);
            this.ddlIsApprovedId.Margin = new System.Windows.Forms.Padding(2);
            this.ddlIsApprovedId.Name = "ddlIsApprovedId";
            this.ddlIsApprovedId.Size = new System.Drawing.Size(251, 21);
            this.ddlIsApprovedId.TabIndex = 8;
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlIsApprovedId).Condition = new Infragistics.Win.OperatorCondition(Infragistics.Win.ConditionOperator.NotEquals, "--Seleccionar--", true, typeof(string));
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlIsApprovedId).DataType = typeof(string);
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlIsApprovedId).EmptyValueCriteria = Infragistics.Win.Misc.EmptyValueCriteria.NullOrEmptyString;
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlIsApprovedId).IsRequired = true;
            // 
            // unBasePrice
            // 
            this.unBasePrice.Location = new System.Drawing.Point(487, 123);
            this.unBasePrice.Margin = new System.Windows.Forms.Padding(2);
            this.unBasePrice.Name = "unBasePrice";
            this.unBasePrice.Size = new System.Drawing.Size(178, 20);
            this.unBasePrice.TabIndex = 4;
            this.uvMedicalExamEdit.GetValidationSettings(this.unBasePrice).DataType = typeof(string);
            this.uvMedicalExamEdit.GetValidationSettings(this.unBasePrice).EmptyValueCriteria = Infragistics.Win.Misc.EmptyValueCriteria.NullOrEmptyString;
            this.uvMedicalExamEdit.GetValidationSettings(this.unBasePrice).IsRequired = true;
            this.unBasePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.unBasePrice_KeyPress);
            // 
            // ddlKindOfService
            // 
            this.ddlKindOfService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlKindOfService.DropDownWidth = 300;
            this.ddlKindOfService.FormattingEnabled = true;
            this.ddlKindOfService.Location = new System.Drawing.Point(111, 98);
            this.ddlKindOfService.Margin = new System.Windows.Forms.Padding(2);
            this.ddlKindOfService.Name = "ddlKindOfService";
            this.ddlKindOfService.Size = new System.Drawing.Size(554, 21);
            this.ddlKindOfService.TabIndex = 63;
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlKindOfService).Condition = new Infragistics.Win.OperatorCondition(Infragistics.Win.ConditionOperator.NotEquals, "--Seleccionar--", true, typeof(string));
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlKindOfService).DataType = typeof(string);
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlKindOfService).EmptyValueCriteria = Infragistics.Win.Misc.EmptyValueCriteria.NullOrEmptyString;
            this.uvMedicalExamEdit.GetValidationSettings(this.ddlKindOfService).IsRequired = true;
            // 
            // cbRecargable
            // 
            this.cbRecargable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecargable.DropDownWidth = 300;
            this.cbRecargable.FormattingEnabled = true;
            this.cbRecargable.Location = new System.Drawing.Point(111, 70);
            this.cbRecargable.Margin = new System.Windows.Forms.Padding(2);
            this.cbRecargable.Name = "cbRecargable";
            this.cbRecargable.Size = new System.Drawing.Size(554, 21);
            this.cbRecargable.TabIndex = 65;
            this.uvMedicalExamEdit.GetValidationSettings(this.cbRecargable).Condition = new Infragistics.Win.OperatorCondition(Infragistics.Win.ConditionOperator.NotEquals, "--Seleccionar--", true, typeof(string));
            this.uvMedicalExamEdit.GetValidationSettings(this.cbRecargable).DataType = typeof(string);
            this.uvMedicalExamEdit.GetValidationSettings(this.cbRecargable).EmptyValueCriteria = Infragistics.Win.Misc.EmptyValueCriteria.NullOrEmptyString;
            this.uvMedicalExamEdit.GetValidationSettings(this.cbRecargable).IsRequired = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.DropDownWidth = 300;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(124, 166);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(108, 21);
            this.comboBox1.TabIndex = 24;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(487, 357);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Salir";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(590, 357);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "Guardar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAgregarLinea
            // 
            this.btnAgregarLinea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregarLinea.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgregarLinea.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAgregarLinea.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAgregarLinea.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgregarLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarLinea.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarLinea.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarLinea.Image")));
            this.btnAgregarLinea.Location = new System.Drawing.Point(638, 250);
            this.btnAgregarLinea.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarLinea.Name = "btnAgregarLinea";
            this.btnAgregarLinea.Size = new System.Drawing.Size(27, 21);
            this.btnAgregarLinea.TabIndex = 62;
            this.btnAgregarLinea.UseVisualStyleBackColor = false;
            this.btnAgregarLinea.Click += new System.EventHandler(this.btnAgregarLinea_Click);
            // 
            // btnAgregarLineaSAM
            // 
            this.btnAgregarLineaSAM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregarLineaSAM.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgregarLineaSAM.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgregarLineaSAM.FlatAppearance.BorderSize = 0;
            this.btnAgregarLineaSAM.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAgregarLineaSAM.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgregarLineaSAM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarLineaSAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarLineaSAM.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarLineaSAM.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarLineaSAM.Image")));
            this.btnAgregarLineaSAM.Location = new System.Drawing.Point(320, 173);
            this.btnAgregarLineaSAM.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarLineaSAM.Name = "btnAgregarLineaSAM";
            this.btnAgregarLineaSAM.Size = new System.Drawing.Size(27, 21);
            this.btnAgregarLineaSAM.TabIndex = 62;
            this.btnAgregarLineaSAM.UseVisualStyleBackColor = false;
            // 
            // txtTarifaSegus
            // 
            this.txtTarifaSegus.Location = new System.Drawing.Point(488, 227);
            this.txtTarifaSegus.Margin = new System.Windows.Forms.Padding(2);
            this.txtTarifaSegus.MaxLength = 250;
            this.txtTarifaSegus.Name = "txtTarifaSegus";
            this.txtTarifaSegus.Size = new System.Drawing.Size(177, 20);
            this.txtTarifaSegus.TabIndex = 11;
            // 
            // txtCodigoSegus
            // 
            this.txtCodigoSegus.Location = new System.Drawing.Point(112, 227);
            this.txtCodigoSegus.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoSegus.MaxLength = 250;
            this.txtCodigoSegus.Name = "txtCodigoSegus";
            this.txtCodigoSegus.Size = new System.Drawing.Size(250, 20);
            this.txtCodigoSegus.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Categoría";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Precio Base";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Diagnosticable";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(416, 230);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Tarifa Segus";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 230);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Código Segus";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 156);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Tipo Componente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 254);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Unidad Productiva";
            // 
            // ddlUnidadProductiva
            // 
            this.ddlUnidadProductiva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUnidadProductiva.DropDownWidth = 300;
            this.ddlUnidadProductiva.FormattingEnabled = true;
            this.ddlUnidadProductiva.Location = new System.Drawing.Point(111, 250);
            this.ddlUnidadProductiva.Margin = new System.Windows.Forms.Padding(2);
            this.ddlUnidadProductiva.Name = "ddlUnidadProductiva";
            this.ddlUnidadProductiva.Size = new System.Drawing.Size(514, 21);
            this.ddlUnidadProductiva.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 182);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Es Visible";
            // 
            // unUIIndex
            // 
            this.unUIIndex.AutoSize = false;
            this.unUIIndex.Enabled = false;
            this.unUIIndex.Location = new System.Drawing.Point(488, 178);
            this.unUIIndex.Margin = new System.Windows.Forms.Padding(2);
            this.unUIIndex.MaxValue = 9999;
            this.unUIIndex.Name = "unUIIndex";
            this.unUIIndex.PromptChar = ' ';
            this.unUIIndex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.unUIIndex.Size = new System.Drawing.Size(177, 20);
            this.unUIIndex.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(427, 178);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Nro Orden";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 208);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Aprobación";
            // 
            // unValidInDays
            // 
            this.unValidInDays.AutoSize = false;
            this.unValidInDays.Location = new System.Drawing.Point(488, 203);
            this.unValidInDays.Margin = new System.Windows.Forms.Padding(2);
            this.unValidInDays.MaxValue = 9999;
            this.unValidInDays.Name = "unValidInDays";
            this.unValidInDays.PromptChar = ' ';
            this.unValidInDays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.unValidInDays.Size = new System.Drawing.Size(177, 20);
            this.unValidInDays.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(410, 202);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Vigencia(dias)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 104);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 64;
            this.label12.Text = "Clase de Servicio";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 74);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 66;
            this.label13.Text = "Recargable";
            // 
            // rbDeduciblePay
            // 
            this.rbDeduciblePay.AutoSize = true;
            this.rbDeduciblePay.Location = new System.Drawing.Point(651, 48);
            this.rbDeduciblePay.Name = "rbDeduciblePay";
            this.rbDeduciblePay.Size = new System.Drawing.Size(14, 13);
            this.rbDeduciblePay.TabIndex = 67;
            this.rbDeduciblePay.TabStop = true;
            this.rbDeduciblePay.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.Location = new System.Drawing.Point(568, 48);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 68;
            this.label14.Text = "¿Deducible?";
            // 
            // txtProcedId
            // 
            this.txtProcedId.Enabled = false;
            this.txtProcedId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcedId.Location = new System.Drawing.Point(111, 304);
            this.txtProcedId.Name = "txtProcedId";
            this.txtProcedId.Size = new System.Drawing.Size(121, 20);
            this.txtProcedId.TabIndex = 127;
            this.txtProcedId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(54, 307);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 126;
            this.label16.Text = "CPMS ID";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(108, 283);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 128;
            this.label15.Text = "CPMS";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // cbProcedimiento
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbProcedimiento.DisplayLayout.Appearance = appearance1;
            this.cbProcedimiento.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cbProcedimiento.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.cbProcedimiento.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbProcedimiento.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.cbProcedimiento.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbProcedimiento.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbProcedimiento.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cbProcedimiento.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.cbProcedimiento.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.cbProcedimiento.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cbProcedimiento.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.cbProcedimiento.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cbProcedimiento.DisplayLayout.Override.CellAppearance = appearance8;
            this.cbProcedimiento.DisplayLayout.Override.CellPadding = 0;
            this.cbProcedimiento.DisplayLayout.Override.ColumnSizingArea = Infragistics.Win.UltraWinGrid.ColumnSizingArea.EntireColumn;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.cbProcedimiento.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.cbProcedimiento.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.cbProcedimiento.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.cbProcedimiento.DisplayLayout.Override.RowAppearance = appearance11;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cbProcedimiento.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.cbProcedimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProcedimiento.Location = new System.Drawing.Point(109, 330);
            this.cbProcedimiento.Name = "cbProcedimiento";
            this.cbProcedimiento.Size = new System.Drawing.Size(556, 22);
            this.cbProcedimiento.TabIndex = 130;
            this.cbProcedimiento.RowSelected += new Infragistics.Win.UltraWinGrid.RowSelectedEventHandler(this.cbProcedimiento_RowSelected);
            this.cbProcedimiento.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbProcedimiento_MouseDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(27, 334);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 13);
            this.label17.TabIndex = 129;
            this.label17.Text = "Procedimiento: ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMedicalExamEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(677, 385);
            this.ControlBox = false;
            this.Controls.Add(this.cbProcedimiento);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtProcedId);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.rbDeduciblePay);
            this.Controls.Add(this.cbRecargable);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ddlKindOfService);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnAgregarLinea);
            this.Controls.Add(this.unBasePrice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.unValidInDays);
            this.Controls.Add(this.ddlIsApprovedId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.unUIIndex);
            this.Controls.Add(this.ddlUIIsVisibleId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ddlUnidadProductiva);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlComponentTypeId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ddlDiagnosableId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlCategoryId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodigoSegus);
            this.Controls.Add(this.txtTarifaSegus);
            this.Controls.Add(this.txtInsertName);
            this.Controls.Add(this.Nombre);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMedicalExamEdicion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Examen Médico";
            this.Load += new System.EventHandler(this.frmMedicalExamEdicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uvMedicalExamEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unUIIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unValidInDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProcedimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.TextBox txtInsertName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private Infragistics.Win.Misc.UltraValidator uvMedicalExamEdit;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAgregarLinea;
        private System.Windows.Forms.Button btnAgregarLineaSAM;
        private System.Windows.Forms.TextBox txtTarifaSegus;
        private System.Windows.Forms.TextBox txtCodigoSegus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ddlDiagnosableId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlComponentTypeId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlUnidadProductiva;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlUIIsVisibleId;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor unUIIndex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ddlIsApprovedId;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor unValidInDays;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox unBasePrice;
        private ComboTreeBox ddlCategoryId;
        private System.Windows.Forms.ComboBox ddlKindOfService;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbRecargable;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rbDeduciblePay;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtProcedId;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbProcedimiento;
        private System.Windows.Forms.Label label17;
    }
}