﻿using ArquitecturaG1.DBContext;
using ArquitecturaG1.Models.DTO;
//using ArquitecturaG1.Models.IDaoInterfaces;
using System.Data;
using System.Data.SqlClient;

namespace ArquitecturaG1.Models.DAO
{
    internal class IdiomasDao : ConexionDBIdiomas , IIdiomasDao
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


        //public List<IdiomasDto> VerIdiomasAgrupados()
        //{
        //    Comando.Connection = Conexion;
        //    Comando.CommandText = "VerIdiomas";
        //    Comando.CommandType = CommandType.StoredProcedure;

        //    Conexion.Open();
        //    LeerFilas = Comando.ExecuteReader();

        //    // Leer todos los idiomas de la base de datos
        //    List<IdiomasDto> ListaSerializada = new List<IdiomasDto>();

        //    while (LeerFilas.Read())
        //    {
        //        ListaSerializada.Add(new IdiomasDto
        //        {
        //            CountryCode = LeerFilas.GetString(0),
        //            Languaje = LeerFilas.GetString(1),
        //            IsOfficial = LeerFilas.GetString(2),
        //            Percentage = LeerFilas.GetDecimal(3),
        //        });
        //    }

        //    LeerFilas.Close();
        //    Conexion.Close();

        //    // Agrupar por CountryCode y Language utilizando LINQ
        //    var idiomasAgrupados = ListaSerializada
        //        .GroupBy(idioma => new { idioma.CountryCode, idioma.Languaje })
        //        .Select(grupo => new IdiomasDto
        //        {
        //            CountryCode = grupo.Key.CountryCode,
        //            Languaje = grupo.Key.Languaje,
        //            // suma de porcentajes aquí si es necesario
        //            Percentage = grupo.Sum(idioma => idioma.Percentage),
        //            // Agregar otras propiedades según sea necesario
        //        })
        //        .ToList();

        //    return idiomasAgrupados;
        //}

    }

}
