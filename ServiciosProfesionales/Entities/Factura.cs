using System;
using System.Collections.Generic;

namespace ServiciosProfesionales.Entities
{
    public class Factura
    {
        public int Id { get; set; }
        public string FolioFiscal { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int ContribuyenteId { get; set; }
        public int ClienteId { get; set; }
        
        public ICollection<Concepto> Conceptos { get; set; }
        public Contribuyente Contribuyente { get; set; }
        public Cliente Cliente { get; set; }
    }
}