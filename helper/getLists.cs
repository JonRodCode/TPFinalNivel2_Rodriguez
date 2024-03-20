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
    public class getLists

    // Esta clase retorna varias listas que son utiles para el desarrolo de la app.
    {
        validations validation = new validations();
        public List<articulo> almacenarSeleccionados(DataGridView grilla)

        // Almacena los articulos seleccionados en una lista
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

        public List<articulo> obtenerListaCompleta()

        // Obtiene una lista con todos los articulos disponibles de la DB
        {
            negocioArticulo negocio = new negocioArticulo();
            List<articulo> listaArticulos = new List<articulo>();
            listaArticulos = negocio.listar("Default");

            return listaArticulos;
        }
        public List<articulo> actualizar_filtrar(TextBox txt, List<articulo> listaCompleta)

        // Segun una lista, y un filtro dado, retorna una lista con los articulos que coincidan o contengan el filtro
        {
            string filtro = txt.Text;
            List<articulo> lista = new List<articulo>();

            if (filtro.Count() > 0)
                lista = listaCompleta.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) || x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Precio.ToString().Contains(filtro.ToString()));

            else
                lista = listaCompleta;

            return lista;

        }

        public List<articulo> obtenerListaEliminados()

        // Obtiene una lista con todos los articulos NO disponbles (eliminados logicamente) de la DB
        {
            negocioArticulo negocio = new negocioArticulo();
            List<articulo> listaArticulos = new List<articulo>();
            string consulta = negocio.consultaLectura.Replace(" not ", " ");
            listaArticulos = negocio.listar(consulta);

            return listaArticulos;
        }
        public List<articulo> listarFiltro(string campo, string criterio, string filtro, List<articulo> lista)

        // Usado en Detalles, retorna una lista filtrada segun los campos de busqueda. Como Detalles usa una lista
        // especifica como base, se hace una comparacion entre esa lista y la lista filtrada para obtener la lista final
        {
            negocioArticulo negocio = new negocioArticulo();
            List<articulo> lista_articulos = negocio.lista_articulos;
            string consultaLectura = negocio.consultaLectura;
            try
            {

                switch (campo)
                {
                    case "Código":

                        switch (criterio)
                        {
                            case "Empieza con":
                                consultaLectura += " AND Codigo like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consultaLectura += " AND Codigo like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consultaLectura += " AND Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Nombre":

                        switch (criterio)
                        {
                            case "Empieza con":
                                consultaLectura += " AND Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consultaLectura += " AND Nombre like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consultaLectura += " AND Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Descripción":

                        switch (criterio)
                        {
                            case "Empieza con":
                                consultaLectura += " AND A.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consultaLectura += " AND A.Descripcion like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consultaLectura += " AND A.Descripcion like '%" + filtro + "%'";
                                break;
                            case "Sin descripción":
                                consultaLectura += " AND A.Descripcion like ''";
                                break;
                        }
                        break;

                    case "Marca":

                        switch (criterio)
                        {
                            case "Empieza con":
                                consultaLectura += " AND M.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consultaLectura += " AND M.Descripcion like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consultaLectura += " AND M.Descripcion like '%" + filtro + "%'";
                                break;

                        }
                        break;

                    case "Categoria":

                        switch (criterio)
                        {
                            case "Empieza con":
                                consultaLectura += " AND C.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consultaLectura += " AND C.Descripcion like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consultaLectura += " AND C.Descripcion like '%" + filtro + "%'";
                                break;
                            case "Sin categoria":
                                consultaLectura += " AND IdCategoria = 0";
                                break;
                        }
                        break;

                    case "Url de imagen":
                        switch (criterio)
                        {
                            case "Externa":
                                consultaLectura += " AND ImagenUrl like 'https%'";
                                break;
                            case "Interna":
                                consultaLectura += " AND not ImagenUrl like 'https%' AND not ImagenUrl like '' AND ImagenUrl like '%:\\%'";
                                break;
                            case "Sin url":
                                consultaLectura += " AND not ImagenUrl like 'https%' AND not ImagenUrl like '%:\\%'";
                                break;
                        }
                        break;

                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consultaLectura += " AND Precio > " + filtro;
                                break;
                            case "Menor a":
                                consultaLectura += " AND Precio < " + filtro;
                                break;
                            case "Igual a":
                                consultaLectura += " AND Precio = " + filtro;
                                break;
                        }
                        break;
                }

                List<articulo> listaFiltrada = new List<articulo>();

                lista_articulos = negocio.listar(consultaLectura);

                for (int i = 0; i < lista_articulos.Count; i++)
                {
                    for (int j = 0; j < lista.Count; j++)
                    {
                        if (lista_articulos[i].Id == lista[j].Id)
                        {
                            listaFiltrada.Add(lista[j]);
                            break;
                        }
                    }
                }
                return listaFiltrada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public (List<articulo>, bool) busquedaAvanzada(ComboBox cboCampo, ComboBox cboCriterio, TextBox txtFiltro, List<articulo> listaDeBusqueda, List<articulo> listaFiltrada, bool busquedaRealizada)

        // Retorna una lista filtrada segun los campos de busqueda, posterior a validar esos campos. Tambien retorna
        // "true" si efectivamente se pudo realizar la busqueda.
        {
            negocioArticulo negocio = new negocioArticulo();
            if (validation.validarCamposBusqueda(cboCampo, cboCriterio, txtFiltro))
            {
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;

                if (campo == "Precio")
                {
                    foreach (char character in filtro)
                    {
                        if (character == ',')
                            filtro = filtro.Replace(',', '.');
                    }
                }

                listaDeBusqueda = listarFiltro(campo, criterio, filtro, listaFiltrada);
                busquedaRealizada = true;

            }
            return (listaDeBusqueda, busquedaRealizada);
        }
    }
}
