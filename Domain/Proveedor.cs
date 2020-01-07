using System;

namespace Domain
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Descripcion { set; get; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Disponible { get; set; }

      //  public ICollection<Producto> Productos { get; set; }
    }
}
