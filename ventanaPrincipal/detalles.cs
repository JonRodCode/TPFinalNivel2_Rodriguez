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
    public partial class detalles : Form
    {
        List<articulo> listaFiltrada;
        public detalles(List<articulo> listaFiltrada)
        {
            InitializeComponent();
            this.listaFiltrada = listaFiltrada;
        }


        private void detalles_Load(object sender, EventArgs e)
        {
            dgvDetalles.DataSource = listaFiltrada;
            
        }
    }
}
