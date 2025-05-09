
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace GestionNegocio
{
    public partial class Productos : Form
    {
        private List<Articulo> listaArticulo;
        private List<Imagen> listaImagen;
        private Articulo seleccionado;
        private int idSeleccionada = 0;
        private int nroImagen = 0;
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            cargarLista();

            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");

        }

        void cargarLista()
        {
            articuloNegocio negocio = new articuloNegocio();
            try
            {
                listaArticulo = negocio.listar();
                dgvProductos.DataSource = listaArticulo;
                ocultarColumnas();
                //loadImagen(listaArticulo[0].imagen.ImagenUrl);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        private void ocultarColumnas()
        {
            dgvProductos.Columns["Imagen"].Visible = false;
            dgvProductos.Columns["Id"].Visible = false;
            dgvProductos.Columns["Descripcion"].Visible = false;
        }

        void cargarImagenes()    ///CARGAR IMAGENES PENDIENTE DE REVISION SOLO CARGA LA IMAGEN DEL PRIMER PRODUCTO
        {                          ///* INTENTAR CARGANDO IMAGENES DE MANERA LOCAL**//
                                       ///TOMA LOS URL COMO FALTA DE PERMISO DE ACCESO
            try
            {
                if (dgvProductos.CurrentRow != null)
                {
                    seleccionado = (Articulo)dgvProductos.CurrentRow.DataBoundItem;
                    if (seleccionado.imagenes.Count > 0)
                    {
                        loadImagen(seleccionado.imagenes[0].ImagenUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadImagen(string imagen) ///revisar
        {
            try
            {
                pbxProducto.Load(imagen);
            }
            catch (Exception)
            {
                pbxProducto.Load("https://static.thenounproject.com/png/2879926-200.png");
            }
        }

        /* private void loadImagen(List<string> lista) revisar
        {

            try
            {
                //MessageBox.Show("cant " + lista.Count());
                pbxProducto.Load(lista[0]);

            }
            catch (Exception)
            {
                pbxProducto.Load("https://static.thenounproject.com/png/2879926-200.png");
            }
        }*/

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                seleccionado = (Articulo)dgvProductos.CurrentRow.DataBoundItem;
                nroImagen = 0;
                idSeleccionada = 0;
                cargarImagenes();
                lblDescripcion.Text = seleccionado.Descripcion;
            }
        }

        private bool validarFiltro() //REVISAR FILTRO LANZA EXCEPCION Y NO FILTRA (con la primera opcion del *cboCriterio*)
        { 
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el campo por favor.");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el criterio por favor");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (!(soloNumeros(txtFiltro.Text)))
                {
                    MessageBox.Show("Debe filtrar por numeros");
                    return true;
                }

            }

            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }

            return true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();

            try
            {
                if (validarFiltro())
                {
                    return;
                }

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;

                dgvProductos.DataSource = negocio.Filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();

            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a: ");
                cboCriterio.Items.Add("Menor a: ");
                cboCriterio.Items.Add("Igual a: ");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con: ");
                cboCriterio.Items.Add("Termina con: ");
                cboCriterio.Items.Add("Contiene: ");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            /*frmAltaProducto alta  = new frmAltaProducto();
            alta.ShowDialog();
            cargarLista();*/
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            
            seleccionado = (Articulo)dgvProductos.CurrentRow.DataBoundItem;
            


            //frmAltaProducto modificar = new frmAltaProducto(seleccionado);
            //modificar.ShowDialog();
            cargarLista();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();
            Articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Seguro que desea eliminarlo?", "Eliminando...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvProductos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.Id);
                    cargarLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void btnBuscadorRapido_Click(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtBuscadorRapido.Text;

            if(filtro != null)
            {
                listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulo;
            }

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaFiltrada;
            ocultarColumnas();
        }
    }
}

