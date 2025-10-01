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
    public partial class frmMantProveedores : Form
    {
        public frmMantProveedores()
        {
            InitializeComponent();
        }

        private void frmMantProveedores_Load(object sender, EventArgs e) //AL AGREGAR PROVEEDOR PERMITE AGREGAR LETRAS EN EL DOCUMENTO - VALIDAR PARA QUE SOLO PERMITA NUMEROS
        {
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 2, Texto = "Inactivo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dgvProveedores.Columns)
            {
                if (column.Visible == true && column.Name != "btnSeleccionar")
                {
                    cmbFiltro.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
                }
            }
            cmbFiltro.DisplayMember = "Texto";
            cmbFiltro.ValueMember = "Valor";
            cmbFiltro.SelectedIndex = 0;

            //MOSTRAR TODOS LOS Proveedores
            List<Proveedor> listaProveedores = new ProveedorNegocio().Listar();

            foreach (Proveedor item in listaProveedores)
            {
                /*dgvProveedores.Rows.Add(new object[] {"",item.IdProveedor,item.Documento,item.RazonSocial,item.Direccion,item.Telefono,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "Inactivo"
                });*/
                dgvProveedores.Rows.Add(new object[] {"",item.IdProveedor,item.Documento,item.RazonSocial,item.Correo,item.Telefono,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "Inactivo"
                });
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            Proveedor objProveedor = new Proveedor()
            {
                IdProveedor = Convert.ToInt32(txtId.Text),
                Documento = txtDocumento.Text,
                RazonSocial = txtRazonSocial.Text,
                Correo = txtCorreo.Text,
                //Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cmbEstado.SelectedItem).Valor) == 1 ? true : false
            };

            int idProveedorGenerado = 0;

            if (objProveedor.Documento.ToString() == "")
            { mensaje += "Error, debes ingresar un numero de Documento Valido"; }
            /*else if (objProveedor.RazonSocial.ToString() == "" || objProveedor.Direccion.ToString() == "")
            { mensaje += "Error, debe completar los campos faltantes"; }*/
            else if (objProveedor.RazonSocial.ToString() == "" || objProveedor.Correo.ToString() == "")
            { mensaje += "Error, debe completar los campos faltantes"; }
            else if (objProveedor.IdProveedor == 0)
            {
                idProveedorGenerado = new ProveedorNegocio().Registrar(objProveedor, out mensaje);

                if (idProveedorGenerado != 0)
                {
                    dgvProveedores.Rows.Add(new object[] {"",idProveedorGenerado,txtDocumento.Text,txtRazonSocial.Text,txtCorreo.Text,txtTelefono.Text,
                        ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString()
                    });

                    mensaje = "El Proveedor ha sido registrado correctamente.";
                    icon = MessageBoxIcon.Information;
                }
                else
                {
                    mensaje = "Error, no se pudo registrar el Proveedor";
                }

            }
            else
            {
                bool resultado = new ProveedorNegocio().Editar(objProveedor, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvProveedores.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["RazonSocial"].Value = txtRazonSocial.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Telefono"].Value = txtTelefono.Text;
                    row.Cells["IdEstado"].Value = ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString();
                    mensaje = "El Proveedor ha sido modificado correctamente";
                    icon = MessageBoxIcon.Information;
                }
                else
                { mensaje = "Error al modificar el Proveedor"; }

            }
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, icon);
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                String mensaje = string.Empty;
                MessageBoxIcon icon = MessageBoxIcon.Information;
                if (MessageBox.Show("¿Desea eliminar el Proveedor seleccionado?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Proveedor objProveedor = new Proveedor()
                    {
                        IdProveedor = Convert.ToInt32(txtId.Text)
                    };

                    bool respuesta = new ProveedorNegocio().Eliminar(objProveedor, out mensaje);

                    if (respuesta)
                    {
                        dgvProveedores.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        mensaje = "El Proveedor ha sido eliminado correctamente";
                        icon = MessageBoxIcon.Information;
                    }
                    else
                    {
                        mensaje = "Error, inesperado. No se pudo eliminar el Proveedor";
                        icon = MessageBoxIcon.Exclamation;
                    }
                }

                Limpiar();
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, icon);
            }
        }

        private void btnBuscarFiltro_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cmbFiltro.SelectedItem).Valor.ToString();
            if (dgvProveedores.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProveedores.Rows)
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
            foreach (DataGridViewRow row in dgvProveedores.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            txtIndice.Text = "-1"; //UNICO INDICE QUE NO CORRESPONDE A NINGUNO DENTRO DEL LISTADO
            txtId.Text = "0";
            txtDocumento.Text = "";
            txtRazonSocial.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            cmbEstado.SelectedIndex = 0;

            txtDocumento.Select();
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Rellena los valores de mant Proveedores, por los del Proveedor selecionado en el DGV
            if (dgvProveedores.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvProveedores.Rows[indice].Cells["Id"].Value.ToString();
                    txtDocumento.Text = dgvProveedores.Rows[indice].Cells["Documento"].Value.ToString();
                    txtRazonSocial.Text = dgvProveedores.Rows[indice].Cells["RazonSocial"].Value.ToString();
                    txtCorreo.Text = dgvProveedores.Rows[indice].Cells["Correo"].Value.ToString();
                    txtTelefono.Text = dgvProveedores.Rows[indice].Cells["Telefono"].Value.ToString();


                    foreach (OpcionCombo oc in cmbEstado.Items) //al momento de seleccionar el Proveedor existente no copia correctamente el Estado en la plantilla de carga
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvProveedores.Rows[indice].Cells["IdEstado"].Value))
                        {
                            int indice_combo = cmbEstado.Items.IndexOf(oc);
                            cmbEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }

        private void dgvProveedores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
    }
}
