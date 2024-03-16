﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elementos
{
    public class articulo
    {
        public int Id { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public categoria_marca Marca { get; set; }
        public categoria_marca Categoria { get; set; }

        [DisplayName("Url de imagen")]
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }

    }
}
