﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioCatalogo
    {
        IEnumerable<Catalogo> ObtenerCatalogos(int idProveedor);

        Catalogo ObtenerCatalogo(int idProveedor, int idProducto);

        void AddCatalogo(int idProducto, int idProveedor);

        void DeleteCatalogo(int idProducto, int idProveedor);
    }
}
