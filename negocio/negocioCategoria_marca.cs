using accesoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using elementos;

namespace negocio
{
    public class negocioCategoria_marca
    {
        List<categoria_marca> lista;

        public List<categoria_marca> listar(string cat_mar)
        {
            lista = new List<categoria_marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta;
                consulta = "select * from "+cat_mar;
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    categoria_marca categoria_marca = new categoria_marca();
                    categoria_marca.Id = (int)datos.Lector["Id"];
                    categoria_marca.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(categoria_marca);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }


    }
}
