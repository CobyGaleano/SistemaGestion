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

            //MOSTRAR TODOS LOS USUARIOS
            List<Usuario> listaUsuarios = new UsuarioNegocio().Listar();

            foreach (Usuario item in listaUsuarios)
            {
                dgvUsuario.Rows.Add(new object[] {"",item.IdUsuario,item.Documento,item.NombreCompleto,item.Correo,item.Clave,
                item.rRol.IdRol,
                item.rRol.Descripcion,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "Activo" : "Inactivo"
                });
            }
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

        private void dgvUsuario_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 ) return;
            if (e.ColumnIndex == 0 )
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check_circle.Width;
                var h = Properties.Resources.check_circle.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check_circle, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ///Rellena los valores de mant Usuarios, por los del usuario selecionado en el DGV
            if (dgvUsuario.Columns[e.ColumnIndex].Name == "btnSeleccionar") 
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtId.Text = dgvUsuario.Rows[indice].Cells["Id"].Value.ToString();
                    txtDocumento.Text = dgvUsuario.Rows[indice].Cells["Documento"].Value.ToString();
                    txtCorreo.Text = dgvUsuario.Rows[indice].Cells["Correo"].Value.ToString();
                    txtContraseña.Text = dgvUsuario.Rows[indice].Cells["Clave"].Value.ToString();
                    txtConfContra.Text = dgvUsuario.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach(OpcionCombo OC in cmbRol.Items)
                    {
                        if(Convert.ToInt32(OC.Valor) == Convert.ToInt32(dgvUsuario.Rows[indice].Cells["IdRol"].Value.ToString())
                        {
                            int indice_combo = cmbRol.Items.IndexOf(OC);
                            cmbRol.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }
    }
}
