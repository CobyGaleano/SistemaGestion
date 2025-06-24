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
    public partial class frmMantCategorias : Form
    {
        public frmMantCategorias()
        {
            InitializeComponent();
        }

        private void frmMantCategorias_Load(object sender, EventArgs e)
        {
            {
                cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
                cmbEstado.Items.Add(new OpcionCombo() { Valor = 2, Texto = "Inactivo" });
                cmbEstado.DisplayMember = "Texto";
                cmbEstado.ValueMember = "Valor";
                cmbEstado.SelectedIndex = 0;

                foreach (DataGridViewColumn column in dgvCategoria.Columns)
                {
                    if (column.Visible == true && column.Name != "btnSeleccionar")
                    {
                        cmbFiltro.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
                    }
                }
                cmbFiltro.DisplayMember = "Texto";
                cmbFiltro.ValueMember = "Valor";
                cmbFiltro.SelectedIndex = 0;

                //MOSTRAR TODAS LAS CATEGORIAS
                List<Categoria> lista = new CategoriaNegocio().Listar();

                foreach (Categoria item in lista)
                {
                    dgvCategoria.Rows.Add(new object[] {"",item.Id,item.Descripcion,
                                            item.Estado == true ? 1 : 0,
                                            item.Estado == true ? "Activo" : "Inactivo"
                    });
                }

            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Categoria obj = new Categoria()
            {
                Id = Convert.ToInt32(txtId.Text),
                Descripcion = txtDescripcion.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cmbEstado.SelectedItem).Valor) == 1 ? true : false
            };

            int Resultado = 0;

            if (obj.Descripcion.ToString() == "")
            { mensaje += "Error, debes ingresar una Descripcion"; }
            else if (obj.Id == 0)
            {
                Resultado = new CategoriaNegocio().Registrar(obj, out mensaje);

                if (Resultado != 0)
                {
                    dgvCategoria.Rows.Add(new object[] {"",Resultado,txtDescripcion.Text,
                    ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString()
                    });

                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpiar();
                }
                else { MessageBox.Show(mensaje); }

            }
            else
            {
                bool resultado = new CategoriaNegocio().Editar(obj, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvCategoria.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Descripcion"].Value = txtDescripcion.Text;
                    row.Cells["IdEstado"].Value = ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString();

                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpiar();
                }
                else { MessageBox.Show(mensaje); }
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e) //SE ELIMINA CORRECTAMENTE PERO DA EL MENSAJE DE ...
        {                                                          //..."CATEGORIA RELACIONADA A PRODUCTO" Y NO SE ACTUALIZA LA DGV
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar la CATEGORIA seleccionado?",
                                   "Mensaje", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    String mensaje = string.Empty;
                    Categoria obj = new Categoria()
                    {
                        Id = Convert.ToInt32(txtId.Text)
                    };
                    bool respuesta = new CategoriaNegocio().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        dgvCategoria.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                Limpiar();
            }
        }

        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtDescripcion.Text = "";
            cmbEstado.SelectedIndex = 0;
            txtDescripcion.Select();

        }
        private void dgvCategoria_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex < 0) return;
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

        private void dgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ///Rellena los valores de mant Categorias, por los del Categoria selecionado en el DGV
            if (dgvCategoria.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvCategoria.Rows[indice].Cells["Id"].Value.ToString();
                    txtDescripcion.Text = dgvCategoria.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach (OpcionCombo oc in cmbEstado.Items) //al momento de seleccionar el Categoria existente no copia correctamente el Estado en la plantilla de carga
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvCategoria.Rows[indice].Cells["IdEstado"].Value))
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
