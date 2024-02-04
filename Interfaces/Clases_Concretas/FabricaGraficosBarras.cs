namespace ArquitecturaG1.Interface.Abstract_Factory
using ArquitecturaG1.Interfaces;
using ArquitecturaG1.Modelos;

namespace ProyectoEstadisticasIdiomas.Interfaces.Clases_Concretas
{
    public class FabricaGraficosBarras : IFabricaGraficos
    {
        public IGrafico CrearGrafico()
        {
            return new GraficoDeBarras(); // Asume la existencia de una clase GraficoDeBarras que implementa IGrafico
        }
    }
}