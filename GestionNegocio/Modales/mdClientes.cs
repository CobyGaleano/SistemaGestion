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

namespace GestionNegocio.Modales
{
    public partial class mdClientes : Form
    {
        public mdClientes()
        {
            InitializeComponent();
        }

        private void mdClientes_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvClientes.Columns)
            {
                if (column.Visible == true)
                {
                    cmbFiltro.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
                }
            }
            cmbFiltro.DisplayMember = "Texto";
            cmbFiltro.ValueMember = "Valor";
            cmbFiltro.SelectedIndex = 0;
        }
    }
}
