using Dominio;
using GestionNegocio.Resources;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionNegocio.Modales
{
    public partial class mdProveedor : Form
    {
        public Proveedor proveedor{ get; set; }
        public mdProveedor()
        {
            InitializeComponent();
        }

        private void mdProveedor_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvProveedores.Columns)
            {
                if (column.Visible == true)
                {
                    cmbFiltro.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
                }
            }
            cmbFiltro.DisplayMember = "Texto";
            cmbFiltro.ValueMember = "Valor";
            cmbFiltro.SelectedIndex = 0;

            //MOSTRAR TODOS LOS Proveedores
            List<Proveedor> listaProveedores = new ProveedorNegocio().Listar();

            foreach (Proveedor item in listaProveedores)
            {
                dgvProveedores.Rows.Add(new object[] {"",item.IdProveedor,item.Documento,item.RazonSocial});
            }
        }
    }
}
