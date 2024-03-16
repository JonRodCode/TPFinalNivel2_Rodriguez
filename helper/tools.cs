using elementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using System.ComponentModel;

namespace helper
{
    public class tools
    {
        public void ocultarTablas(DataGridView grilla)

        // Oculta tablas predefinidas
        {
            grilla.Columns["Id"].Visible = false;
            grilla.Columns["Descripcion"].Visible = false;
            grilla.Columns["Categoria"].Visible = false;
            grilla.Columns["ImagenUrl"].Visible = false;
        }
        public void ocultarTablas(DataGridView grilla, string columna)

        // Oculta 1 tabla recibida
        {
            grilla.Columns[columna].Visible = false;
        }

        public void ocultarCampos(bool dVP,Label lbl1, Label lbl2,Label lbl3, TextBox txt1, TextBox txt2, ComboBox cbo1)
        {
            if (dVP)
            {
                lbl1.Visible = false;
                lbl2.Visible = false;
                lbl3.Visible = false;
                txt1.Visible = false;
                txt2.Visible = false;
                cbo1.Visible = false;
            }
        }

        public void filtrar(string text, List<articulo> listaArticulos)
        {
           
        }
        public void cargarImagen(PictureBox pbx,string url)

        //Carga la imagen de una url, si no puede carga otra por default
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

        public List<articulo> obtenerListaCompleta()
        {
            negocioArticulo negocio = new negocioArticulo();
            List<articulo> listaArticulos = new List<articulo>();
            listaArticulos = negocio.listar();

            return listaArticulos;
        }

        public void cargar(DataGridView grilla, List<articulo> listaCompleta)
        {
            // Carga la ventana principal con datos desde la DB

            grilla.DataSource = null;
            grilla.DataSource = listaCompleta;
            grilla.Columns["Precio"].DefaultCellStyle.Format = "0.00";
            ocultarTablas(grilla);

        }

        public void cargarDetalles(DataGridView grilla, List<articulo> lista, PictureBox imgBox)
        {
            // Carga la ventana de Detalles
            try
            {
                grilla.DataSource = null;
                grilla.DataSource = lista;
                articulo articulo = (articulo)grilla.SelectedRows[0].DataBoundItem;
                ocultarTablas(grilla, "Id");
                grilla.Columns["Precio"].DefaultCellStyle.Format = "0.00";
                cargarImagen(imgBox, articulo.ImagenUrl);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void cargarAltaArticuloCbos(ComboBox mar, ComboBox cat)
        {
            // Carga la ventana de AltaArticulo para agregar

            negocioCategoria_marca marcas_categorias = new negocioCategoria_marca();

            mar.DataSource = marcas_categorias.listar("MARCAS");
            mar.SelectedIndex = -1;
            cat.DataSource = marcas_categorias.listar("CATEGORIAS");
            cat.SelectedIndex = -1;
        }
        public void cargarAltaArticuloCbos(ComboBox mar, ComboBox cat,articulo art)
        {
            // Carga la ventana de AltaArticulo para modificar

            negocioCategoria_marca marcas_categorias = new negocioCategoria_marca();

            mar.DataSource = marcas_categorias.listar("MARCAS");
            mar.ValueMember = "Id";
            mar.DisplayMember = "Descripcion";
            mar.SelectedValue = art.Marca.Id;

            cat.DataSource = marcas_categorias.listar("CATEGORIAS");
            cat.ValueMember = "Id";
            cat.DisplayMember = "Descripcion";
            cat.SelectedValue = art.Categoria.Id;
        }

        public List<articulo> almacenarSeleccionados(DataGridView grilla)
        {
            List<articulo> listaFiltrada = new List<articulo>();
            try
            {
                for (int i = 0; i < grilla.SelectedRows.Count; i++)
                {
                    articulo art;
                    art = (articulo)grilla.SelectedRows[i].DataBoundItem;
                    listaFiltrada.Add(art);
                }
                listaFiltrada = listaFiltrada.OrderBy(x => x.Id).ToList();
                return listaFiltrada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
