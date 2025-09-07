using Dominio;
using iTextSharp.text;
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
    public partial class frmDetalleVentas : Form
    {
        public frmDetalleVentas()
        {
            InitializeComponent();
        }

        private void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            if (txtTipoDoc.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_HTML = Properties.Resources.PlantillaCompra.ToString();
            Dominio.Negocio oDatos = new NegocioNegocio().ObtenerDatos(); //ERROR AL OBTENER LOS DATOS - VERIFICAR ERROR

            Texto_HTML = Texto_HTML.Replace("@nombrenegocio", oDatos.Nombre.ToUpper());
            Texto_HTML = Texto_HTML.Replace("@docnegocio", oDatos.RUC);
            Texto_HTML = Texto_HTML.Replace("@direcnegocio", oDatos.Direccion);

            Texto_HTML = Texto_HTML.Replace("@tipodocumento", txtTipoDoc.Text.ToUpper());
            Texto_HTML = Texto_HTML.Replace("@numerodocumento", txtNroDoc.Text);

            Texto_HTML = Texto_HTML.Replace("@docproveedor", txtDocProveedor.Text);
            Texto_HTML = Texto_HTML.Replace("@nombreproveedor", txtRazonSocial.Text);
            Texto_HTML = Texto_HTML.Replace("@fecharegistro", txtFecha.Text);
            Texto_HTML = Texto_HTML.Replace("@usuarioregistro", txtUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvDetalleCompra.Rows)
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
            savefile.FileName = string.Format("Compras_{0}.pdf", txtNroDoc.Text);
            savefile.Filter = "PDF files|*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {

                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    bool obtenido = true;
                    byte[] byteImagen = new NegocioNegocio().ObtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImagen);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(Texto_HTML))
                    {
                        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("PDF generado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
