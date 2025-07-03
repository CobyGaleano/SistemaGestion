using Dominio;
using GestionNegocio.Resources;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionNegocio
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }
        private void frmProductos_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 2, Texto = "Inactivo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;

            List<Categoria> listaCategoria = new CategoriaNegocio().Listar();
            foreach (Categoria item in listaCategoria)
            {

                cmbCategoria.Items.Add(new OpcionCombo() { Valor = item.Id, Texto = item.Descripcion });
            }
            cmbCategoria.DisplayMember = "Texto";
            cmbCategoria.ValueMember = "Valor";
            cmbCategoria.SelectedIndex = 0;

            List<Marca> listaMarca = new MarcaNegocio().Listar();
            foreach (Marca item in listaMarca)
            {

                cmbMarca.Items.Add(new OpcionCombo() { Valor = item.Id, Texto = item.Nombre });
            }
            cmbMarca.DisplayMember = "Texto";
            cmbMarca.ValueMember = "Valor";
            cmbMarca.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dgvProductos.Columns)
            {
                if (column.Visible == true && column.Name != "btnSeleccionar")
                {
                    cmbFiltro.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
                }
            }
            cmbFiltro.DisplayMember = "Texto";
            cmbFiltro.ValueMember = "Valor";
            cmbFiltro.SelectedIndex = 0;

            //MOSTRAR TODOS LOS ProductoS
            List<Producto> listaProductos = new ProductoNegocio().Listar();

            foreach (Producto item in listaProductos)
            {
                dgvProductos.Rows.Add(new object[]
                {
                    "",
                    item.IdProducto,
                    item.Codigo,
                    item.Nombre,
                    item.Descripcion,
                    item.oCategoria.Id,
                    item.oCategoria.Descripcion,
                    item.oMarca.Id,
                    item.oMarca.Nombre,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "Inactivo"
                });
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Producto objProducto = new Producto()
            {
                IdProducto = Convert.ToInt32(txtId.Text),
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                oCategoria = new Categoria() { Id = Convert.ToInt32(((OpcionCombo)cmbCategoria.SelectedItem).Valor) },
                oMarca = new Marca() { Id = Convert.ToInt32(((OpcionCombo)cmbMarca.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cmbEstado.SelectedItem).Valor) == 1 ? true : false
            };

            int idProductoGenerado = 0;

            if (objProducto.Codigo.ToString() == "")
            { mensaje += "Error, debes ingresar un Codigo Valido"; }
            else if (objProducto.Nombre.ToString() == "" || objProducto.Descripcion.ToString() == "")
            { mensaje += "Error, debe completar los campos faltantes"; }
            else if (objProducto.IdProducto == 0)
            {
                idProductoGenerado = new ProductoNegocio().Registrar(objProducto, out mensaje);

                if (idProductoGenerado != 0)
                {
                    dgvProductos.Rows.Add(new object[] {"",idProductoGenerado,txtCodigo.Text,txtNombre.Text,txtDescripcion.Text,
                        ((OpcionCombo)cmbCategoria.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cmbCategoria.SelectedItem).Texto.ToString(),
                        ((OpcionCombo)cmbMarca.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cmbMarca.SelectedItem).Texto.ToString(),
                        ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString()
                    });

                    Limpiar();
                }
                else { MessageBox.Show(mensaje); }

            }
            else
            {
                bool resultado = new ProductoNegocio().Editar(objProducto, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvProductos.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Codigo"].Value = txtCodigo;
                    row.Cells["Nombre"].Value = txtCodigo;
                    row.Cells["Descripcion"].Value = txtCodigo;
                    row.Cells["IdCategoria"].Value = ((OpcionCombo)cmbCategoria.SelectedItem).Valor.ToString();
                    row.Cells["Categoria"].Value = ((OpcionCombo)cmbCategoria.SelectedItem).Texto.ToString();
                    row.Cells["IdMarca"].Value = ((OpcionCombo)cmbCategoria.SelectedItem).Valor.ToString();
                    row.Cells["Marca"].Value = ((OpcionCombo)cmbCategoria.SelectedItem).Texto.ToString();
                    row.Cells["IdEstado"].Value = ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString();

                    Limpiar();
                }
                else { MessageBox.Show(mensaje); }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el Producto seleccionado?",
                   "Mensaje", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String mensaje = string.Empty;
                Producto objProducto = new Producto()
                {
                    IdProducto = Convert.ToInt32(txtId.Text)
                };
                bool respuesta = new ProductoNegocio().Eliminar(objProducto, out mensaje);

                if (respuesta)
                {
                    dgvProductos.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            Limpiar();
        }
    

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cmbFiltro.SelectedItem).Valor.ToString();
            if(dgvProductos.Rows.Count > 0 )
            {
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtFiltro.Text.Trim().ToUpper()))
                         row.Visible = true;
                    else row.Visible = false; 
                }
            }
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                row.Visible = true;
            }
        }
        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            cmbEstado.SelectedIndex = 0;
            cmbCategoria.SelectedIndex = 0;
            cmbMarca.SelectedIndex = 0;

            txtCodigo.Select();

        }

        private void dgvProductos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 0)
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

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ///Rellena los valores de mant Productos, por los del Producto selecionado en el DGV
            if (dgvProductos.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvProductos.Rows[indice].Cells["Id"].Value.ToString();
                    txtCodigo.Text = dgvProductos.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombre.Text = dgvProductos.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtDescripcion.Text = dgvProductos.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach (OpcionCombo OC in cmbCategoria.Items)
                    {
                        if (Convert.ToInt32(OC.Valor) == Convert.ToInt32(dgvProductos.Rows[indice].Cells["IdCategoria"].Value))
                        {
                            int indice_combo = cmbCategoria.Items.IndexOf(OC);
                            cmbCategoria.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionCombo OC in cmbMarca.Items)
                    {
                        if (Convert.ToInt32(OC.Valor) == Convert.ToInt32(dgvProductos.Rows[indice].Cells["IdMarca"].Value))
                        {
                            int indice_combo = cmbMarca.Items.IndexOf(OC);
                            cmbMarca.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionCombo oc in cmbEstado.Items) //al momento de seleccionar el Producto existente no copia correctamente el Estado en la plantilla de carga
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvProductos.Rows[indice].Cells["IdEstado"].Value))
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

