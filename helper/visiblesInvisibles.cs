using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace helper
{
    public class visiblesInvisibles

    // Esta clase contiene metodo para ocultar tablas o campos
    {
        public void ocultarTablas(DataGridView grilla)

        // Oculta tablas predefinidas, usado en ventana Principal
        {
            grilla.Columns["Id"].Visible = false;
            grilla.Columns["Descripcion"].Visible = false;
            grilla.Columns["Categoria"].Visible = false;
            grilla.Columns["ImagenUrl"].Visible = false;
        }
        public void ocultarTablas(DataGridView grilla, string columna)

        // Oculta 1 tabla recibida, usado en ventana Detalles
        {
            grilla.Columns[columna].Visible = false;
        }

        public void ocultarCampos(bool dVP, Label lbl1, Label lbl2, Label lbl3, TextBox txt1, TextBox txt2, ComboBox cbo1)
        
        // Oculta los campos No obligatorios al agregar o modificar un articlo desde ventana Principal
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
    }
}
