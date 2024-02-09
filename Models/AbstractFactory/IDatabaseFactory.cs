using ArquitecturaG1.Models.DAO;

namespace ArquitecturaG1.Models.AbstractFactory
{
    public interface IDatabaseFactory
    {
        IPaisesDao CreatePaisesDao();
        IIdiomasDao CreateIdiomasDao();
    }
}
