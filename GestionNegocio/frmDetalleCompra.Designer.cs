namespace GestionNegocio
{
    partial class frmDetalleCompra
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
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblNroDocumento = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtTipoDoc = new System.Windows.Forms.TextBox();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.gpbInfoCompra = new System.Windows.Forms.GroupBox();
            this.gpbProveedor = new System.Windows.Forms.GroupBox();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDocProveedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.dgvDetalleCompra = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.btnDescargarPDF = new System.Windows.Forms.Button();
            this.lblContenedor = new System.Windows.Forms.Label();
            this.gpbInfoCompra.SuspendLayout();
            this.gpbProveedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(570, 55);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtDocumento.TabIndex = 1;
            // 
            // lblNroDocumento
            // 
            this.lblNroDocumento.AutoSize = true;
            this.lblNroDocumento.BackColor = System.Drawing.Color.White;
            this.lblNroDocumento.Location = new System.Drawing.Point(446, 58);
            this.lblNroDocumento.Name = "lblNroDocumento";
            this.lblNroDocumento.Size = new System.Drawing.Size(118, 13);
            this.lblNroDocumento.TabIndex = 2;
            this.lblNroDocumento.Text = "Numero de documento:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::GestionNegocio.Properties.Resources.eraser;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(757, 52);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::GestionNegocio.Properties.Resources.search_big;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(676, 52);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(6, 23);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha:";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(9, 39);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(164, 20);
            this.txtFecha.TabIndex = 5;
            // 
            // txtTipoDoc
            // 
            this.txtTipoDoc.Location = new System.Drawing.Point(197, 39);
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.Size = new System.Drawing.Size(209, 20);
            this.txtTipoDoc.TabIndex = 3;
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.BackColor = System.Drawing.Color.White;
            this.lblTipoDoc.Location = new System.Drawing.Point(194, 23);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(89, 13);
            this.lblTipoDoc.TabIndex = 4;
            this.lblTipoDoc.Text = "Tipo Documento:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(426, 39);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(192, 20);
            this.txtUsuario.TabIndex = 7;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(423, 23);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 8;
            this.lblUsuario.Text = "Usuario:";
            // 
            // gpbInfoCompra
            // 
            this.gpbInfoCompra.BackColor = System.Drawing.Color.White;
            this.gpbInfoCompra.Controls.Add(this.lblUsuario);
            this.gpbInfoCompra.Controls.Add(this.txtUsuario);
            this.gpbInfoCompra.Controls.Add(this.lblFecha);
            this.gpbInfoCompra.Controls.Add(this.txtFecha);
            this.gpbInfoCompra.Controls.Add(this.lblTipoDoc);
            this.gpbInfoCompra.Controls.Add(this.txtTipoDoc);
            this.gpbInfoCompra.Location = new System.Drawing.Point(196, 81);
            this.gpbInfoCompra.Name = "gpbInfoCompra";
            this.gpbInfoCompra.Size = new System.Drawing.Size(636, 77);
            this.gpbInfoCompra.TabIndex = 4;
            this.gpbInfoCompra.TabStop = false;
            this.gpbInfoCompra.Text = "Información compra:";
            // 
            // gpbProveedor
            // 
            this.gpbProveedor.BackColor = System.Drawing.Color.White;
            this.gpbProveedor.Controls.Add(this.txtNroDoc);
            this.gpbProveedor.Controls.Add(this.label3);
            this.gpbProveedor.Controls.Add(this.txtDocProveedor);
            this.gpbProveedor.Controls.Add(this.label4);
            this.gpbProveedor.Controls.Add(this.txtRazonSocial);
            this.gpbProveedor.Location = new System.Drawing.Point(196, 164);
            this.gpbProveedor.Name = "gpbProveedor";
            this.gpbProveedor.Size = new System.Drawing.Size(636, 77);
            this.gpbProveedor.TabIndex = 5;
            this.gpbProveedor.TabStop = false;
            this.gpbProveedor.Text = "Información proveedor:";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(561, 39);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(57, 20);
            this.txtNroDoc.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Numero Documento:";
            // 
            // txtDocProveedor
            // 
            this.txtDocProveedor.Location = new System.Drawing.Point(9, 39);
            this.txtDocProveedor.Name = "txtDocProveedor";
            this.txtDocProveedor.Size = new System.Drawing.Size(164, 20);
            this.txtDocProveedor.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(194, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Razon Social:";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(197, 39);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(209, 20);
            this.txtRazonSocial.TabIndex = 3;
            // 
            // dgvDetalleCompra
            // 
            this.dgvDetalleCompra.AllowUserToAddRows = false;
            this.dgvDetalleCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.PrecioCompra,
            this.Cantidad,
            this.SubTotal});
            this.dgvDetalleCompra.Location = new System.Drawing.Point(196, 247);
            this.dgvDetalleCompra.Name = "dgvDetalleCompra";
            this.dgvDetalleCompra.Size = new System.Drawing.Size(636, 239);
            this.dgvDetalleCompra.TabIndex = 6;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.Width = 200;
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.HeaderText = "PrecioCompra";
            this.PrecioCompra.Name = "PrecioCompra";
            this.PrecioCompra.Width = 150;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.Width = 150;
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Location = new System.Drawing.Point(266, 492);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.Size = new System.Drawing.Size(159, 20);
            this.txtMontoTotal.TabIndex = 7;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.BackColor = System.Drawing.Color.White;
            this.lblMontoTotal.Location = new System.Drawing.Point(193, 495);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(67, 13);
            this.lblMontoTotal.TabIndex = 8;
            this.lblMontoTotal.Text = "Monto Total:";
            // 
            // btnDescargarPDF
            // 
            this.btnDescargarPDF.Image = global::GestionNegocio.Properties.Resources.folder_down_arrow_24;
            this.btnDescargarPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDescargarPDF.Location = new System.Drawing.Point(700, 495);
            this.btnDescargarPDF.Name = "btnDescargarPDF";
            this.btnDescargarPDF.Size = new System.Drawing.Size(132, 23);
            this.btnDescargarPDF.TabIndex = 9;
            this.btnDescargarPDF.Text = "Descargar en PDF";
            this.btnDescargarPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDescargarPDF.UseVisualStyleBackColor = true;
            this.btnDescargarPDF.Click += new System.EventHandler(this.btnDescargarPDF_Click);
            // 
            // lblContenedor
            // 
            this.lblContenedor.BackColor = System.Drawing.Color.White;
            this.lblContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContenedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContenedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblContenedor.Location = new System.Drawing.Point(163, 9);
            this.lblContenedor.Name = "lblContenedor";
            this.lblContenedor.Size = new System.Drawing.Size(713, 517);
            this.lblContenedor.TabIndex = 0;
            this.lblContenedor.Text = "Detalle Compra";
            // 
            // frmDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(1055, 535);
            this.Controls.Add(this.btnDescargarPDF);
            this.Controls.Add(this.lblMontoTotal);
            this.Controls.Add(this.txtMontoTotal);
            this.Controls.Add(this.dgvDetalleCompra);
            this.Controls.Add(this.gpbProveedor);
            this.Controls.Add(this.gpbInfoCompra);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblNroDocumento);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.lblContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDetalleCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDetalleCompra";
            this.gpbInfoCompra.ResumeLayout(false);
            this.gpbInfoCompra.PerformLayout();
            this.gpbProveedor.ResumeLayout(false);
            this.gpbProveedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContenedor;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblNroDocumento;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtTipoDoc;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.GroupBox gpbInfoCompra;
        private System.Windows.Forms.GroupBox gpbProveedor;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDocProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.Button btnDescargarPDF;
        private System.Windows.Forms.DataGridView dgvDetalleCompra;
    }
}