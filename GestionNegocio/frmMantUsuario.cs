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
            string mensaje = string.Empty;
            Usuario objUsuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtId.Text),
                Documento = txtDocumento.Text,
                NombreCompleto = txtNombre.Text,
                Correo = txtCorreo.Text,
                Clave = txtContraseña.Text,
                rRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cmbRol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cmbEstado.SelectedItem).Valor) == 1 ? true : false
            };

            int idUsuarioGenerado = 0;

            if (Convert.ToInt32(objUsuario.Documento) == 0 || objUsuario.Documento.ToString() == "")
            { mensaje += "Error, debes ingresar un numero de Documento Valido"; }
            else if (objUsuario.NombreCompleto.ToString() == "" || objUsuario.Correo.ToString() == "")
            { mensaje += "Error, debe completar los campos faltantes"; }
            else if (objUsuario.Clave.ToString() != txtConfContra.Text)
            { mensaje += "Error, las contraseñas no coinciden"; }
            else
            { idUsuarioGenerado = new UsuarioNegocio().Registrar(objUsuario, out mensaje); }
            

            if (idUsuarioGenerado != 0)
            {
                dgvUsuario.Rows.Add(new object[] {"",idUsuarioGenerado,txtDocumento.Text,txtNombre.Text,txtCorreo.Text,txtContraseña.Text,
                ((OpcionCombo)cmbRol.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cmbRol.SelectedItem).Texto.ToString(),
                ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString()
                });

                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void Limpiar()
        {
            txtIndice.Text = "-1";
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
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvUsuario.Rows[indice].Cells["Id"].Value.ToString();
                    txtDocumento.Text = dgvUsuario.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombre.Text = dgvUsuario.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvUsuario.Rows[indice].Cells["Correo"].Value.ToString();
                    txtContraseña.Text = dgvUsuario.Rows[indice].Cells["Clave"].Value.ToString();
                    txtConfContra.Text = dgvUsuario.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (OpcionCombo OC in cmbRol.Items)
                    {
                        if (Convert.ToInt32(OC.Valor) == Convert.ToInt32(dgvUsuario.Rows[indice].Cells["IdRol"].Value))
                        { 
                            int indice_combo = cmbRol.Items.IndexOf(OC);
                            cmbRol.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach(OpcionCombo oc in cmbEstado.Items) //al momento de seleccionar el Usuario existente no copia correctamente el Estado en la plantilla de carga
                    {
                        if(Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvUsuario.Rows[indice].Cells["IdEstado"].Value))
                        {
                            int indice_combo = cmbEstado.Items.IndexOf(oc);
                            cmbEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }
    }
}
