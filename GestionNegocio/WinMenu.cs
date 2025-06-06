using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Dominio;
using Negocio;



namespace GestionNegocio
{
    public partial class WinMenu : Form
    {
        public static Usuario usuarioActual;
        public WinMenu(Usuario objUsuario = null)
        {
            if (objUsuario == null)
                usuarioActual = new Usuario(){ NombreCompleto = "PREDEFINIDO",IdUsuario = 1};
            else
                usuarioActual = objUsuario;
                InitializeComponent();
        }

        private void Principal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WinMenu_Load(object sender, EventArgs e)
        {
            List<Permiso> listaPermisos = new PermisoNegocio().Listar(usuarioActual.IdUsuario);
            foreach(Button button in BarraMenu.Controls.OfType<Button>())
            {
                bool encontrado = listaPermisos.Any(m => m.NombreMenu == button.Name);
                if (encontrado==false)
                {
                    button.Enabled = false;
                }
            }
            txtUsuario.Text = usuarioActual.NombreCompleto;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
             DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }    

        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnAmpliar.Visible = true;
        }

        private void btnAmpliar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnAmpliar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Productos());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Ventas());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Clientes());
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Gastos());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if(SubmenuReportes.Visible!=true) SubmenuReportes.Visible = true;
            else SubmenuReportes.Visible = false;
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            if(SubMenuMantenimiento.Visible != true) SubMenuMantenimiento.Visible = true;
            else SubMenuMantenimiento.Visible = false;
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Inicio());
        }

        private void BarraMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRventas_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
            AbrirFormHija(new Reportes());
            
        }

        private void btnRcompras_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
            AbrirFormHija(new Reportes());
        }

        private void btnRpagos_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
            AbrirFormHija(new Reportes());
        }

        //comandos para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Mueve ventana al mover el cursor sobre la barra de titulo
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            btnAmpliar.Visible = false;
            btnMaximizar.Visible = true;
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            
        }

        private void btnTurnOff_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea cerrar sesion?", "Salir", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        ///ABRIR PANEL DENTRO DEL CONTENEDOR PRINCIPAL
        ///
        private void AbrirFormHija(object formHija)
        {
            if(this.ContPrincipal.Controls.Count > 0)
                this.ContPrincipal.Controls.RemoveAt(0);
            Form fh =  formHija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.ContPrincipal.Controls.Add(fh);
            this.ContPrincipal.Tag = fh;
            fh.Show();
        }
        private void btnManProveedores_Click(object sender, EventArgs e)
        {
            SubMenuMantenimiento.Visible = false;
            AbrirFormHija(new frmMantProveedores());
        }

        private void btnManCategorias_Click(object sender, EventArgs e)
        {
            SubMenuMantenimiento.Visible = false;
            AbrirFormHija(new frmMantCategorias());
        }


        private void btnManMarcas_Click(object sender, EventArgs e)
        {
            SubMenuMantenimiento.Visible = false;
            AbrirFormHija(new frmMantMarcas());
        }

        private void btnManUsuarios_Click(object sender, EventArgs e)
        {
            SubMenuMantenimiento.Visible = false;
            AbrirFormHija(new frmMantUsuario());
        }

        private void btnMantNegocio_Click(object sender, EventArgs e)
        {
            SubMenuMantenimiento.Visible = false;
            AbrirFormHija(new frmMantNegocio());
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            SubMenuMantenimiento.Visible = false;
            AbrirFormHija(new frmConfiguraciones());
        }
    }
}
