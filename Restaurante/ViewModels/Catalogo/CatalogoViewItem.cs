using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using Servicios;
using Servicios.Interfaces;

namespace Restaurante.ViewModels.Catalogos
{
    public class CatalogoViewItem
    {
        public int Id { get; set; }
        public string Proveedor { get; set; }
        public string Producto { get; set; }

        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }

        public CatalogoViewItem()
        {
        }

        public CatalogoViewItem(Catalogo Catalogo)
        {
            Id = Catalogo.Id;
            IdProveedor = Catalogo.Proveedor.Id;
            IdProducto = Catalogo.Producto.Id;
            Proveedor = Catalogo.Proveedor.Descripcion;
            Producto = Catalogo.Producto.Descripcion;
        }
    }
}