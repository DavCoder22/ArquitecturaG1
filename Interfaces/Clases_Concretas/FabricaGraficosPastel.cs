using ArquitecturaG1.Interfaces;
using ArquitecturaG1.Interfaces.Fabricas;
using ArquitecturaG1.Modelos;

namespace ArquitecturaG1.Interfaces.Clases_Concretas
{
    public class FabricaGraficosPastel : IFabricaGraficos
    {
        public IGrafico CrearGrafico()
        {
            // Asume la existencia de una clase GraficoDePastel que implementa IGrafico
            return new GraficoDePastel();
        }
    }
}
