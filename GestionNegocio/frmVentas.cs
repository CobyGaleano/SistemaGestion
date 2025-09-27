using Dominio;
using GestionNegocio.Modales;
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


namespace GestionNegocio.Resources
{//LA SEGUNDA MAYOR TRUCHADA QUE INTENTO
    public partial class frmVentas : Form
    {
        private Usuario _Usuario;
        public frmVentas(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void limpiar()
        {
            txtIdProducto.Text = "0";
            txtCodigoProducto.Text = "";
            txtProducto.Text = "";
            txtPrecioVenta.Text = "";
            txtStock.Text = "";
            nudCantidad.Value = 1;
        }

        private void sumarTotal()
        {
            decimal total = 0;
            for(int fila = 0; fila < dgvVenta.Rows.Count; fila++ )
            {
                decimal subtotalActual = Convert.ToDecimal(dgvVenta.Rows[fila].Cells["SubTotal"].Value.ToString());
                total += subtotalActual;
            }
            /*if(dgvVenta.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dgvVenta.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
                }
            }*/
            txtTotal.Text = total.ToString("0.00"); 
        }

        private void CalcularCambio()
        {
            int cambio = 0;
            cambio = Convert.ToInt32(txtTotal) - Convert.ToInt32(txtPagaCon);
            txtCambio.Text = Convert.ToString(cambio); 
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cmbTipoDocumento.Items.Add(new OpcionCombo() { Valor = "P", Texto = "Presupuesto" });
            cmbTipoDocumento.Items.Add(new OpcionCombo() { Valor = "X", Texto = "Comprobante" });
            cmbTipoDocumento.Items.Add(new OpcionCombo() { Valor = "B", Texto = "Factura B" });
            cmbTipoDocumento.Items.Add(new OpcionCombo() { Valor = "A", Texto = "Factura A" });
            cmbTipoDocumento.DisplayMember = "Texto";
            cmbTipoDocumento.ValueMember = "Valor";
            cmbTipoDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtIdCliente.Text = "0";
            txtIdProducto.Text = "0";
            txtCambio.Text = "";
            txtPagaCon.Text = "";
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdClientes())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdCliente.Text = modal._Cliente.IdCliente.ToString();
                    txtNumeroDocumento.Text = modal._Cliente.Documento;
                    txtNombreCompleto.Text = modal._Cliente.NombreCompleto;
                }
                else { txtNumeroDocumento.Select(); }
            }

            
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProductos())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modal.producto.IdProducto.ToString();
                    txtCodigoProducto.Text = modal.producto.Codigo;
                    txtProducto.Text = modal.producto.Nombre;
                    txtPrecioVenta.Text = modal.producto.PrecioVenta.ToString("0.00");
                    txtStock.Text = modal.producto.Stock.ToString();
                    nudCantidad.Select();
                }
                else { txtCodigoProducto.Select(); }
            }
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                Producto oProducto = new ProductoNegocio().Listar().Where(p => p.Codigo == txtCodigoProducto.Text && p.Estado == true).FirstOrDefault();

                if (oProducto != null)
                {
                    txtCodigoProducto.BackColor = Color.Honeydew;
                    txtIdProducto.Text = oProducto.IdProducto.ToString();
                    txtProducto.Text = oProducto.Nombre.ToString();
                    txtPrecioVenta.Select();
                }
                else
                {
                    txtCodigoProducto.BackColor = Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precioVenta = 0;
            bool productoExiste = false;

            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(!decimal.TryParse(txtPrecioVenta.Text, out precioVenta))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtPrecioVenta.Select();
            }

            if (!decimal.TryParse(txtStock.Text, out precioVenta))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtStock.Select();
            }

            foreach(DataGridViewRow fila in dgvVenta.Rows)
            {
                if (Convert.ToString(fila.Cells[0].Value) == txtIdProducto.Text)
                {
                    productoExiste = true;
                    break;
                }
            }

            if(!productoExiste)
            {
               
                bool respuesta = new VentaNegocio().restarStock(Convert.ToInt32(txtIdProducto.Text),Convert.ToInt32(nudCantidad.Value.ToString()));

                if (respuesta)
                {
                    dgvVenta.Rows.Add(new object[]
                    {
                        txtIdProducto.Text,
                        txtProducto.Text,
                        precioVenta.ToString("0.00"),
                        nudCantidad.Value.ToString(),
                        (nudCantidad.Value * precioVenta).ToString("0.00")
                    });
                }
            }
            sumarTotal();
            CalcularCambio();
            limpiar();
            txtCodigoProducto.Select();
        }

        private void dgvVenta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.trash_24.Width;
                var h = Properties.Resources.trash_24.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.trash_24, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVenta.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;

                if(indice >= 0)
                {
                    bool respuesta = new VentaNegocio().sumarStock(
                        Convert.ToInt32(dgvVenta.Rows[indice].Cells["IdProducto"].Value.ToString()),
                        Convert.ToInt32(dgvVenta.Rows[indice].Cells["Cantidad"].Value.ToString())
                    );

                    if (respuesta)
                    {
                        dgvVenta.Rows.RemoveAt(indice);
                        sumarTotal();
                    }
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtIdCliente.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvVenta.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar al menos un articulo en la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalle_compra = new DataTable();

            detalle_compra.Columns.Add("IdProducto", typeof(int));
            detalle_compra.Columns.Add("precioVenta", typeof(decimal));
            detalle_compra.Columns.Add("Cantidad", typeof(int));
            detalle_compra.Columns.Add("MontoTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvVenta.Rows)
            {
                detalle_compra.Rows.Add(
                    new object[] {
                        Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                        row.Cells["precioVenta"].Value.ToString(),
                        row.Cells["Cantidad"].Value.ToString(),
                        row.Cells["SubTotal"].Value.ToString()
                    }
                );
            }
            int IdCorrelativo = new CompraNegocio().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000}", IdCorrelativo);

            Compra oCompra = new Compra()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txtIdCliente.Text) },
                TipoDocumento = ((OpcionCombo)cmbTipoDocumento.SelectedItem).Texto,
                NumeroDocumento = numeroDocumento,
                MontoTotal = Convert.ToDecimal(txtTotal.Text)
            };

            string mensaje = string.Empty;
            bool respuesta = new CompraNegocio().RegistrarCompra(oCompra, detalle_compra, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Numero de compra generada:\n" + numeroDocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes) Clipboard.SetText(numeroDocumento.ToString());

                txtIdCliente.Text = "0";
                txtNumeroDocumento.Text = "";
                txtNombreCompleto.Text = "";
                dgvVenta.Rows.Clear();
                sumarTotal();
            }

            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDetalleVenta_Click(object sender, EventArgs e)
        {
            Form fh = new frmDetalleVentas();
            fh.ShowDialog();
        }

        private void txtPagaCon_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                CalcularCambio();
            }
        }
    }
    
}
