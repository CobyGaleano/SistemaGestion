using GestionNegocio.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocio;
using Dominio;
using System.Windows.Media;


namespace GestionNegocio
{
    public partial class frmMantUsuario : Form
    {
        public frmMantUsuario()
        {
            InitializeComponent();
        }

        private void frmMantUsuario_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 2, Texto = "Inactivo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;

            List<Rol> listaRol = new RolNegocio().Listar();

            foreach (Rol item in listaRol){
            
                cmbRol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cmbRol.DisplayMember = "Texto";
            cmbRol.ValueMember = "Valor";
            cmbRol.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dgvUsuario.Columns)
            {
                if (column.Visible == true && column.Name != "btnSeleccionar")
                {
                    cmbFiltro.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
                }
            }
            cmbFiltro.DisplayMember = "Texto";
            cmbFiltro.ValueMember = "Valor";
            cmbFiltro.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dgvUsuario.Rows.Add(new object[] {"",txtId.Text,txtDocumento.Text,txtNombre.Text,txtCorreo.Text,txtContraseña.Text,
                ((OpcionCombo)cmbRol.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cmbRol.SelectedItem).Texto.ToString(),
                ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString()
            });
            Limpiar();
        }

        private void Limpiar()
        {
            txtId.Text = "0";
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtContraseña.Text = "";
            txtConfContra.Text = "";
            cmbEstado.SelectedIndex = 0;
            cmbRol.SelectedIndex = 0;

        }
        
    }
}
