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
using System.Windows.Media.Animation;

namespace GestionNegocio
{
    public partial class frmMantNegocio : Form
    {
        public frmMantNegocio()
        {
            InitializeComponent();
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes,0,imageBytes.Length);
            Image image = new Bitmap(ms);

            return image;
        }

        private void frmMantNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] bytesImage = new NegocioNegocio().ObtenerLogo(out obtenido);

            if (obtenido) { pxbLogo.Image = ByteToImage(bytesImage); }

            Dominio.Negocio datos = new NegocioNegocio().ObtenerDatos();

            txtNombreNegocio.Text = datos.ToString();
            txtRUC.Text = datos.ToString();
            txtDireccion.Text = datos.Direccion;


        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "Files|*.jpg;*.jpeg;*.png";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] bytesImage = File.ReadAllBytes(ofd.FileName);
                bool respuesta = new NegocioNegocio().ActualizarLogo(bytesImage,out mensaje);

                if (respuesta)
                    pxbLogo.Image = ByteToImage(bytesImage);
                else
                    MessageBox.Show(mensaje, "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
