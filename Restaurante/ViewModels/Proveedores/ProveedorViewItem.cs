using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Restaurante.ViewModels.Proveedores
{
    public class ProveedorViewItem
    {
        public int Id { get; set; }
        public string Descripcion { set; get; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaAlta { get; set; }

        public ProveedorViewItem()
        {

        }

        public ProveedorViewItem(Proveedor proveedor)
        {
            Id = proveedor.Id;
            Descripcion = proveedor.Descripcion;
            Direccion = proveedor.Direccion;
            Mail = proveedor.Mail;
            Telefono = proveedor.Telefono;
            FechaAlta = proveedor.FechaAlta;
        }
    }
}