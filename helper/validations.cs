using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace helper
{
    public class validations

    //Esta clase contiene metodos para validar algunas situaciones
    {
        public bool validarCamposBusqueda(ComboBox campo, ComboBox criterio, TextBox filtro)

        // Valida los campos de la Busqueda avanzada en la ventana Detalles
        {
            if (campo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el campo para filtrar.");
                return false;
            }

            else if (criterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el criterio para filtrar.");
                return false;
            }
            else
            {
                if (filtro.Text == "" && (criterio.Text == "Empieza con" || criterio.Text == "Termina con" || criterio.Text == "Contiene" || criterio.Text == "Mayor a" || criterio.Text == "Menor a" || criterio.Text == "Igual a"))
                {
                    MessageBox.Show("Por favor, ingrese un filtro.");
                    return false;
                }
                else if (campo.Text == "Precio" && (!soloValorDecimal(filtro.Text)))
                {

                    MessageBox.Show("Por favor, ingrese un valor númerico con formato válido");
                    return false;
                }
            }
            return true;
        }

        public bool soloValorDecimal(string texto)

        // Valida que el texto sea solo de valor decimal
        {
            int validarComa = 0;
            foreach (char character in texto)
            {
                if (character == ',')
                    validarComa++;
                if ((char.IsDigit(character) || character == ',') && validarComa < 2)
                {
                    continue;
                }
                else { return false; }
            }
            return true;
        }

        public bool validarAltaArticulo(TextBox txtCodigo, TextBox txtNombre, TextBox txtPrecio, ComboBox cboMarca)

        // Valida los campos principales para la ventana AltaArticulo, para agregar o modificar articulos
        {
            if (txtCodigo.Text == "" || txtNombre.Text == "" || txtPrecio.Text == "" || cboMarca.SelectedItem is null)
            {
                MessageBox.Show("Por favor, completa los campos obligatorios");
                return false;
            }
            else if (!(soloValorDecimal(txtPrecio.Text)))
            {
                MessageBox.Show("Por favor, ingrese en el campo ''Precio'' un valor númerico con formato válido");
                return false;
            }
            return true;
        }
    }
}
