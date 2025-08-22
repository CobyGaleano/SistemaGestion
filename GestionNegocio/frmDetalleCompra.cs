using DocumentFormat.OpenXml.Wordprocessing;
using Dominio;
using iTextSharp.text.pdf;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionNegocio
{
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Compra oCompra = new CompraNegocio().obtenerCompra(txtDocumento.Text);

            if(oCompra.IdCompra != 0)
            {
                List<Detalle_Compra> oDetalleCompra = new CompraNegocio().obtenerDetalleCompra(oCompra.IdCompra);
                txtNroDoc.Text = oCompra.NumeroDocumento;
                txtFecha.Text = oCompra.FechaRegistro;
                txtTipoDoc.Text = oCompra.TipoDocumento;
                txtUsuario.Text = oCompra.oUsuario.NombreCompleto;
                txtDocProveedor.Text = oCompra.oProveedor.Documento;
                txtRazonSocial.Text = oCompra.oProveedor.RazonSocial;

                oCompra.ListaDetalleCompra = oDetalleCompra;
                dgvDetalleCompra.Rows.Clear();
                foreach(Detalle_Compra dc in oCompra.ListaDetalleCompra){
                    dgvDetalleCompra.Rows.Add(new object[] { dc.oProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal });
                }
                txtMontoTotal.Text = oCompra.MontoTotal.ToString("0.00");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            txtTipoDoc.Text = "";
            txtUsuario.Text = "";
            txtDocProveedor.Text = "";
            txtRazonSocial.Text = "";

            dgvDetalleCompra.Rows.Clear();
            txtMontoTotal.Text = "0.00";
        }

        private void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            if(txtTipoDoc.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_HTML = Properties.Resources.PlantillaCompra.ToString();
            Dominio.Negocio oDatos = new NegocioNegocio().ObtenerDatos();

            Texto_HTML = Texto_HTML.Replace("@nombrenegocio", oDatos.Nombre.ToUpper());
            Texto_HTML = Texto_HTML.Replace("@docnegocio", oDatos.RUC);
            Texto_HTML = Texto_HTML.Replace("@direcnegocio", oDatos.Direccion);

            Texto_HTML = Texto_HTML.Replace("@tipodocumento", txtTipoDoc.Text.ToUpper());
            Texto_HTML = Texto_HTML.Replace("@numerodocumento", txtNroDoc.Text);

            Texto_HTML = Texto_HTML.Replace("@docproveeor", txtDocProveedor.Text);
            Texto_HTML = Texto_HTML.Replace("@nombreproveedor", txtRazonSocial.Text);
            Texto_HTML = Texto_HTML.Replace("@fecharegistro", txtFecha.Text);
            Texto_HTML = Texto_HTML.Replace("@usuarioregistro", txtUsuario.Text);

            string filas = string.Empty;
            foreach(DataGridViewRow row in dgvDetalleCompra.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_HTML = Texto_HTML.Replace("@filas", filas);
            Texto_HTML = Texto_HTML.Replace("@montoTotal", txtMontoTotal.Text);

            //CREACION DEL ARCHIVO EXCEL
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Compras_{0}.xlsx", txtNroDoc.Text);
            savefile.Filter = "PDF files|*.pdf";

            if(savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream  = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                }
            }

        }
    }
}
