using SQLite;

namespace MiAppCrud.Models
{
    public class Orden
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        // Relación con Producto
        public int ProductoId { get; set; }
    }
}
