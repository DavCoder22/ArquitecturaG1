using ArquitecturaG1.DBContext;
using ArquitecturaG1.Models.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ArquitecturaG1.Models.DAO
{
    internal class IdiomasDao : ConexionDBIdiomas, IIdiomasDao
    {
        //Se declara un SqlReader para leer las filas
        private SqlDataReader LeerFilas;
        private SqlCommand Comando = new SqlCommand();

        //Se enlista los datos de IdiomaDB
        public List<IdiomasDto> VerIdiomas(string condicion)
        {
            //Se crean los atributos de conexión y se configura la consulta SQL directa
            Comando.Connection = Conexion;
            Comando.CommandText = "SELECT * FROM CountryLanguage WHERE Language = @Language";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@Language", condicion);
            Comando.CommandType = CommandType.Text;

            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            var ListaSerializada = new List<IdiomasDto>();

            // Leer los parámetros de cada fila
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

        public List<IdiomasDto> GetAllIdiomas()
        {
            // Configurar el comando SQL para seleccionar todos los idiomas
            Comando.Connection = Conexion;
            Comando.CommandText = "SELECT * FROM CountryLanguage";
            Comando.CommandType = CommandType.Text;

            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            var ListaSerializada = new List<IdiomasDto>();

            // Leer los registros de la tabla
            while (LeerFilas.Read())
            {
                ListaSerializada.Add(new IdiomasDto
                {
                   //CountryCode = LeerFilas.GetString(0),
                    Languaje = LeerFilas.GetString(1),
                    IsOfficial = LeerFilas.GetString(2),
                    Percentage = LeerFilas.GetDecimal(3),
                });
            }

            LeerFilas.Close();
            Conexion.Close();

            return ListaSerializada;
        }

        public List<IdiomasDto> VerIdiomasPorCodigoPais(string countryCode)
        {
            var ListaSerializada = new List<IdiomasDto>();
            using (var comando = new SqlCommand("SELECT * FROM CountryLanguage WHERE CountryCode = @CountryCode", Conexion))
            {
                comando.Parameters.Add(new SqlParameter("@CountryCode", SqlDbType.Char) { Value = countryCode });
                Conexion.Open();
                using (var LeerFilas = comando.ExecuteReader())
                {
                    while (LeerFilas.Read())
                    {
                        var idioma = new IdiomasDto
                        {
                           // CountryCode = LeerFilas.IsDBNull(0) ? null : LeerFilas.GetString(0),
                            Languaje = LeerFilas.IsDBNull(1) ? null : LeerFilas.GetString(1),
                            IsOfficial = LeerFilas.IsDBNull(2) ? null : LeerFilas.GetString(2),
                            Percentage = LeerFilas.IsDBNull(3) ? default(decimal) : LeerFilas.GetDecimal(3),
                        };
                        ListaSerializada.Add(idioma);
                    }
                }
                Conexion.Close();
            }
            return ListaSerializada;
        }

    }
}
