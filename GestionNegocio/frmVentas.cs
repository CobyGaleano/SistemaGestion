﻿using Dominio;
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
{
    public partial class frmVentas : Form
    {
        private Usuario usuario;
        public frmVentas(Usuario oUsuario = null)
        {
            usuario = oUsuario;
            InitializeComponent();

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

            txtIdProveedor.Text = "0";
            txtIdProducto.Text = "0";

             
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProveedor())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProveedor.Text = modal.proveedor.IdProveedor.ToString();
                    txtNumeroDocumento.Text = modal.proveedor.Documento;
                    txtRazonSocial.Text = modal.proveedor.RazonSocial;
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
                    txtPrecioCompra.Select();
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
                    txtPrecioCompra.Select();
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
            decimal precioCompra = 0;
            decimal precioVenta = 0;
            bool productoExiste = false;

            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(!decimal.TryParse(txtPrecioCompra.Text, out precioCompra))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtPrecioCompra.Select();
            }

            if (!decimal.TryParse(txtPrecioVenta.Text, out precioVenta))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioVenta.Select();
            }

            foreach(DataGridViewRow fila in dgvVenta.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text)
                {
                    productoExiste = true;
                    break;
                }
            }

            if(!productoExiste)
            {
                dgvVenta.Rows.Add(new object[]
                {
                    txtIdProducto.Text,
                    txtProducto.Text,
                    txtPrecioCompra.Text,
                    txtPrecioVenta.Text,
                    nudCantidad.Value.ToString(),
                    (nudCantidad.Value * precioCompra).ToString("0.00")

                });
            }
        }
    }
}
