using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using elementos;
using accesoDB;
using helper;
using negocio;

namespace ventanas
{
    public partial class AltaArticulo : Form
    {
        loads load = new loads();
        visiblesInvisibles visibleInvisible = new visiblesInvisibles();
        validations validation = new validations();

        articulo articuloAmodificar = null;
        bool desdeVentanaP = false;
        public AltaArticulo()

        //Inicializacion desde Detalles, para agregar un articulo
        {
            InitializeComponent();
            Text = "Agregar Articulo";
        }
        public AltaArticulo(articulo articuloAmodificar)

        //Inicializacion desde Detalles, para modificar un articulo
        {
            InitializeComponent();
            this.articuloAmodificar = articuloAmodificar;
            Text = "Modificar Articulo";
        }
        public AltaArticulo(bool desdeVentanaP)

        //Inicializacion desde ventana Principal, para agregar un articulo
        {
            InitializeComponent();
            this.desdeVentanaP = desdeVentanaP;
            Text = "Agregar Articulo";
        }
        public AltaArticulo(articulo articuloAmodificar, bool desdeVentanaP)

        //Inicializacion desde ventana Principal, para modificar un articulo
        {
            InitializeComponent();
            this.articuloAmodificar = articuloAmodificar;
            this.desdeVentanaP = desdeVentanaP;
            Text = "Modificar Articulo";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        // Vuelve a la ventana anterior
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)

        // Agrega el articulo nuevo o actualiza el articulo modificado
        {
            articulo nuevo = new articulo();
            negocioArticulo negocio = new negocioArticulo();
            try
            {
                if (validation.validarAltaArticulo(txtCodigo,txtNombre,txtPrecio,cboMarca))
                {
                    if (articuloAmodificar != null)
                        nuevo = articuloAmodificar;

                    nuevo.Codigo = txtCodigo.Text;
                    nuevo.Nombre = txtNombre.Text;
                    nuevo.Descripcion = txtDescripcion.Text;
                    nuevo.ImagenUrl = txtImagenUrl.Text;
                    nuevo.Precio = decimal.Parse(txtPrecio.Text);
                    nuevo.Marca = (categoria_marca)cboMarca.SelectedItem;
                    nuevo.Categoria = (categoria_marca)cboCategoria.SelectedItem;

                    if (nuevo.Id != 0)
                    {
                        negocio.modificarArticulo(nuevo);
                        MessageBox.Show("Modificado exitosamente.");
                    }
                    else
                    {
                        negocio.agregarArticulo(nuevo);
                        MessageBox.Show("Agregado exitosamente.");
                    }
                    Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void txtImagenUrl_Leave(object sender, EventArgs e)

        // Carga la imagen correspondiente luego de pasar por el cammpo "Url de Imagen"
        {
            load.cargarImagen(pbxImagenAlta,txtImagenUrl.Text);
        }

        private void AltaArticulo_Load(object sender, EventArgs e)
        
        // Carga la ventana mostrando u ocultando campos segun de donde se llamo (Detalles o Ventana Principal)
        {
            try
            {
                visibleInvisible.ocultarCampos(desdeVentanaP, lblDescripcion, lblImagenUrl, lblCategoria, txtDescripcion, txtImagenUrl, cboCategoria);
                if (articuloAmodificar != null)
                {
                    txtCodigo.Text = articuloAmodificar.Codigo;
                    txtNombre.Text = articuloAmodificar.Nombre;
                    txtDescripcion.Text = articuloAmodificar.Descripcion;
                    txtImagenUrl.Text = articuloAmodificar.ImagenUrl;
                    txtPrecio.Text = articuloAmodificar.Precio.ToString();
                    load.cargarAltaArticuloCbos(cboMarca, cboCategoria,articuloAmodificar);
                    load.cargarImagen(pbxImagenAlta,txtImagenUrl.Text);
                }
                else
                    load.cargarAltaArticuloCbos(cboMarca, cboCategoria);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
