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
using helper;
using negocio;

namespace ventanas
{
    public partial class detalles : Form
    {
        tools tool = new tools();
        List<articulo> listaFiltrada;
        public detalles(List<articulo> listaFiltrada)
        {
            InitializeComponent();
            this.listaFiltrada = listaFiltrada;
        }

        private void detalles_Load(object sender, EventArgs e)
        {
            try
            {
                tool.cargarDetalles(dgvDetalles, listaFiltrada, pbxImagen);
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor seleccione un articulo para ver detalles");
                Close();
            }
        }

        private void dgvDetalles_SelectionChanged(object sender, EventArgs e)
        
        // Este evento es para cambiar la imagen si seleccionamos otra fila
        {
            try
            {
                if (dgvDetalles.CurrentRow != null)
                {
                    articulo articulo = (articulo)dgvDetalles.CurrentRow.DataBoundItem;
                    tool.cargarImagen(pbxImagen, articulo.ImagenUrl);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        
        // Abrimos el form de AltaArticulo, y si guardamos un nuevo articulo lo sumamos a este listado de detalles
        { 
            AltaArticulo alta = new AltaArticulo();
            List<articulo> listaInicial = new List<articulo>();
            List<articulo> listaFinal = new List<articulo>();
            negocioArticulo negocio = new negocioArticulo();
            try   
            {
                listaInicial = negocio.listar();
                alta.ShowDialog();
                listaFinal = negocio.listar();
                
                if (listaInicial.Count != listaFinal.Count)
                {
                    articulo ultimo = listaFinal[listaFinal.Count -1];
                    listaFiltrada.Add(ultimo);
                    
                    tool.cargarDetalles(dgvDetalles, listaFiltrada, pbxImagen);
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        private void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            AltaArticulo alta;
            articulo articuloAmodificar;

            negocioArticulo negocio = new negocioArticulo();
            List<articulo> listaDB = new List<articulo>();
            try
            {
                articuloAmodificar = (articulo)dgvDetalles.SelectedRows[0].DataBoundItem;
                alta = new AltaArticulo(articuloAmodificar);
                alta.ShowDialog();


                int indice = 0;
                for (int i = 0; i != listaFiltrada.Count; i++)
                {
                    if (articuloAmodificar.Id == listaFiltrada[i].Id)
                    {
                        indice = i;
                        break;
                    }
                }

                listaDB = negocio.listar();
                foreach (articulo art in listaDB)
                    if(articuloAmodificar.Id == art.Id)
                    {
                        articuloAmodificar = art;
                        break;
                    }

                listaFiltrada[indice] = articuloAmodificar;
                tool.cargarDetalles(dgvDetalles, listaFiltrada, pbxImagen);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw ex;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            negocioArticulo negocio = new negocioArticulo();
            articulo eliminado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminar este articulo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    eliminado = (articulo)dgvDetalles.SelectedRows[0].DataBoundItem;
                    negocio.eliminarArticulo(eliminado);
                    MessageBox.Show("Articulo eliminado");

                    foreach (articulo art in listaFiltrada)
                    {
                        if (art.Id == eliminado.Id)
                        {
                            listaFiltrada.Remove(art);
                            break;
                        }
                    }
                    tool.cargarDetalles(dgvDetalles,listaFiltrada,pbxImagen);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}