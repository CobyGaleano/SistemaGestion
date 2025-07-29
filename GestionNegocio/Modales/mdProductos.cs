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

namespace GestionNegocio.Modales
{
    public partial class mdProductos : Form
    {
        public Producto producto { get; set; }
        public mdProductos()
        {
            InitializeComponent();
        }

        private void mdProductos_Load(object sender, EventArgs e)
        {

            foreach (DataGridViewColumn column in dgvProductos.Columns)
            {
                if (column.Visible == true)
                {
                    cmbFiltro.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
                }
            }
            cmbFiltro.DisplayMember = "Texto";
            cmbFiltro.ValueMember = "Valor";
            cmbFiltro.SelectedIndex = 0;

            //MOSTRAR TODOS LOS PRODUCTOS
            List<Producto> listaProductos = new ProductoNegocio().Listar();

            foreach (Producto item in listaProductos)
            {
                dgvProductos.Rows.Add(new object[]
                {
                    item.IdProducto,
                    item.Codigo,
                    item.Nombre,
                    item.oCategoria.Descripcion,
                    item.oMarca.Nombre,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta,
                });
            }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iCol = e.ColumnIndex;

            if (iRow >= 0 && iCol > 0)
            {
                producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(dgvProductos.Rows[iRow].Cells["IdProducto"].Value.ToString()),
                    Codigo = dgvProductos.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombre = dgvProductos.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    oCategoria = new Categoria() { Id = Convert.ToInt32(dgvProductos.Rows[iRow].Cells["IdCategoria"].Value.ToString()) },
                    oMarca = new Marca() { Id = Convert.ToInt32(dgvProductos.Rows[iRow].Cells["IdMarca"].Value.ToString()) },
                    Stock = Convert.ToInt32(dgvProductos.Rows[iRow].Cells["Stock"].Value.ToString()),
                    PrecioCompra = Convert.ToInt32(dgvProductos.Rows[iRow].Cells["PrecioCompra"].ToString()),
                    PrecioVenta = Convert.ToInt32(dgvProductos.Rows[iRow].Cells["PrecioVenta"].ToString()),
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cmbFiltro.SelectedItem).Valor.ToString();
            if (dgvProductos.Rows.Count > 0)
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
    }
}
