using ArquitecturaG1.Interface.Abstract_Factory;

namespace ArquitecturaG1.Interface.Clases_Concretas
{
    public class PieChartFactory : IChartFactory
    {
        public IChart CreateChart()
        {
            return new PieChart();
        }
    }

    public class PieChart : IChart
    {
        public void RenderChart(List<PaisDTO> paises, List<IdiomaDTO> idiomas)
        {
            // Implementar lógica para renderizar gráfico de pastel
        }
    }
}
