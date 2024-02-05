using System;
using ArquitecturaG1.DAO;
using ArquitecturaG1.Models.DTO;

namespace ArquitecturaG1
{
    internal static class Program
    {
        static void Main()
        {
            //Prueba de extracción de datos por consola
            //IdiomasDao IdiomasDao = new IdiomasDao();
            //List<IdiomasDto> ListaIdiomas = IdiomasDao.VerIdiomas("Spanish");
            //Console.WriteLine(ListaIdiomas[2].CountryCode.ToString());
            PaisesDao paisesDao = new PaisesDao();
            List<PaisesDto> ListaPaises = paisesDao.VerPaises("Spain");
            Console.WriteLine(ListaPaises[0].Name.ToString());
        }
    }
}
