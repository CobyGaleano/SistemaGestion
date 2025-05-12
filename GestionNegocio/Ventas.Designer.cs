namespace GestionNegocio
{
    partial class Ventas
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
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.lblEstadoCred = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblRecargo = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.cmbFormasPago = new System.Windows.Forms.ComboBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtDescuentoTotal = new System.Windows.Forms.TextBox();
            this.txtDesc1 = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.txtDesc3 = new System.Windows.Forms.TextBox();
            this.txtDesc2 = new System.Windows.Forms.TextBox();
            this.txtRecargo = new System.Windows.Forms.TextBox();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.txtRecargoTotal = new System.Windows.Forms.TextBox();
            this.txtImpuestos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtDirec = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEstadoCrediticio = new System.Windows.Forms.TextBox();
            this.lblIdDocumento = new System.Windows.Forms.Label();
            this.lblFechaActual = new System.Windows.Forms.Label();
            this.txtFechaActual = new System.Windows.Forms.TextBox();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvVentas.Location = new System.Drawing.Point(12, 64);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.Size = new System.Drawing.Size(1067, 345);
            this.dgvVentas.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 68.35938F;
            this.Column1.HeaderText = "CANTIDAD";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 80.73495F;
            this.Column2.HeaderText = "CODIGO";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 91.90199F;
            this.Column3.HeaderText = "DESCRIPCION";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 101.9785F;
            this.Column4.HeaderText = "MEDIDA";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 111.0709F;
            this.Column5.HeaderText = "DIVISA";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 119.2755F;
            this.Column6.HeaderText = "PRECIO";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 126.6788F;
            this.Column7.HeaderText = "TOTAL";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // lblCliente
            // 
            this.lblCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(20, 12);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(76, 5);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(234, 20);
            this.txtCliente.TabIndex = 2;
            // 
            // lblNumero
            // 
            this.lblNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.Location = new System.Drawing.Point(849, 4);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(32, 23);
            this.lblNumero.TabIndex = 3;
            this.lblNumero.Text = "Nº";
            // 
            // lblDireccion
            // 
            this.lblDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(17, 453);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 4;
            this.lblDireccion.Text = "Direccion";
            // 
            // lblTelefono
            // 
            this.lblTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(17, 481);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 5;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblMail
            // 
            this.lblMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(17, 425);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(36, 13);
            this.lblMail.TabIndex = 6;
            this.lblMail.Text = "E-Mail";
            // 
            // lblCuit
            // 
            this.lblCuit.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblCuit.AutoSize = true;
            this.lblCuit.Location = new System.Drawing.Point(20, 38);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(47, 13);
            this.lblCuit.TabIndex = 7;
            this.lblCuit.Text = "Cuit/Cuil";
            // 
            // lblEstadoCred
            // 
            this.lblEstadoCred.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblEstadoCred.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEstadoCred.AutoSize = true;
            this.lblEstadoCred.Location = new System.Drawing.Point(20, 510);
            this.lblEstadoCred.Name = "lblEstadoCred";
            this.lblEstadoCred.Size = new System.Drawing.Size(86, 13);
            this.lblEstadoCred.TabIndex = 8;
            this.lblEstadoCred.Text = "Estado Crediticio";
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(867, 41);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(43, 13);
            this.lblFecha.TabIndex = 10;
            this.lblFecha.Text = "Fecha: ";
            // 
            // lblDescuento
            // 
            this.lblDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(727, 453);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(59, 13);
            this.lblDescuento.TabIndex = 9;
            this.lblDescuento.Text = "Descuento";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(727, 425);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(46, 13);
            this.lblSubtotal.TabIndex = 11;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // lblRecargo
            // 
            this.lblRecargo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecargo.AutoSize = true;
            this.lblRecargo.Location = new System.Drawing.Point(727, 486);
            this.lblRecargo.Name = "lblRecargo";
            this.lblRecargo.Size = new System.Drawing.Size(48, 13);
            this.lblRecargo.TabIndex = 12;
            this.lblRecargo.Text = "Recargo";
            // 
            // lblIVA
            // 
            this.lblIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIVA.AutoSize = true;
            this.lblIVA.Location = new System.Drawing.Point(727, 517);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(24, 13);
            this.lblIVA.TabIndex = 13;
            this.lblIVA.Text = "IVA";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(727, 582);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(42, 13);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "TOTAL";
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Location = new System.Drawing.Point(383, 481);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(79, 13);
            this.lblFormaPago.TabIndex = 15;
            this.lblFormaPago.Text = "Forma de Pago";
            // 
            // lblVendedor
            // 
            this.lblVendedor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(383, 425);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(53, 13);
            this.lblVendedor.TabIndex = 16;
            this.lblVendedor.Text = "Vendedor";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(20, 540);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 55);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAceptar.Location = new System.Drawing.Point(386, 540);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(213, 55);
            this.btnAceptar.TabIndex = 18;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Items.AddRange(new object[] {
            "Cesar",
            "Sole",
            "Kira",
            "Jack ",
            "Gringo"});
            this.cmbVendedor.Location = new System.Drawing.Point(478, 422);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(121, 21);
            this.cmbVendedor.TabIndex = 19;
            // 
            // cmbFormasPago
            // 
            this.cmbFormasPago.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbFormasPago.FormattingEnabled = true;
            this.cmbFormasPago.Items.AddRange(new object[] {
            "Efectivo",
            "Mercado Pago",
            "T. Debito",
            "T. Credito",
            "Trasferencia",
            "QR"});
            this.cmbFormasPago.Location = new System.Drawing.Point(478, 478);
            this.cmbFormasPago.Name = "cmbFormasPago";
            this.cmbFormasPago.Size = new System.Drawing.Size(121, 21);
            this.cmbFormasPago.TabIndex = 20;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Location = new System.Drawing.Point(969, 579);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(76, 20);
            this.txtTotal.TabIndex = 21;
            // 
            // txtDescuentoTotal
            // 
            this.txtDescuentoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescuentoTotal.Location = new System.Drawing.Point(969, 451);
            this.txtDescuentoTotal.Name = "txtDescuentoTotal";
            this.txtDescuentoTotal.Size = new System.Drawing.Size(76, 20);
            this.txtDescuentoTotal.TabIndex = 22;
            // 
            // txtDesc1
            // 
            this.txtDesc1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc1.Location = new System.Drawing.Point(802, 450);
            this.txtDesc1.Name = "txtDesc1";
            this.txtDesc1.Size = new System.Drawing.Size(28, 20);
            this.txtDesc1.TabIndex = 23;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubtotal.Location = new System.Drawing.Point(969, 422);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(76, 20);
            this.txtSubtotal.TabIndex = 24;
            // 
            // txtDesc3
            // 
            this.txtDesc3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc3.Location = new System.Drawing.Point(903, 450);
            this.txtDesc3.Name = "txtDesc3";
            this.txtDesc3.Size = new System.Drawing.Size(28, 20);
            this.txtDesc3.TabIndex = 25;
            // 
            // txtDesc2
            // 
            this.txtDesc2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc2.Location = new System.Drawing.Point(853, 450);
            this.txtDesc2.Name = "txtDesc2";
            this.txtDesc2.Size = new System.Drawing.Size(28, 20);
            this.txtDesc2.TabIndex = 26;
            // 
            // txtRecargo
            // 
            this.txtRecargo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecargo.Location = new System.Drawing.Point(903, 483);
            this.txtRecargo.Name = "txtRecargo";
            this.txtRecargo.Size = new System.Drawing.Size(28, 20);
            this.txtRecargo.TabIndex = 27;
            // 
            // txtIVA
            // 
            this.txtIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIVA.Location = new System.Drawing.Point(903, 514);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(28, 20);
            this.txtIVA.TabIndex = 28;
            // 
            // txtRecargoTotal
            // 
            this.txtRecargoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecargoTotal.Location = new System.Drawing.Point(969, 483);
            this.txtRecargoTotal.Name = "txtRecargoTotal";
            this.txtRecargoTotal.Size = new System.Drawing.Size(76, 20);
            this.txtRecargoTotal.TabIndex = 29;
            // 
            // txtImpuestos
            // 
            this.txtImpuestos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImpuestos.Location = new System.Drawing.Point(969, 514);
            this.txtImpuestos.Name = "txtImpuestos";
            this.txtImpuestos.Size = new System.Drawing.Size(76, 20);
            this.txtImpuestos.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(937, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "%";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(937, 486);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "%";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(937, 517);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "%";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(887, 453);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "-";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(836, 454);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "-";
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(76, 35);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(133, 20);
            this.txtCuit.TabIndex = 36;
            // 
            // txtMail
            // 
            this.txtMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMail.Location = new System.Drawing.Point(140, 422);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(133, 20);
            this.txtMail.TabIndex = 37;
            // 
            // txtDirec
            // 
            this.txtDirec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDirec.Location = new System.Drawing.Point(140, 450);
            this.txtDirec.Name = "txtDirec";
            this.txtDirec.Size = new System.Drawing.Size(133, 20);
            this.txtDirec.TabIndex = 38;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTelefono.Location = new System.Drawing.Point(140, 478);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(133, 20);
            this.txtTelefono.TabIndex = 39;
            // 
            // txtEstadoCrediticio
            // 
            this.txtEstadoCrediticio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEstadoCrediticio.Location = new System.Drawing.Point(140, 507);
            this.txtEstadoCrediticio.Name = "txtEstadoCrediticio";
            this.txtEstadoCrediticio.Size = new System.Drawing.Size(133, 20);
            this.txtEstadoCrediticio.TabIndex = 40;
            // 
            // lblIdDocumento
            // 
            this.lblIdDocumento.AutoSize = true;
            this.lblIdDocumento.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdDocumento.Location = new System.Drawing.Point(983, 14);
            this.lblIdDocumento.Name = "lblIdDocumento";
            this.lblIdDocumento.Size = new System.Drawing.Size(0, 23);
            this.lblIdDocumento.TabIndex = 41;
            // 
            // lblFechaActual
            // 
            this.lblFechaActual.AutoSize = true;
            this.lblFechaActual.Location = new System.Drawing.Point(900, 48);
            this.lblFechaActual.Name = "lblFechaActual";
            this.lblFechaActual.Size = new System.Drawing.Size(10, 13);
            this.lblFechaActual.TabIndex = 42;
            this.lblFechaActual.Text = " ";
            // 
            // txtFechaActual
            // 
            this.txtFechaActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFechaActual.Location = new System.Drawing.Point(916, 38);
            this.txtFechaActual.Name = "txtFechaActual";
            this.txtFechaActual.Size = new System.Drawing.Size(82, 20);
            this.txtFechaActual.TabIndex = 43;
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Items.AddRange(new object[] {
            "Cesar",
            "Sole",
            "Kira",
            "Jack ",
            "Gringo"});
            this.cmbTipoDocumento.Location = new System.Drawing.Point(722, 4);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoDocumento.TabIndex = 44;
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(1100, 615);
            this.Controls.Add(this.cmbTipoDocumento);
            this.Controls.Add(this.txtFechaActual);
            this.Controls.Add(this.lblFechaActual);
            this.Controls.Add(this.lblIdDocumento);
            this.Controls.Add(this.txtEstadoCrediticio);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDirec);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtImpuestos);
            this.Controls.Add(this.txtRecargoTotal);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.txtRecargo);
            this.Controls.Add(this.txtDesc2);
            this.Controls.Add(this.txtDesc3);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.txtDesc1);
            this.Controls.Add(this.txtDescuentoTotal);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.cmbFormasPago);
            this.Controls.Add(this.cmbVendedor);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.lblRecargo);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.lblEstadoCred);
            this.Controls.Add(this.lblCuit);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.dgvVentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Ventas";
            this.Text = "Ventas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lblEstadoCred;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblRecargo;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cmbVendedor;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtDescuentoTotal;
        private System.Windows.Forms.TextBox txtDesc1;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.TextBox txtDesc3;
        private System.Windows.Forms.TextBox txtDesc2;
        private System.Windows.Forms.TextBox txtRecargo;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.TextBox txtRecargoTotal;
        private System.Windows.Forms.TextBox txtImpuestos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtDirec;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEstadoCrediticio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.ComboBox cmbFormasPago;
        private System.Windows.Forms.Label lblIdDocumento;
        private System.Windows.Forms.Label lblFechaActual;
        private System.Windows.Forms.TextBox txtFechaActual;
        private System.Windows.Forms.ComboBox cmbTipoDocumento;
    }
}