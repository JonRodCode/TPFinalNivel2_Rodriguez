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
        getLists getlist = new getLists();
        loads load = new loads();

        List<articulo> listaFiltrada;
        List<articulo> listaDeBusqueda;
        bool busquedaRealizada = false;
        public detalles(List<articulo> listaFiltrada)
        {
            InitializeComponent();
            this.listaFiltrada = listaFiltrada;
        }

        private void detalles_Load(object sender, EventArgs e)

        // Carga la ventana de detalles, con los articulos seleccionados en la ventana principal.
        {
            try
            {
                load.cargarDetalles(dgvDetalles, listaFiltrada, pbxImagen);
                load.cargarBusquedaCbos(cboCampo);
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor seleccione un articulo para ver detalles.");
                Close();
            }
        }

        private void dgvDetalles_SelectionChanged(object sender, EventArgs e)
        
        // Este evento es para cambiar la imagen si seleccionamos otra fila.
        {
            try
            {
                if (dgvDetalles.CurrentRow != null)
                {
                    articulo articulo = (articulo)dgvDetalles.CurrentRow.DataBoundItem;
                    load.cargarImagen(pbxImagen, articulo.ImagenUrl);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        
        // Abre un form de AltaArticulo para agregar un articulo, con todos los datos disponibles.
        // Si se guarda un nuevo articulo, actualiza la lista.
        { 
            AltaArticulo alta = new AltaArticulo();
            List<articulo> listaInicial = new List<articulo>();
            List<articulo> listaFinal = new List<articulo>();
            negocioArticulo negocio = new negocioArticulo();
            try   
            {
                listaInicial = negocio.listar("Default");
                alta.ShowDialog();
                listaFinal = negocio.listar("Default");
                
                if (listaInicial.Count != listaFinal.Count)
                {
                    articulo ultimo = listaFinal[listaFinal.Count -1];
                    listaFiltrada.Add(ultimo);

                    if (busquedaRealizada)
                    {
                        (listaDeBusqueda, busquedaRealizada) = getlist.busquedaAvanzada(cboCampo, cboCriterio, txtFiltro, listaDeBusqueda, listaFiltrada, busquedaRealizada);
                        load.cargarDetalles(dgvDetalles, listaDeBusqueda, pbxImagen);
                    }
                    else
                        load.cargarDetalles(dgvDetalles, listaFiltrada, pbxImagen);
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        private void btnVolverAlMenu_Click(object sender, EventArgs e)

        // Vuelve a la ventana principal
        {
            Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)

        // Modifica 1 articulo con todos sus datos disponibles.
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

                listaDB = negocio.listar("Default");
                foreach (articulo art in listaDB)
                    if(articuloAmodificar.Id == art.Id)
                    {
                        articuloAmodificar = art;
                        break;
                    }

                listaFiltrada[indice] = articuloAmodificar;
                if (busquedaRealizada)
                {
                    (listaDeBusqueda, busquedaRealizada) = getlist.busquedaAvanzada(cboCampo, cboCriterio, txtFiltro, listaDeBusqueda, listaFiltrada, busquedaRealizada);
                    load.cargarDetalles(dgvDetalles, listaDeBusqueda, pbxImagen);
                }
                else
                    load.cargarDetalles(dgvDetalles, listaFiltrada, pbxImagen);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)

        // Elimina 1 articulo. Eliminacion logica.
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
                    MessageBox.Show("Articulo eliminado.");

                    dgvDetalles.DataSource = null;

                    foreach (articulo art in listaFiltrada)
                    {
                        if (art.Id == eliminado.Id)
                        {
                            listaFiltrada.Remove(art);
                            break;
                        }
                    }

                    if (busquedaRealizada)
                    {
                        (listaDeBusqueda, busquedaRealizada) = getlist.busquedaAvanzada(cboCampo, cboCriterio, txtFiltro, listaDeBusqueda, listaFiltrada, busquedaRealizada);
                        load.cargarDetalles(dgvDetalles, listaDeBusqueda, pbxImagen);
                    }
                    else
                        load.cargarDetalles(dgvDetalles, listaFiltrada, pbxImagen);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnCargarAllArticulos_Click(object sender, EventArgs e)

        // Carga en esta ventana, todos los articulos disponibles de la base de datos
        {
            listaFiltrada = getlist.obtenerListaCompleta();
            load.cargarDetalles(dgvDetalles,listaFiltrada,pbxImagen);
        }
        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)

        // Limpia los 3 campos de busqueda.
        {
            txtFiltro.Text = "";
            cboCriterio.Items.Clear();
            load.cargarBusquedaCbos(cboCampo);
            txtFiltro.Enabled = false;
            load.cargarDetalles(dgvDetalles, listaFiltrada, pbxImagen);
            busquedaRealizada = false;
        }
        private void btnBuscar_Click(object sender, EventArgs e)

        // Realiza una busqueda avanzado tomando los campos de busqueda como criterio.
        {
            negocioArticulo negocio = new negocioArticulo();
            try
            {
                (listaDeBusqueda, busquedaRealizada) = getlist.busquedaAvanzada(cboCampo, cboCriterio, txtFiltro,listaDeBusqueda, listaFiltrada, busquedaRealizada);
                load.cargarDetalles(dgvDetalles, listaDeBusqueda, pbxImagen);
            }
            catch (Exception)
            {
                MessageBox.Show("No se encontraron articulos.");
                load.cargarDetalles(dgvDetalles, listaFiltrada, pbxImagen);
            }
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)

        // Agrega en el campo "Criterio" los items correspondientes segun el campo "Campo" elegido
        {
            string seleccionado = cboCampo.SelectedItem.ToString();

            cboCriterio.Items.Clear();
            txtFiltro.Text = "";
            txtFiltro.Enabled = false;

            if (seleccionado == "Código" || seleccionado == "Nombre" || seleccionado == "Marca" || seleccionado == "Categoria" || seleccionado == "Descripción")
            {
                cboCriterio.Items.Add("Empieza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
                if (seleccionado == "Descripción")
                {
                    cboCriterio.Items.Add("Sin descripción");
                }

                else if (seleccionado == "Categoria")
                {
                    cboCriterio.Items.Add("Sin categoria");
                }
            }
            else if (seleccionado == "Url de imagen")
            {
                cboCriterio.Items.Add("Externa");
                cboCriterio.Items.Add("Interna");
                cboCriterio.Items.Add("Sin url");
            }

            else if (seleccionado == "Precio")
            {
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }

        }

        private void cboCriterio_SelectedIndexChanged(object sender, EventArgs e)

        // Habilita o deshabilita el campo "Filtro" segun el campo "Criterio" elegido
        {
            string seleccionado = cboCriterio.SelectedItem.ToString();

            if (seleccionado == "Empieza con" || seleccionado == "Termina con" || seleccionado == "Contiene" || seleccionado == "Mayor a" || seleccionado == "Menor a" || seleccionado == "Igual a")
                txtFiltro.Enabled = true;
            else
            {
                txtFiltro.Text = "";
                txtFiltro.Enabled = false;
            }
                
        }
    }
}