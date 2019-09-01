using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMADataManager.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {

        public string GetConnectionString(string name)
        {
            // On retourne la connection DB de Web.config du projet Web
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameters,
            string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProcedure, parameters, commandType:
                     CommandType.StoredProcedure).ToList();

                return rows;
            }
        }        

        public void SaveData<T>(string storedProcedure, T parameters,
            string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType:
                     CommandType.StoredProcedure);
            }
        }
    }
}
