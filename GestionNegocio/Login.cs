using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace GestionNegocio
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVisible_Click(object sender, EventArgs e)
        {
            btnVisible.Visible = false;
            btnInvisible.Visible = true;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnInvisible_Click(object sender, EventArgs e)
        {
            btnVisible.Visible = true;
            btnInvisible.Visible = false;
            txtPassword.UseSystemPasswordChar = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new UsuarioNegocio().Listar();
            Usuario oUsuario = new UsuarioNegocio().Listar().Where(u  => u.Documento == txtUser.Text && u.Clave == txtPassword.Text).FirstOrDefault();

            if (oUsuario != null)
            {
                WinMenu winMenu = new WinMenu(oUsuario);

                winMenu.Show();
                this.Hide();

                winMenu.FormClosing += frm_closing;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No se encontro el Usuario","USUARIO NO ENCONTRADO",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); 
            }
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtUser.Text = "";
            txtPassword.Text = "";
            this.Show();
        }
    }
}
