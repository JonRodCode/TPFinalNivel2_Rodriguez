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
        List<articulo> listaArticulos;
        tools tool = new tools();

        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listaArticulos = tool.obtenerListaCompleta();
            tool.cargar(dgvArticulos,listaArticulos);
        }

        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) //Listo

        // Esta búsqueda rapida nos permite filtrar los articulos, unicamente dentro de las tablas visibles
        // (o sea el header que ves, para mas detalles ir a Detalles)
        {
            string filtro = txtBuscar.Text;
            List<articulo> listaFiltrada = new List<articulo>();

            if (filtro.Count() > 0)
                listaFiltrada = listaArticulos.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) || x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Precio.ToString().Contains(filtro.ToString()));

            else
                listaFiltrada = listaArticulos;

            tool.cargar(dgvArticulos, listaFiltrada);
        }

        private void btnDetalles_Click(object sender, EventArgs e) //Listo

        // Nos permite ampliar la cantidad de datos que tenemos sobre los articulos.
        // Sé que pude ir directamente aca como "Ventana Principal",
        // pero preferi separarlo para asi tener una version simple con los datos más importantes, como inicio.
        {
            List<articulo> listaFiltrada = new List<articulo>();
            try
            {
                listaFiltrada = tool.almacenarSeleccionados(dgvArticulos);
                detalles detalle = new detalles(listaFiltrada);
                detalle.ShowDialog();

                listaArticulos = tool.obtenerListaCompleta();
                tool.cargar(dgvArticulos, listaArticulos);
                txtBuscar.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }
        private void btnAgregar_Click(object sender, EventArgs e) //Listo
        {
            AltaArticulo alta = new AltaArticulo(true);
            alta.ShowDialog();
            listaArticulos = tool.obtenerListaCompleta();
            tool.cargar(dgvArticulos, listaArticulos);
            txtBuscar.Text = "";
        }
        private void btnModificar_Click(object sender, EventArgs e)
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

                    listaArticulos = tool.obtenerListaCompleta();
                    tool.cargar(dgvArticulos, listaArticulos);
                    txtBuscar.Text = "";
                }
                else if (dgvArticulos.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Solo puedes modificar un articulo a la vez, porfavor selecciona 1 solo");
                }
                else
                {
                    MessageBox.Show("No se encuentra ningun articulo seleccionado");
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)

        // "Elimina" 1 o varios articulos
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

                        listaArticulos = tool.obtenerListaCompleta();
                        tool.cargar(dgvArticulos, listaArticulos);
                        txtBuscar.Text = "";
                    }
                }
                else if (dgvArticulos.SelectedRows.Count > 1)
                {
                    DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminar los articulos seleccionados?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        listaEliminados = tool.almacenarSeleccionados(dgvArticulos);
                        negocio.eliminarArticulos(listaEliminados);
                        MessageBox.Show("Articulos eliminados");

                        listaArticulos = tool.obtenerListaCompleta();
                        tool.cargar(dgvArticulos, listaArticulos);
                        txtBuscar.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("No se encuentra ningun articulo seleccionado");
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
