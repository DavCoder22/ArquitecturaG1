using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ArquitecturaG1.DBContext
{
    class ConexionDBIdiomas
    {
        //Cadena de conexión hacia base de datos IdiomasDB
        static readonly string conexion = "Data Source=mssql_idiomas;Initial Catalog=IdiomasDB;User ID=sa;Password=LeandroExp1999.;";
        protected SqlConnection Conexion = new SqlConnection(conexion);

    }
}
