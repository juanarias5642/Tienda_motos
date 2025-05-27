namespace lib_dominio.Entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Entidad { get; set; }
        public string? Operacion { get; set; }
        public string? Datos { get; set; }
        public DateTime Fecha { get; set; }
    }
}
