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
        static SqlDataReader LeerFilas;
        static SqlCommand Comando = new SqlCommand();

        //Se crea una lista donde se almacenen los datos
        public List<PaisesDto> VerPaises(string code)
        {
            Comando.Connection = Conexion;
            string query = "SELECT Name, Population FROM Countries";
            Comando.CommandText = query;
            Comando.CommandType = CommandType.Text;
            if (code != null)
                query += "WHERE Code Like @Code";
            
            Comando.Parameters.AddWithValue("@Code", $"%{code}%");
            Conexion.Open();

            LeerFilas = Comando.ExecuteReader();
            List<PaisesDto> ListGeneric = new List<PaisesDto>();

            while (LeerFilas.Read())
            {
                ListGeneric.Add(new PaisesDto
                {
                    Code = LeerFilas.GetString(0),
                    Name = LeerFilas.GetString(1),
                    Population = LeerFilas.GetInt32(2),

                });
            }

            LeerFilas.Close();
            Conexion.Close();

            return ListGeneric;
        }

    }


}
