namespace ArquitecturaG1.Modelos
{
    public class EstadisticaIdioma
    {
        public int Id { get; set; }
        public int PaisId { get; set; }
        public string Idioma { get; set; }
        public double Porcentaje { get; set; }
        // Relación con Pais si es necesario, por ejemplo:
        // public Pais Pais { get; set; }
    }
}
