using System.Collections.Generic;

namespace ServiciosProfesionales.Entities
{
    public class Contribuyente
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Rfc { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}