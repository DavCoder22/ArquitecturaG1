using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ArquitecturaG1.DBContext;
using ArquitecturaG1.Models.DTO;

namespace ArquitecturaG1.Models.DAO
{
    internal class PaisesDao : ConexionDBPaises, IPaisesDao
    {
        //Se declara el SqlReader para leer las filas
        private SqlDataReader LeerFilas;
        private SqlCommand Comando = new SqlCommand();

        //Se crea una lista donde se almacenen los datos
        public List<PaisesDto> VerPaises(string name)
        {
            Comando.Connection = Conexion;
            // Modifica la consulta para no usar procedimientos almacenados
            Comando.CommandText = "SELECT * FROM Country WHERE Name = @Name";
            Comando.Parameters.Clear();
            if (name != null)
                Comando.Parameters.AddWithValue("@Name", name);
            Comando.CommandType = CommandType.Text;

            Conexion.Open();

            LeerFilas = Comando.ExecuteReader();
            var ListGeneric = new List<PaisesDto>();

            while (LeerFilas.Read())
            {
                ListGeneric.Add(new PaisesDto
                {
                    Code = LeerFilas.GetString(0),
                    Name = LeerFilas.GetString(1),
                    Continent = LeerFilas.GetString(2),
                    Region = LeerFilas.GetString(3),
                    Population = LeerFilas.GetInt32(6),
                    Localname = LeerFilas.GetString(10),
                    Capital = LeerFilas.GetInt32(13)
                });
            }

            LeerFilas.Close();
            Conexion.Close();

            return ListGeneric;
        }

        public List<PaisesDto> BuscarPaisesPorNombreParcial(string partialName)
        {
            List<PaisesDto> listaPaises = new List<PaisesDto>();
            using (var comando = new SqlCommand("SELECT * FROM Country WHERE Name LIKE @PartialName", Conexion))
            {
                comando.Parameters.Add(new SqlParameter("@PartialName", SqlDbType.VarChar) { Value = $"%{partialName}%" });
                Conexion.Open();
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pais = new PaisesDto
                        {
                            Code = reader["Code"]as string,
                            Name = reader["Name"] as string,
                            Continent = reader["Continent"] as string,
                            Region = reader["Region"] as string,
                            Population = reader["Population"] as int? ?? default(int),
                            Localname = reader["LocalName"] as string,
                            Capital = reader["Capital"] as int? ?? default(int)
                        };
                        listaPaises.Add(pais);
                    }
                }
                Conexion.Close();
            }
            return listaPaises;
        }
    }
}
