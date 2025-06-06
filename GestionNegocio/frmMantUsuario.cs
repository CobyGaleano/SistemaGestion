using GestionNegocio.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocio;
using Dominio;


namespace GestionNegocio
{
    public partial class frmMantUsuario : Form
    {
        public frmMantUsuario()
        {
            InitializeComponent();
        }

        private void frmMantUsuario_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 2, Texto = "Inactivo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;

            List<Rol> listaRol = new RolNegocio().Listar();

            foreach (Rol item in listaRol)
            {
                {
                    cmbRol.Items.Add(new OpcionCombo() {Valor = item.IdRol, Texto = item.Descripcion });

                    cmbRol.DisplayMember = "Texto";
                    cmbRol.ValueMember = "Valor";
                    cmbRol.SelectedIndex = 0;

                }
            }
        }
    }
}
