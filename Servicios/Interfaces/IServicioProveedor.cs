﻿using System.Collections.Generic;
using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioProveedor
    {
        IEnumerable<Proveedor> ObtenerProveedores();

        void AddProveedor(string descripcion, string direccion, string mail, string telefono, string disponible);

        void UpdateProveedor(int id, string descripcion, string direccion, string mail, string telefono, string disponible); 

        Proveedor ObtenerProveedor(int id);
    }
}
