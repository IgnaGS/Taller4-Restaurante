﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioProducto
    {
        IEnumerable<Producto> ObtenerProductos();

        void AddProducto(string descripcion, double precio);

        void UpdateProducto(int id, string descripcion, double precio);
    }
}
