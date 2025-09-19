namespace GestionNegocio
{
    partial class frmDetalleVentas
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
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.lblDocumentoCliente = new System.Windows.Forms.Label();
            this.txtDocCliente = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.gpbInfoCompra = new System.Windows.Forms.GroupBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.txtTipoDoc = new System.Windows.Forms.TextBox();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblNroDocumento = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.btnDescargarPDF = new System.Windows.Forms.Button();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.gpbCliente = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblContenedor = new System.Windows.Forms.Label();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbInfoCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.gpbCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(561, 39);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(57, 20);
            this.txtNroDoc.TabIndex = 8;
            // 
            // lblDocumentoCliente
            // 
            this.lblDocumentoCliente.AutoSize = true;
            this.lblDocumentoCliente.BackColor = System.Drawing.Color.White;
            this.lblDocumentoCliente.Location = new System.Drawing.Point(6, 23);
            this.lblDocumentoCliente.Name = "lblDocumentoCliente";
            this.lblDocumentoCliente.Size = new System.Drawing.Size(105, 13);
            this.lblDocumentoCliente.TabIndex = 6;
            this.lblDocumentoCliente.Text = "Numero Documento:";
            // 
            // txtDocCliente
            // 
            this.txtDocCliente.Location = new System.Drawing.Point(9, 39);
            this.txtDocCliente.Name = "txtDocCliente";
            this.txtDocCliente.Size = new System.Drawing.Size(164, 20);
            this.txtDocCliente.TabIndex = 5;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(197, 39);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(209, 20);
            this.txtNombreCliente.TabIndex = 3;
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
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(426, 39);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(192, 20);
            this.txtUsuario.TabIndex = 7;
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
            this.gpbInfoCompra.Location = new System.Drawing.Point(196, 82);
            this.gpbInfoCompra.Name = "gpbInfoCompra";
            this.gpbInfoCompra.Size = new System.Drawing.Size(636, 77);
            this.gpbInfoCompra.TabIndex = 26;
            this.gpbInfoCompra.TabStop = false;
            this.gpbInfoCompra.Text = "Información compra:";
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
            // txtTipoDoc
            // 
            this.txtTipoDoc.Location = new System.Drawing.Point(197, 39);
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.Size = new System.Drawing.Size(209, 20);
            this.txtTipoDoc.TabIndex = 3;
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.BackColor = System.Drawing.Color.White;
            this.lblNombreCompleto.Location = new System.Drawing.Point(194, 23);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(92, 13);
            this.lblNombreCompleto.TabIndex = 4;
            this.lblNombreCompleto.Text = "Nombre Competo:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::GestionNegocio.Properties.Resources.search_big;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(676, 53);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 24;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblNroDocumento
            // 
            this.lblNroDocumento.AutoSize = true;
            this.lblNroDocumento.BackColor = System.Drawing.Color.White;
            this.lblNroDocumento.Location = new System.Drawing.Point(446, 59);
            this.lblNroDocumento.Name = "lblNroDocumento";
            this.lblNroDocumento.Size = new System.Drawing.Size(118, 13);
            this.lblNroDocumento.TabIndex = 23;
            this.lblNroDocumento.Text = "Numero de documento:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(570, 56);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtDocumento.TabIndex = 22;
            // 
            // btnDescargarPDF
            // 
            this.btnDescargarPDF.Image = global::GestionNegocio.Properties.Resources.folder_down_arrow_24;
            this.btnDescargarPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDescargarPDF.Location = new System.Drawing.Point(700, 496);
            this.btnDescargarPDF.Name = "btnDescargarPDF";
            this.btnDescargarPDF.Size = new System.Drawing.Size(132, 23);
            this.btnDescargarPDF.TabIndex = 31;
            this.btnDescargarPDF.Text = "Descargar en PDF";
            this.btnDescargarPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDescargarPDF.UseVisualStyleBackColor = true;
            this.btnDescargarPDF.Click += new System.EventHandler(this.btnDescargarPDF_Click);
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.BackColor = System.Drawing.Color.White;
            this.lblMontoTotal.Location = new System.Drawing.Point(193, 496);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(67, 13);
            this.lblMontoTotal.TabIndex = 30;
            this.lblMontoTotal.Text = "Monto Total:";
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Location = new System.Drawing.Point(266, 493);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.Size = new System.Drawing.Size(159, 20);
            this.txtMontoTotal.TabIndex = 29;
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AllowUserToAddRows = false;
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.PrecioVenta,
            this.Stock,
            this.Cantidad,
            this.SubTotal});
            this.dgvDetalleVenta.Location = new System.Drawing.Point(196, 248);
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.Size = new System.Drawing.Size(636, 239);
            this.dgvDetalleVenta.TabIndex = 28;
            // 
            // gpbCliente
            // 
            this.gpbCliente.BackColor = System.Drawing.Color.White;
            this.gpbCliente.Controls.Add(this.txtNroDoc);
            this.gpbCliente.Controls.Add(this.lblDocumentoCliente);
            this.gpbCliente.Controls.Add(this.txtDocCliente);
            this.gpbCliente.Controls.Add(this.lblNombreCompleto);
            this.gpbCliente.Controls.Add(this.txtNombreCliente);
            this.gpbCliente.Location = new System.Drawing.Point(196, 165);
            this.gpbCliente.Name = "gpbCliente";
            this.gpbCliente.Size = new System.Drawing.Size(636, 77);
            this.gpbCliente.TabIndex = 27;
            this.gpbCliente.TabStop = false;
            this.gpbCliente.Text = "Información cliente:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::GestionNegocio.Properties.Resources.eraser;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(757, 53);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 25;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblContenedor
            // 
            this.lblContenedor.BackColor = System.Drawing.Color.White;
            this.lblContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContenedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContenedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblContenedor.Location = new System.Drawing.Point(163, 10);
            this.lblContenedor.Name = "lblContenedor";
            this.lblContenedor.Size = new System.Drawing.Size(713, 517);
            this.lblContenedor.TabIndex = 21;
            this.lblContenedor.Text = "Detalle Venta";
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.Width = 200;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.HeaderText = "PrecioVenta";
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.Width = 150;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
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
            // frmDetalleVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(1055, 535);
            this.Controls.Add(this.gpbInfoCompra);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblNroDocumento);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.btnDescargarPDF);
            this.Controls.Add(this.lblMontoTotal);
            this.Controls.Add(this.txtMontoTotal);
            this.Controls.Add(this.dgvDetalleVenta);
            this.Controls.Add(this.gpbCliente);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDetalleVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDetalleVentas";
            this.gpbInfoCompra.ResumeLayout(false);
            this.gpbInfoCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.gpbCliente.ResumeLayout(false);
            this.gpbCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.Label lblDocumentoCliente;
        private System.Windows.Forms.TextBox txtDocCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.GroupBox gpbInfoCompra;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.TextBox txtTipoDoc;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblNroDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Button btnDescargarPDF;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.GroupBox gpbCliente;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblContenedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
    }
}