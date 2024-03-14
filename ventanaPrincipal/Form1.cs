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
using elementos;

namespace ventanaPrincipal
{
    public partial class Form1 : Form
    {
        List<articulo> listaArticulos;
        tools tool = new tools();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            tool.ocultarTablas(dgvArticulos);
            
        }

        private void cargar()
        {
            negocioArticulo negocio = new negocioArticulo();
            listaArticulos = negocio.listar();
            dgvArticulos.DataSource = listaArticulos;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text;
            List<articulo> listaFiltrada = new List<articulo>();

            if (filtro.Count() > 0)
                listaFiltrada = listaArticulos.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) || x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()));

            else
                listaFiltrada = listaArticulos;

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            tool.ocultarTablas(dgvArticulos);
        } //Listo

        private void btnDetalles_Click(object sender, EventArgs e) //Listo
        {
            List<articulo> listaFiltrada = new List<articulo>();
            try
            {
                for (int i = 0; i < dgvArticulos.SelectedRows.Count; i++)
                {
                    articulo art;
                    art = (articulo)dgvArticulos.SelectedRows[i].DataBoundItem;
                    listaFiltrada.Add(art);
                }
                detalles detalle = new detalles(listaFiltrada);
                detalle.ShowDialog();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        //

    }
}
