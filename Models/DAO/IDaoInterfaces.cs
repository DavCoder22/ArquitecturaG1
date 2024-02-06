// IDaoInterfaces.cs

using ArquitecturaG1.Models.DTO;
using System.Collections.Generic;

namespace ArquitecturaG1.Models.DAO
{
    public interface IPaisesDao
    {
        List<PaisesDto> VerPaises(string name);
    }

    public interface IIdiomasDao
    {
        List<IdiomasDto> VerIdiomas(string condicion);
        //List<IdiomasDto> VerIdiomasAgrupados();
    }

    public interface IPaisesDto
    {
        // Propiedades de PaisesDto
    }

    public interface IIdiomasDto
    {
        // Propiedades de IdiomasDto
    }
}
