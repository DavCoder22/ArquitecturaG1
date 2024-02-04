using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ArquitecturaG1.DBContext
{
    public class ConexionDBPaises
    {
        //Cadena de conexión a la base de datos PaisesDB
        //System.Configuration.ConfigurationManager.ConnectionStrings["PaisesDB"].ConnectionString;
        static readonly string conexion = "Data Source=DESKTOP-R1NSJ7E\\SQLEXPRESS02;Initial Catalog=PaisesDB;Integrated Security=True";
        protected SqlConnection Conexion = new SqlConnection(conexion);

    }
}
