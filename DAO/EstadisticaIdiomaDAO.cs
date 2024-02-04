namespace ArquitecturaG1.DAO
{
    using ArquitecturaG1.DTO;
    using System.Collections.Generic;
    using System.Linq;

    public class EstadisticaIdiomaDAO
    {
        private static List<EstadisticaIdiomaDTO> estadisticas = new List<EstadisticaIdiomaDTO>
    {
        new EstadisticaIdiomaDTO { PaisId = 1, Idioma = "Español", Porcentaje = 70.0 },
        new EstadisticaIdiomaDTO { PaisId = 1, Idioma = "Inglés", Porcentaje = 20.0 },
        // Agrega más estadísticas de idiomas para el País A
        new EstadisticaIdiomaDTO { PaisId = 2, Idioma = "Francés", Porcentaje = 60.0 },
        new EstadisticaIdiomaDTO { PaisId = 2, Idioma = "Alemán", Porcentaje = 40.0 }
        // Agrega más estadísticas de idiomas para el País B
    };

        public static List<EstadisticaIdiomaDTO> ObtenerEstadisticasPorPais(int paisId)
        {
            return estadisticas.Where(e => e.PaisId == paisId).ToList();
        }
    }
}
