using Dominio;
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
            MessageBox.Show(usuario.NombreCompleto);
        }
    }
}
