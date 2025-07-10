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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }
        private void Clientes_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 2, Texto = "Inactivo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dgvClientes.Columns)
            {
                if (column.Visible == true && column.Name != "btnSeleccionar")
                {
                    cmbFiltro.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
                }
            }
            cmbFiltro.DisplayMember = "Texto";
            cmbFiltro.ValueMember = "Valor";
            cmbFiltro.SelectedIndex = 0;

            //MOSTRAR TODOS LOS ClienteS
            List<Cliente> listaClientes = new ClienteNegocio().Listar();

            foreach (Cliente item in listaClientes)
            {
                /*dgvClientes.Rows.Add(new object[] {"",item.IdCliente,item.Documento,item.NombreCompleto,item.Direccion,item.Telefono,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "Inactivo"
                });*/
                dgvClientes.Rows.Add(new object[] {"",item.IdCliente,item.Documento,item.NombreCompleto,item.Correo,item.Telefono,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "Inactivo"
                });
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            Cliente objCliente = new Cliente()
            {
                IdCliente = Convert.ToInt32(txtId.Text),
                Documento = txtDocumento.Text,
                NombreCompleto = txtNombre.Text,
                Correo = txtCorreo.Text,
                //Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cmbEstado.SelectedItem).Valor) == 1 ? true : false
            };

            int idClienteGenerado = 0;

            if (objCliente.Documento.ToString() == "")
            { mensaje += "Error, debes ingresar un numero de Documento Valido"; }
            /*else if (objCliente.NombreCompleto.ToString() == "" || objCliente.Direccion.ToString() == "")
            { mensaje += "Error, debe completar los campos faltantes"; }*/
            else if (objCliente.NombreCompleto.ToString() == "" || objCliente.Correo.ToString() == "")
            { mensaje += "Error, debe completar los campos faltantes"; }
            else if (objCliente.IdCliente == 0)
            {
                idClienteGenerado = new ClienteNegocio().Registrar(objCliente, out mensaje);

                if (idClienteGenerado != 0)
                {
                    dgvClientes.Rows.Add(new object[] {"",idClienteGenerado,txtDocumento.Text,txtNombre.Text,txtCorreo.Text,txtTelefono.Text,
                        ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString()
                    });
                    /*dgvClientes.Rows.Add(new object[] {"",idClienteGenerado,txtDocumento.Text,txtNombre.Text,txtDireccion.Text,txtTelefono.Text,
                        ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString()
                    });*/
                    mensaje = "El CLIENTE ha sido registrado correctamente.";
                    icon = MessageBoxIcon.Information;
                }
                else 
                {
                    mensaje = "Error, no se pudo registrar el CLIENTE";
                }

            }
            else
            {
                bool resultado = new ClienteNegocio().Editar(objCliente, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvClientes.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtDocumento.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    //row.Cells["Direccion"].Value = txtDocumento.Text;
                    row.Cells["Telefono"].Value = txtDocumento.Text;
                    row.Cells["IdEstado"].Value = ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString();
                    mensaje = "El CLIENTE ha sido modificado correctamente";
                    icon = MessageBoxIcon.Information;
                }
                else 
                {mensaje = "Error al modificar el CLIENTE";}
                
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
                if (MessageBox.Show("¿Desea eliminar el Cliente seleccionado?","Mensaje", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cliente objCliente = new Cliente()
                    {
                        IdCliente = Convert.ToInt32(txtId.Text)
                    };

                    bool respuesta = new ClienteNegocio().Eliminar(objCliente, out mensaje);

                    if (respuesta)
                    {
                        dgvClientes.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        mensaje = "El CLIENTE ha sido eliminado correctamente";
                        icon = MessageBoxIcon.Information;
                    }
                    else
                    {
                        mensaje = "Error, inesperado. No se pudo eliminar el cliente";
                        icon = MessageBoxIcon.Exclamation;
                    }
                }

                Limpiar();
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, icon);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cmbFiltro.SelectedItem).Valor.ToString();
            if (dgvClientes.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvClientes.Rows)
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
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                row.Visible = true;
            }
        }
        private void Limpiar()
        {
            txtIndice.Text = "-1"; //UNICO INDICE QUE NO CORRESPONDE A NINGUNO DENTRO DEL LISTADO
            txtId.Text = "0";
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            //txtDireccion.Text = "";
            cmbEstado.SelectedIndex = 0;

            txtDocumento.Select();

        }
        private void dgvClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ///Rellena los valores de mant Clientes, por los del Cliente selecionado en el DGV
            if (dgvClientes.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvClientes.Rows[indice].Cells["Id"].Value.ToString();
                    txtDocumento.Text = dgvClientes.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombre.Text = dgvClientes.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvClientes.Rows[indice].Cells["Correo"].Value.ToString();
                    //txtDireccion.Text = dgvClientes.Rows[indice].Cells["Direccion"].Value.ToString();
                    txtTelefono.Text = dgvClientes.Rows[indice].Cells["Telefono"].Value.ToString();


                    foreach (OpcionCombo oc in cmbEstado.Items) //al momento de seleccionar el Cliente existente no copia correctamente el Estado en la plantilla de carga
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvClientes.Rows[indice].Cells["IdEstado"].Value))
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
