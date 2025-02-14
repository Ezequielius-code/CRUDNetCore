﻿using System.Data.SqlClient;

namespace CRUD_Web.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSQL = builder.GetSection("ConecctionStrings:CadenaSQL").Value;
        }

        public string GetCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
