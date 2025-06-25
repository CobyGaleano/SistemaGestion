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
    public partial class frmMantMarcas : Form
    {
        public frmMantMarcas()
        {
            InitializeComponent();
        }

        private void frmMantMarcas_Load(object sender, EventArgs e)
        {
            {
                cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
                cmbEstado.Items.Add(new OpcionCombo() { Valor = 2, Texto = "Inactivo" });
                cmbEstado.DisplayMember = "Texto";
                cmbEstado.ValueMember = "Valor";
                cmbEstado.SelectedIndex = 0;

                foreach (DataGridViewColumn column in dgvMarca.Columns)
                {
                    if (column.Visible == true && column.Name != "btnSeleccionar")
                    {
                        cmbFiltro.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
                    }
                }
                cmbFiltro.DisplayMember = "Texto";
                cmbFiltro.ValueMember = "Valor";
                cmbFiltro.SelectedIndex = 0;

                //MOSTRAR TODAS LAS MarcaS
                List<Marca> lista = new MarcaNegocio().Listar();

                foreach (Marca item in lista)
                {
                    dgvMarca.Rows.Add(new object[] {"",item.Id,item.Nombre,
                                            item.Estado == true ? 1 : 0,
                                            item.Estado == true ? "Activo" : "Inactivo"
                    });
                }

            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Marca obj = new Marca()
            {
                Id = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cmbEstado.SelectedItem).Valor) == 1 ? true : false
            };

            int Resultado = 0;

            if (obj.Nombre.ToString() == "")
            { mensaje += "Error, debes ingresar una Nombre"; }
            else if (obj.Id == 0)
            {
                Resultado = new MarcaNegocio().Registrar(obj, out mensaje);

                if (Resultado != 0)
                {
                    dgvMarca.Rows.Add(new object[] {"",Resultado,txtNombre.Text,
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
                bool resultado = new MarcaNegocio().Editar(obj, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvMarca.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Nombre"].Value = txtNombre.Text;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar la Marca seleccionado?",
                                   "Mensaje", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    String mensaje = string.Empty;
                    Marca obj = new Marca()
                    {
                        Id = Convert.ToInt32(txtId.Text)
                    };
                    bool respuesta = new MarcaNegocio().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        dgvMarca.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
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
            txtNombre.Text = "";
            cmbEstado.SelectedIndex = 0;
            txtNombre.Select();

        }

        private void dgvMarca_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvMarca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ///Rellena los valores de mant Marcas, por los del Marca selecionado en el DGV
            if (dgvMarca.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvMarca.Rows[indice].Cells["Id"].Value.ToString();
                    txtNombre.Text = dgvMarca.Rows[indice].Cells["Nombre"].Value.ToString();

                    foreach (OpcionCombo oc in cmbEstado.Items) //al momento de seleccionar el Marca existente no copia correctamente el Estado en la plantilla de carga
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvMarca.Rows[indice].Cells["IdEstado"].Value))
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
