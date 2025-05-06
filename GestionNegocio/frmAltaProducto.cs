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
    public partial class frmAltaProducto : Form
    {
        private Articulo articulo = null;           //
        private Imagen imagen = null;               // OBJETOS PRIVADOS DE LA CLASE frmAltaProducto
        private List<Imagen> imagenes = null;       // (se utilizan en varias funciones) 

        public frmAltaProducto()
        {
            InitializeComponent();
        }

        public frmAltaProducto(Articulo seleccionado)
        {
            InitializeComponent();
            this.articulo = seleccionado;
            this.imagenes = seleccionado.imagenes;
            // this.imagen.ImagenUrl = seleccionado.imagenes.ToString();  
            Text = "Modificar Articulo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();
            // Articulo producto = new Articulo(); 
            // Imagen imagen = new Imagen();
            ImagenNegocio imgNegocio = new ImagenNegocio();
            try
            {
                if (articulo == null && imagen == null)
                { 
                    articulo = new Articulo(); 
                    imagen = new Imagen();
                } 
                //articulo.Precio.ToString()
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Precio = int.Parse(txtPrecioBase.Text); //convierte el texto en una variable tipo int32 bits
                //en MODIFICAR carga el precio, en el txtBox, junto con los decimales (DB: MONEY) TRAE CONFLICTO AL INTENTAR CONVERTIR EL STRING CON DECIMALES

                articulo.marca = (Marca)cmbMarca.SelectedItem; //casteo explicito: indica el tipo de objeto que se encuentra dentro del Cmbox   
                articulo.categoria = (Categoria)cmbCategoria.SelectedItem; //casteo explicito: indica el tipo de objeto que se encuentra dentro del Cmbox
                articulo.Descripcion = txtDescripcion.Text;
                

                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);

                    MessageBox.Show("Producto modificado exitosamente!");
                }
                else
                {
                    negocio.Agregar(articulo);
                    imagen.IdArticulo = articulo.Id;
                    imagen.ImagenUrl = txtUrlImagen.Text;
                    imgNegocio.AgregarImagen(imagen);
                    /* articulo.Id = neo
                    imagen.IdArticulo = articulo.Id; //MAL PLANTEADA ID DE PRODUCTO CONTIENE VALOR '0' - PENSAR UNA FORMA DE TRAER ID DE DATABASE
                    imgNegocio.AgregarImagen(imagen); */
                    MessageBox.Show("Producto agregado exitosamente!");
                }


                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void frmAltaProducto_Load(object sender, EventArgs e)
        {
            MarcaNegocio marca = new MarcaNegocio();
            CategoriaNegocio categoria = new CategoriaNegocio();
            Imagen imagen = new Imagen();
            try
            {
                cmbMarca.DataSource = marca.listar();
                cmbMarca.ValueMember = "Id";
                cmbMarca.DisplayMember = "Descripcion";
                cmbCategoria.DataSource = categoria.listar();
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.DisplayMember = "Descripcion";

                if(articulo != null )
                {
                    //FALTA URL IMAGEN
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtPrecioBase.Text = articulo.Precio.ToString();
                    cmbMarca.SelectedValue = articulo.marca.Id;
                    cmbCategoria.SelectedValue = articulo.categoria.Id;
                    if(articulo.imagenes != null && articulo.imagenes.Count > 0)// verifica lo que hay dentro de la lista de imagenes del articulo seleccionado
            {
                        txtUrlImagen.Text = articulo.imagenes[0].ImagenUrl.ToString();//carga en el TXTBOX lo que hay dentro de la primera imagen de la lista de imagenes
                    }
                    txtDescripcion.Text = articulo.Descripcion;

                    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            loadImagen(txtUrlImagen.Text);

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

    }
}
