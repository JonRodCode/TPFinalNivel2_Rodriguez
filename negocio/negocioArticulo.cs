using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using elementos;
using helper;

namespace negocio
{
    public class negocioArticulo
    {
        public List<articulo> lista_articulos = new List<articulo>();

        public List<articulo> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select A.Id,Codigo, Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca AND C.Id = A.Idcategoria");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    articulo articulo = new articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];


                    categoria_marca marca = new categoria_marca();
                    marca.Id = (int)datos.Lector["IdMarca"];
                    marca.Descripcion = (string)datos.Lector["Marca"];
                    articulo.Marca = marca;


                    categoria_marca categoria = new categoria_marca();
                    categoria.Id = (int)datos.Lector["IdCategoria"];
                    categoria.Descripcion = (string)datos.Lector["Categoria"];
                    articulo.Categoria = categoria;

                    articulo.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                    lista_articulos.Add(articulo);
                }

                return lista_articulos;
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
