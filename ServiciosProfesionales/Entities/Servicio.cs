namespace ServiciosProfesionales.Entities
{
    public class Servicio
    {
        public int Id { get; set; }
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
    }
}
