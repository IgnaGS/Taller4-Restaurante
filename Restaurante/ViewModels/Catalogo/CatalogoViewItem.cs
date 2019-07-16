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
        public Proveedor Proveedor { get; set; }
        public Producto Producto { get; set; }


        public CatalogoViewItem()
        {
        }

        public CatalogoViewItem(Catalogo Catalogo)
        {
            Id = Catalogo.Id;
            Proveedor = Catalogo.Proveedor;
            Producto = Catalogo.Producto;
        }
    }
}