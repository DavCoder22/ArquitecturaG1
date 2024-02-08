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


        public List<PaisesDto> BuscarPaisesPorNombreParcial(string partialName)
        {
            var listaPaises = new List<PaisesDto>();

            // Utilizar using para asegurar la limpieza de recursos.

            // NO OLVIDAR CAMBIAR EL PROC ALMA X CODE

            using (var comando = new SqlCommand("VerPaises", Conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Condition", $"%{partialName}%");

                Conexion.Open();

                using (var leerFilas = comando.ExecuteReader())
                {
                    while (leerFilas.Read())
                    {
                        listaPaises.Add(new PaisesDto
                        {
                            // Asegúrate de ajustar los índices de GetString y GetInt32 según el diseño de tu tabla.
                            Name = leerFilas.GetString(1),
                            Continent = leerFilas.GetString(2),
                            Region = leerFilas.GetString(3),
                            Population = leerFilas.GetInt32(6),
                            Localname = leerFilas.GetString(10),
                            Capital = leerFilas.IsDBNull(13) ? 0 : leerFilas.GetInt32(13)

                        });
                    }
                }

                Conexion.Close();
            }

            return listaPaises;
        }




    }


}
