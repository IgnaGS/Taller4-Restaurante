using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Catalogo
    {
        public int Id { get; set; }

        [ForeignKey("Proveedor")]
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
