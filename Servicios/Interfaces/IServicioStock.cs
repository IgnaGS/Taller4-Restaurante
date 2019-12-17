﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioStock
    {
        Stock ObtenerStock(int idProducto);

        void AddStock(int idProducto, int cantidad);

        void UpdateStock(int idProducto, int cantidad);
    }
}
