// IDaoInterfaces.cs

using ArquitecturaG1.Models.DTO;
using System.Collections.Generic;

namespace ArquitecturaG1.Models.DAO
{
    public interface IPaisesDao
    {
        List<PaisesDto> VerPaises(string name);
        List<PaisesDto> BuscarPaisesPorNombreParcial(string partialName);
    }

    public interface IIdiomasDao
    {
        List<IdiomasDto> VerIdiomas(string condicion);
        List<IdiomasDto> VerIdiomasPorCodigoPais(string countryCode);
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
