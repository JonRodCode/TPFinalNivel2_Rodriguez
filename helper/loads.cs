using elementos;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace helper
{
    public class loads

    //Esta clase sirve para lo que son las cargas de de ventanas, cargas de ComboBox y cargar imagen
    {
        visiblesInvisibles visibleInvisible = new visiblesInvisibles();
        getLists getList = new getLists();
        public void cargarImagen(PictureBox pbx, string url)

        // Carga la imagen de una url, si no puede carga una imagen interna por default
        {
            try
            {
                pbx.Load(url);
            }
            catch (Exception)
            {
                pbx.Load("C:\\imagesApp\\ImagenNoD.png");
            }

        }


        public void cargar(DataGridView grilla, List<articulo> listaCompleta)
            
        // Carga la ventana principal con datos desde la DB.
        {

            grilla.DataSource = null;
            grilla.DataSource = listaCompleta;
            grilla.Columns["Precio"].DefaultCellStyle.Format = "0.00";
            visibleInvisible.ocultarTablas(grilla);

        }

        public void cargarDetalles(DataGridView grilla, List<articulo> lista, PictureBox imgBox)
        
        // Carga la ventana de Detalles
        {
            try
            {
                grilla.DataSource = null;
                grilla.DataSource = lista;
                articulo articulo = (articulo)grilla.SelectedRows[0].DataBoundItem;
                visibleInvisible.ocultarTablas(grilla, "Id");
                cargarImagen(imgBox, articulo.ImagenUrl);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void cargarArticulosEliminados(DataGridView grilla)

        // Carga el DataGridView de opciones avanzadas, al hacer click en el boton "Ver"
        {
            try
            {
                List<articulo> lista = getList.obtenerListaEliminados();
                grilla.DataSource = null;
                grilla.DataSource = lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cargarAltaArticuloCbos(ComboBox mar, ComboBox cat)
        
        // Carga la ventana AltaArticulo con los items de sus ComboBox
        {

            negocioCategoria_marca marcas_categorias = new negocioCategoria_marca();

            mar.DataSource = marcas_categorias.listar("MARCAS");
            mar.SelectedIndex = -1;
            cat.DataSource = marcas_categorias.listar("CATEGORIAS");
            cat.SelectedIndex = -1;
        }
        public void cargarAltaArticuloCbos(ComboBox mar, ComboBox cat, articulo art)
            
        // Carga la ventana AltaArticulo para modificar, con la seleccion de los comboBox segun el articulo a modificar
        {

            negocioCategoria_marca marcas_categorias = new negocioCategoria_marca();

            mar.DataSource = marcas_categorias.listar("MARCAS");
            mar.ValueMember = "Id";
            mar.DisplayMember = "Descripcion";
            mar.SelectedValue = art.Marca.Id;

            cat.DataSource = marcas_categorias.listar("CATEGORIAS");
            if (!(art.Categoria is null))
            {
                cat.ValueMember = "Id";
                cat.DisplayMember = "Descripcion";
                cat.SelectedValue = art.Categoria.Id;
            }
            else
                cat.SelectedIndex = -1;
        }


        public void cargarBusquedaCbos(ComboBox cboCampo)

        // Carga los Items del ComboBox Campo, se usa al cargar la ventana Detalles
        {
            cboCampo.Items.Clear();
            cboCampo.Items.Add("Código");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoria");
            cboCampo.Items.Add("Url de imagen");
            cboCampo.Items.Add("Precio");
        }
    }
}
