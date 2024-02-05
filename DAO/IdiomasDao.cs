using ArquitecturaG1.DBContext;
using ArquitecturaG1.Models.DTO;
using System.Data;
using System.Data.SqlClient;

namespace ArquitecturaG1.DAO
{
    internal class IdiomasDao : ConexionDBIdiomas
    {
        //Se declara un SqlReader para leer las filas
        SqlDataReader LeerFilas;
        SqlCommand Comando = new SqlCommand();

        //Se enlista los datos de IdiomaDB
        public List<IdiomasDto> VerIdiomas(string condicion)
        {
            //Se crean los atributos de conexión
            Comando.Connection = Conexion;
            Comando.CommandText = "VerIdiomas";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Language", condicion);
            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            List<IdiomasDto> ListaSerializada = new List<IdiomasDto>();

            //Leer los parametros de cada fila
            while (LeerFilas.Read())
            {
                ListaSerializada.Add(new IdiomasDto
                {
                    CountryCode = LeerFilas.GetString(0),
                    Languaje = LeerFilas.GetString(1),
                    IsOfficial = LeerFilas.GetString(2),
                    Percentage = LeerFilas.GetDecimal(3),
                });
            }
            LeerFilas.Close();
            Conexion.Close();
            return ListaSerializada;
        }
    }
}
