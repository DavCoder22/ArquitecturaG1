using ArquitecturaG1.Models.DAO;

namespace ArquitecturaG1.Models.AbstractFactory
{
    public class SqlServerDatabaseFactory : IDatabaseFactory
    {
        public IPaisesDao CreatePaisesDao()
        {
            return new PaisesDao();
        }

        public IIdiomasDao CreateIdiomasDao()
        {
            return new IdiomasDao();
        }
    }
}
