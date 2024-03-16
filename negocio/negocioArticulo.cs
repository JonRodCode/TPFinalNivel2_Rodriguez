using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using elementos;
using accesoDB;
using helperDB;
using System.Data.SqlTypes;

namespace negocio
{
    public class negocioArticulo
    {
        toolsDB toolDB = new toolsDB();
        public List<articulo> lista_articulos;

        public List<articulo> listar()
        {
            lista_articulos = new List<articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select A.Id,Codigo, Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca AND C.Id = A.Idcategoria AND not Nombre like '/oculto\\%'");
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

        public void agregarArticulo(articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            string consulta;
            try
            {
                consulta = "insert into ARTICULOS(Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@ImagenUrl,@Precio)";
                toolDB.setearAllParammetros(datos, nuevo);

                datos.setearConsulta(consulta);
                datos.ejecutarAccion();
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

        public void modificarArticulo(articulo modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            string consulta;
            try
            {
                consulta = "update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where id = @Id";
                
                toolDB.setearAllParammetros(datos,modificado);
                datos.setearConsulta(consulta);
                datos.ejecutarAccion();
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

        public void eliminarArticuloParaSiempre(articulo eliminado)
        {
            AccesoDatos datos = new AccesoDatos();
            string consulta;
            try
            {
                consulta = "delete From ARTICULOS where id = @Id";
                datos.setearParametro("@Id", eliminado.Id.ToString());
                datos.setearConsulta(consulta);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}
        }
        public void eliminarArticulo(articulo eliminado)
        {
            AccesoDatos datos = new AccesoDatos();
            string consulta;
            string nombre;
            try
            {
                nombre = "/oculto\\" + eliminado.Nombre;
                consulta = "update ARTICULOS set Nombre = @nombre where id = @Id";
                datos.setearParametro("@nombre", nombre);
                datos.setearParametro("@Id", eliminado.Id.ToString());
                datos.setearConsulta(consulta);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex; 
            }
            finally { datos.cerrarConexion(); }
        }
        public void eliminarArticulos(List<articulo> listaEliminados)
        {
            foreach(articulo art in listaEliminados)
            {
                eliminarArticulo(art);
            }
        }
    }
}
