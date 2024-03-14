using elementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ventanaPrincipal
{
    public class tools
    {
        public void ocultarTablas(DataGridView grilla)
        {
            grilla.Columns["Id"].Visible = false;
            grilla.Columns["Descripcion"].Visible = false;
            grilla.Columns["Categoria"].Visible = false;
            grilla.Columns["ImagenUrl"].Visible = false;
        }

        public void filtrar(string text, List<articulo> listaArticulos)
        {
           
        }
    }
}
