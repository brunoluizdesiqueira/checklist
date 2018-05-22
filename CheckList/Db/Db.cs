using System.Data;
using System.IO;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace CheckList.Db
{
    public class Seed
    {
        private static IDbConnection _dbConnection;

        public static void CreateDb(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
            var dbFilePath = configuration.GetValue<string>("DBInfo:ConnectionString");
            if (!File.Exists(dbFilePath))
            {
                _dbConnection = new NpgsqlConnection(connectionString);
                _dbConnection.Open();

                // Create a Tarefa table
                _dbConnection.Execute(@"
                    CREATE TABLE IF NOT EXISTS Tarefa (
                        Id SERIAL NOT NULL PRIMARY KEY,
                        Titulo VARCHAR(128) NOT NULL,
                        Descricao VARCHAR(500) NOT NULL,
                        Status INTEGER NOT NULL,
                        DataCriacao TIMESTAMP, 
                        DataEncerramento TIMESTAMP
                    )");

                _dbConnection.Close();
            }

        }
    }
}