using ArquitecturaG1.Interface.Abstract_Factory;

namespace ArquitecturaG1.Interface.Clases_Concretas
{
    public class BarChartFactory : IChartFactory
    {
        public IChart CreateChart()
        {
            return new BarChart();
        }
    }



    public class BarChart : IChart
    {
        public void RenderChart(List<PaisDto> paises, List<IdiomaDto> idiomas)
        {
            // Implementar lógica para renderizar gráfico de barras
        }
    }
}
