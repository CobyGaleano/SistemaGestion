namespace GestionNegocio
{
    partial class Productos
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
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnCampo = new System.Windows.Forms.Label();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.btnCriterio = new System.Windows.Forms.Label();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.btnFiltro = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.pbxProducto = new System.Windows.Forms.PictureBox();
            this.lblTdes = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblBuscadorRapido = new System.Windows.Forms.Label();
            this.txtBuscadorRapido = new System.Windows.Forms.TextBox();
            this.btnBuscadorRapido = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProductos.Location = new System.Drawing.Point(29, 63);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(787, 465);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            // 
            // btnCampo
            // 
            this.btnCampo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCampo.AutoSize = true;
            this.btnCampo.Location = new System.Drawing.Point(26, 548);
            this.btnCampo.Name = "btnCampo";
            this.btnCampo.Size = new System.Drawing.Size(40, 13);
            this.btnCampo.TabIndex = 1;
            this.btnCampo.Text = "Campo";
            // 
            // cboCampo
            // 
            this.cboCampo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(29, 564);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(121, 21);
            this.cboCampo.TabIndex = 2;
            this.cboCampo.SelectedIndexChanged += new System.EventHandler(this.cboCampo_SelectedIndexChanged);
            // 
            // btnCriterio
            // 
            this.btnCriterio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCriterio.AutoSize = true;
            this.btnCriterio.Location = new System.Drawing.Point(161, 548);
            this.btnCriterio.Name = "btnCriterio";
            this.btnCriterio.Size = new System.Drawing.Size(39, 13);
            this.btnCriterio.TabIndex = 3;
            this.btnCriterio.Text = "Criterio";
            // 
            // cboCriterio
            // 
            this.cboCriterio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(164, 564);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(121, 21);
            this.cboCriterio.TabIndex = 4;
            // 
            // btnFiltro
            // 
            this.btnFiltro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFiltro.AutoSize = true;
            this.btnFiltro.Location = new System.Drawing.Point(295, 548);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(29, 13);
            this.btnFiltro.TabIndex = 5;
            this.btnFiltro.Text = "Filtro";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFiltro.Location = new System.Drawing.Point(298, 564);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(124, 20);
            this.txtFiltro.TabIndex = 6;
            // 
            // pbxProducto
            // 
            this.pbxProducto.ErrorImage = null;
            this.pbxProducto.InitialImage = null;
            this.pbxProducto.Location = new System.Drawing.Point(880, 63);
            this.pbxProducto.Name = "pbxProducto";
            this.pbxProducto.Size = new System.Drawing.Size(189, 172);
            this.pbxProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxProducto.TabIndex = 7;
            this.pbxProducto.TabStop = false;
            // 
            // lblTdes
            // 
            this.lblTdes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTdes.AutoSize = true;
            this.lblTdes.Location = new System.Drawing.Point(886, 287);
            this.lblTdes.Name = "lblTdes";
            this.lblTdes.Size = new System.Drawing.Size(69, 13);
            this.lblTdes.TabIndex = 8;
            this.lblTdes.Text = "Descripcion: ";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(886, 354);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(11, 13);
            this.lblDescripcion.TabIndex = 9;
            this.lblDescripcion.Text = "*";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscar.Location = new System.Drawing.Point(448, 563);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 20);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnModificar.Location = new System.Drawing.Point(880, 497);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(87, 31);
            this.btnModificar.TabIndex = 11;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEliminar.Location = new System.Drawing.Point(991, 497);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 31);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(880, 534);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(198, 56);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblBuscadorRapido
            // 
            this.lblBuscadorRapido.AutoSize = true;
            this.lblBuscadorRapido.Location = new System.Drawing.Point(26, 40);
            this.lblBuscadorRapido.Name = "lblBuscadorRapido";
            this.lblBuscadorRapido.Size = new System.Drawing.Size(52, 13);
            this.lblBuscadorRapido.TabIndex = 14;
            this.lblBuscadorRapido.Text = "Buscador";
            // 
            // txtBuscadorRapido
            // 
            this.txtBuscadorRapido.Location = new System.Drawing.Point(84, 37);
            this.txtBuscadorRapido.Name = "txtBuscadorRapido";
            this.txtBuscadorRapido.Size = new System.Drawing.Size(147, 20);
            this.txtBuscadorRapido.TabIndex = 15;
            // 
            // btnBuscadorRapido
            // 
            this.btnBuscadorRapido.Location = new System.Drawing.Point(237, 37);
            this.btnBuscadorRapido.Name = "btnBuscadorRapido";
            this.btnBuscadorRapido.Size = new System.Drawing.Size(75, 20);
            this.btnBuscadorRapido.TabIndex = 16;
            this.btnBuscadorRapido.Text = "Buscar";
            this.btnBuscadorRapido.UseVisualStyleBackColor = true;
            this.btnBuscadorRapido.Click += new System.EventHandler(this.btnBuscadorRapido_Click);
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(1100, 615);
            this.Controls.Add(this.btnBuscadorRapido);
            this.Controls.Add(this.txtBuscadorRapido);
            this.Controls.Add(this.lblBuscadorRapido);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTdes);
            this.Controls.Add(this.pbxProducto);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.cboCriterio);
            this.Controls.Add(this.btnCriterio);
            this.Controls.Add(this.cboCampo);
            this.Controls.Add(this.btnCampo);
            this.Controls.Add(this.dgvProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label btnCampo;
        private System.Windows.Forms.ComboBox cboCampo;
        private System.Windows.Forms.Label btnCriterio;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.Label btnFiltro;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.PictureBox pbxProducto;
        private System.Windows.Forms.Label lblTdes;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblBuscadorRapido;
        private System.Windows.Forms.TextBox txtBuscadorRapido;
        private System.Windows.Forms.Button btnBuscadorRapido;
    }
}