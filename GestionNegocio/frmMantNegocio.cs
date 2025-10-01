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
    public partial class frmMantNegocio : Form // - EL PROGRAMA EN SU TOTALIDAD DEBE TOMAR LA INFORMACION QUE HAY ACÁ -
    {                                         // Agregar en un futuro modificacion de colores, de moneda, etc.....
        public frmMantNegocio()
        {
            InitializeComponent();
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
                return null;

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }

        private void frmMantNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] bytesImage = new NegocioNegocio().ObtenerLogo(out obtenido);

            if (obtenido && bytesImage != null && bytesImage.Length > 0)
                pxbLogo.Image = ByteToImage(bytesImage);
            else
                pxbLogo.Image = Properties.Resources.placeholder_icon;// una imagen por defecto opcional

            Dominio.Negocio datos = new NegocioNegocio().ObtenerDatos();

            txtNombreNegocio.Text = datos.Nombre;
            txtRUC.Text = datos.RUC;
            txtDireccion.Text = datos.Direccion;
        }


        private void btnSubir_Click(object sender, EventArgs e) //NO ME PERMITE SUBIR UNA IMAGEN 
        {
            string mensaje = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "Files|*.jpg;*.jpeg;*.png";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] bytesImage = File.ReadAllBytes(ofd.FileName);
                bool respuesta = new NegocioNegocio().ActualizarLogo(bytesImage,out mensaje);

                if (respuesta) { pxbLogo.Image = ByteToImage(bytesImage); }
                else
                    MessageBox.Show(mensaje, "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
