namespace Domain
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Disponible { get; set; }

      //  public virtual ICollection<Proveedor> Proveedores {get; set; }
    }
}
