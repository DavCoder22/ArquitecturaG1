using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ArquitecturaG1.DBContext;
using ArquitecturaG1.Models.DTO;

namespace ArquitecturaG1.DAO
{
    internal class PaisesDao : ConexionDBPaises
    {
        //Se declara el SqlReader para leer las filas
        static SqlDataReader LeerFilas;
        static SqlCommand Comando = new SqlCommand();

        //Se crea una lista donde se almacenen los datos
        public List<PaisesDto> VerPaises(string name)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "VerPaises";
            Comando.CommandType = CommandType.StoredProcedure;
            if (name != null)
                Comando.Parameters.AddWithValue("@Condition", name);

            Conexion.Open();

            LeerFilas = Comando.ExecuteReader();
            List<PaisesDto> ListGeneric = new List<PaisesDto>();

            while (LeerFilas.Read())
            {
                ListGeneric.Add(new PaisesDto
                {
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

    }
}
