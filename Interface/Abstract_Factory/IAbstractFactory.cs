using System;

namespace ArquitecturaG1.Interface.Abstract_Factory
{

    //    para proporcionar una interfaz para crear familias de objetos relacionados 
    //    o dependientes sin especificar sus clases concretas.La interfaz 
    //    IAbstractFactory en este caso declara dos métodos que son responsables 
    //    de crear instancias de objetos específicos relacionados con el acceso 
    //    a datos(DAO) para países y lenguajes(idiomas).


    public interface IChartFactory
    {
        IChart CreateChart();
    }

    public interface IChart
    {
        void RenderChart(List<PaisDto> paises, List<IdiomaDto> idiomas);
    }



}
