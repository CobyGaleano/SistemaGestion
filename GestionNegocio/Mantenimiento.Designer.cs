namespace GestionNegocio
{
    partial class Mantenimiento
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnManProduc = new System.Windows.Forms.Button();
            this.btnManCat = new System.Windows.Forms.Button();
            this.btnManMarcas = new System.Windows.Forms.Button();
            this.btnManUsuarios = new System.Windows.Forms.Button();
            this.btnManNegocio = new System.Windows.Forms.Button();
            this.btnConfiguraciones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "MANTENIMIENTO";
            // 
            // btnManProduc
            // 
            this.btnManProduc.Location = new System.Drawing.Point(47, 95);
            this.btnManProduc.Name = "btnManProduc";
            this.btnManProduc.Size = new System.Drawing.Size(219, 144);
            this.btnManProduc.TabIndex = 3;
            this.btnManProduc.Text = "Productos";
            this.btnManProduc.UseVisualStyleBackColor = true;
            this.btnManProduc.Click += new System.EventHandler(this.btnManProduc_Click);
            // 
            // btnManCat
            // 
            this.btnManCat.Location = new System.Drawing.Point(289, 95);
            this.btnManCat.Name = "btnManCat";
            this.btnManCat.Size = new System.Drawing.Size(219, 144);
            this.btnManCat.TabIndex = 4;
            this.btnManCat.Text = "Categorias";
            this.btnManCat.UseVisualStyleBackColor = true;
            this.btnManCat.Click += new System.EventHandler(this.btnManCat_Click);
            // 
            // btnManMarcas
            // 
            this.btnManMarcas.Location = new System.Drawing.Point(530, 95);
            this.btnManMarcas.Name = "btnManMarcas";
            this.btnManMarcas.Size = new System.Drawing.Size(219, 144);
            this.btnManMarcas.TabIndex = 5;
            this.btnManMarcas.Text = "Marcas";
            this.btnManMarcas.UseVisualStyleBackColor = true;
            this.btnManMarcas.Click += new System.EventHandler(this.btnManMarcas_Click);
            // 
            // btnManUsuarios
            // 
            this.btnManUsuarios.Location = new System.Drawing.Point(47, 255);
            this.btnManUsuarios.Name = "btnManUsuarios";
            this.btnManUsuarios.Size = new System.Drawing.Size(219, 144);
            this.btnManUsuarios.TabIndex = 6;
            this.btnManUsuarios.Text = "Usuarios";
            this.btnManUsuarios.UseVisualStyleBackColor = true;
            this.btnManUsuarios.Click += new System.EventHandler(this.btnManUsuarios_Click);
            // 
            // btnManNegocio
            // 
            this.btnManNegocio.Location = new System.Drawing.Point(289, 255);
            this.btnManNegocio.Name = "btnManNegocio";
            this.btnManNegocio.Size = new System.Drawing.Size(219, 144);
            this.btnManNegocio.TabIndex = 7;
            this.btnManNegocio.Text = "Negocio";
            this.btnManNegocio.UseVisualStyleBackColor = true;
            this.btnManNegocio.Click += new System.EventHandler(this.btnManNegocio_Click);
            // 
            // btnConfiguraciones
            // 
            this.btnConfiguraciones.Location = new System.Drawing.Point(530, 255);
            this.btnConfiguraciones.Name = "btnConfiguraciones";
            this.btnConfiguraciones.Size = new System.Drawing.Size(219, 144);
            this.btnConfiguraciones.TabIndex = 8;
            this.btnConfiguraciones.Text = "Configuraciones";
            this.btnConfiguraciones.UseVisualStyleBackColor = true;
            this.btnConfiguraciones.Click += new System.EventHandler(this.btnConfiguraciones_Click);
            // 
            // Mantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConfiguraciones);
            this.Controls.Add(this.btnManNegocio);
            this.Controls.Add(this.btnManUsuarios);
            this.Controls.Add(this.btnManMarcas);
            this.Controls.Add(this.btnManCat);
            this.Controls.Add(this.btnManProduc);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mantenimiento";
            this.Text = "Mantenimiento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManProduc;
        private System.Windows.Forms.Button btnManCat;
        private System.Windows.Forms.Button btnManMarcas;
        private System.Windows.Forms.Button btnManUsuarios;
        private System.Windows.Forms.Button btnManNegocio;
        private System.Windows.Forms.Button btnConfiguraciones;
    }
}