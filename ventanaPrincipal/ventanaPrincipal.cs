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
    public partial class VentanaPrincipal : Form
    {
        getLists getList = new getLists();
        loads load = new loads();

        List<articulo> listaArticulos;
        List<articulo> listaFiltrada = new List<articulo>();

        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listaArticulos = getList.obtenerListaCompleta();
            load.cargar(dgvArticulos,listaArticulos);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) //Listo

        // Esta búsqueda rapida permite filtrar los articulos, unicamente dentro de las tablas visibles
        // (o sea el header que ves, para mas detalles ir a Detalles)
        {
            listaFiltrada = getList.actualizar_filtrar(txtBuscar, listaArticulos);

            load.cargar(dgvArticulos, listaFiltrada);
        }
        private void btnDetalles_Click(object sender, EventArgs e) //Listo

        // Permite ampliar datos disponibles que tenemos sobre los articulos. Ademas de poder acceder
        // a una busqueda avanzada, visualizacion de la imagen, etc.
        {
            List<articulo> listaFiltradaDetalles = new List<articulo>();
            try
            {
                listaFiltradaDetalles = getList.almacenarSeleccionados(dgvArticulos);
                detalles detalle = new detalles(listaFiltradaDetalles);
                detalle.ShowDialog();

                listaArticulos = getList.obtenerListaCompleta();
                listaFiltrada = getList.actualizar_filtrar(txtBuscar, listaArticulos);
                load.cargar(dgvArticulos, listaFiltrada);
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }
        private void btnAgregar_Click(object sender, EventArgs e) //Listo

        // Agrega 1 ariculo, unicamente con los datos principales.
        {
            AltaArticulo alta = new AltaArticulo(true);
            alta.ShowDialog();
            listaArticulos = getList.obtenerListaCompleta();
            listaFiltrada = getList.actualizar_filtrar(txtBuscar, listaArticulos);
            load.cargar(dgvArticulos, listaFiltrada);
        }
        private void btnModificar_Click(object sender, EventArgs e) //Listo
        
        // Modifica 1 articulo a la vez. Solo los datos principales.
        {
            AltaArticulo alta;
            articulo articuloAmodificar;
            try
            {
                if (dgvArticulos.SelectedRows.Count == 1)
                {
                    articuloAmodificar = (articulo)dgvArticulos.SelectedRows[0].DataBoundItem;
                    alta = new AltaArticulo(articuloAmodificar, true);
                    alta.ShowDialog();


                    listaArticulos = getList.obtenerListaCompleta();
                    listaFiltrada = getList.actualizar_filtrar(txtBuscar, listaArticulos);
                    load.cargar(dgvArticulos, listaFiltrada);
                }
                else if (dgvArticulos.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Solo puedes modificar un articulo a la vez, porfavor selecciona 1 solo.");
                }
                else
                {
                    MessageBox.Show("No se encuentra ningun articulo seleccionado.");
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) //Listo

        // "Elimina" 1 o varios articulos. Eliminacion Logica.
        {
            negocioArticulo negocio = new negocioArticulo();
            articulo eliminado;
            List<articulo> listaEliminados = new List<articulo>();
            try
            {
                if (dgvArticulos.SelectedRows.Count == 1)
                {
                    DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminar este articulo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        eliminado = (articulo)dgvArticulos.SelectedRows[0].DataBoundItem;
                        negocio.eliminarArticulo(eliminado);
                        MessageBox.Show("Articulo eliminado");

                        listaArticulos = getList.obtenerListaCompleta();
                        listaFiltrada = getList.actualizar_filtrar(txtBuscar, listaArticulos);
                        load.cargar(dgvArticulos, listaFiltrada);
                    }
                }
                else if (dgvArticulos.SelectedRows.Count > 1)
                {
                    DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminar los articulos seleccionados?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        listaEliminados = getList.almacenarSeleccionados(dgvArticulos);
                        negocio.eliminarArticulos(listaEliminados);
                        MessageBox.Show("Articulos eliminados");

                        listaArticulos = getList.obtenerListaCompleta();
                        listaFiltrada = getList.actualizar_filtrar(txtBuscar, listaArticulos);
                        load.cargar(dgvArticulos, listaFiltrada);
                    }
                }
                else
                {
                    MessageBox.Show("No se encuentra ningun articulo seleccionado.");
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)

        // Limpiamos el cuadro de busqueda.
        {
            txtBuscar.Text = "";
        }

        private void btnOpcionesAvanzadas_Click(object sender, EventArgs e)

        // Accede a otras opciones. En este caso opciones sobre los articulos eliminados.
        {
            OpcionesAvanzadas opciones = new OpcionesAvanzadas();
            opciones.ShowDialog();

            listaArticulos = getList.obtenerListaCompleta();
            listaFiltrada = getList.actualizar_filtrar(txtBuscar, listaArticulos);
            load.cargar(dgvArticulos, listaFiltrada);
        }

        
    }
}
