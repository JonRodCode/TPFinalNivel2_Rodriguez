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
        articulo articuloAmodificar = null;
        bool desdeVentanaP = false;
        tools tool = new tools();
        public AltaArticulo()
        {
            InitializeComponent();
            Text = "Agregar Articulo";
        }
        public AltaArticulo(articulo articuloAmodificar)
        {
            InitializeComponent();
            this.articuloAmodificar = articuloAmodificar;
            Text = "Modificar Articulo";
        }
        public AltaArticulo(bool desdeVentanaP)
        {
            InitializeComponent();
            this.desdeVentanaP = desdeVentanaP;
            Text = "Modificar Articulo";
        }
        public AltaArticulo(articulo articuloAmodificar, bool desdeVentanaP)
        {
            InitializeComponent();
            this.articuloAmodificar = articuloAmodificar;
            this.desdeVentanaP = desdeVentanaP;
            Text = "Modificar Articulo";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            articulo nuevo = new articulo();
            negocioArticulo negocio = new negocioArticulo();
            try
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
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregarArticulo(nuevo);
                    MessageBox.Show("Agregado exitosamente");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Close();
            }

        }

        private void txtImagenUrl_Leave(object sender, EventArgs e)
        {
            tool.cargarImagen(pbxImagenAlta,txtImagenUrl.Text);
        }

        private void AltaArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                tool.ocultarCampos(desdeVentanaP, lblDescripcion, lblImagenUrl, lblCategoria, txtDescripcion, txtImagenUrl, cboCategoria);
                if (articuloAmodificar != null)
                {
                    txtCodigo.Text = articuloAmodificar.Codigo;
                    txtNombre.Text = articuloAmodificar.Nombre;
                    txtDescripcion.Text = articuloAmodificar.Descripcion;
                    txtImagenUrl.Text = articuloAmodificar.ImagenUrl;
                    txtPrecio.Text = articuloAmodificar.Precio.ToString();
                    tool.cargarAltaArticuloCbos(cboMarca, cboCategoria,articuloAmodificar);
                    tool.cargarImagen(pbxImagenAlta,txtImagenUrl.Text);

                }
                else
                    tool.cargarAltaArticuloCbos(cboMarca, cboCategoria);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
