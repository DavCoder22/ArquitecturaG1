using ArquitecturaG1.Interfaces;
using ArquitecturaG1.Interfaces.Fabricas;
using ArquitecturaG1.Modelos;

// Asegúrate de que el espacio de nombres coincida con la estructura de tu proyecto.
// Si `FabricaGraficosBarras` está en el mismo espacio de nombres que `IFabricaGraficos`, no necesitas separarlos.
namespace ArquitecturaG1.Interfaces.Clases_Concretas
{
    public class FabricaGraficosBarras : IFabricaGraficos
    {
        public IGrafico CrearGrafico()
        {
            // Asume la existencia de una clase GraficoDeBarras que implementa IGrafico
            return new GraficoDeBarras();
        }
    }
}
