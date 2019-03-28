using System;

namespace ServiciosProfesionales.Entities
{
    public class Ingreso
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ServicioId { get; set; }
        public int FacturaId { get; set; }
        public decimal Importe { get; set; }
        public decimal Iva16 { get; set; }
        public decimal Iva10 { get; set; }
        public decimal Isr10 { get; set; }

        public Servicio Servicio { get; set; }
        public Factura Factura { get; set; }
    }
}