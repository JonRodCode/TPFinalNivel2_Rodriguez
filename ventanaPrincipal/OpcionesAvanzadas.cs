using elementos;
using helper;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ventanas
{
    public partial class OpcionesAvanzadas : Form
    {
        loads load = new loads();
        getLists getlist = new getLists();
        public OpcionesAvanzadas()
        {
            InitializeComponent();
        }

        private void btnVolverAlMenu_Click(object sender, EventArgs e)

        // Vuelve a la ventana principal
        {
            Close();
        }

        private void btnVerEliminados_Click(object sender, EventArgs e)

        // Despliega todos los articulos que fueron eliminados (Eliminacion Logica)
        {
            load.cargarArticulosEliminados(dgvArticulosEliminados);
            btnRestaurar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)

        // Restaura 1 o mas articulos seleccionados. (Los quita de eliminados y los devuelve con los demas articulos activos)
        {
            negocioArticulo negocio = new negocioArticulo();
            try
            {
                if (dgvArticulosEliminados.SelectedRows.Count == 1)
                {
                    DialogResult respuesta = MessageBox.Show("¿De verdad querés restaurar el articulo seleccionados?", "Restaurando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        articulo seleccionado = (articulo)dgvArticulosEliminados.SelectedRows[0].DataBoundItem;
                        negocio.restaurarArticulo(seleccionado);
                        MessageBox.Show("Articulo restaurado.");
                    }
                }
                else if (dgvArticulosEliminados.SelectedRows.Count > 1)
                {
                    DialogResult respuesta = MessageBox.Show("¿De verdad querés restaurar los articulos seleccionados?", "Restaurando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        List<articulo> listaRestaurados = getlist.almacenarSeleccionados(dgvArticulosEliminados);
                        negocio.restaurarArticulos(listaRestaurados);
                        MessageBox.Show("Articulos restaurados.");
                    }
                }
                load.cargarArticulosEliminados(dgvArticulosEliminados);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)

        // Elimina de manera permanente él o los articulos seleccionados (Eliminacion Fisica)
        {
            try
            {
                negocioArticulo negocio = new negocioArticulo();
                if (dgvArticulosEliminados.SelectedRows.Count == 1)
                {
                    DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminar este articulo? No podrás recuperarlo nunca.", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        articulo seleccionado = (articulo)dgvArticulosEliminados.SelectedRows[0].DataBoundItem;
                        negocio.eliminarArticuloParaSiempre(seleccionado);
                        MessageBox.Show("Articulo eliminado.");
                    }
                }
                else if (dgvArticulosEliminados.SelectedRows.Count > 1)
                {
                    DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminar los articulos seleccionados?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        List<articulo> listaEliminados = getlist.almacenarSeleccionados(dgvArticulosEliminados);
                        negocio.eliminarArticulosParaSiempre(listaEliminados);
                        MessageBox.Show("Articulos eliminados.");
                    }
                }

                load.cargarArticulosEliminados(dgvArticulosEliminados);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
