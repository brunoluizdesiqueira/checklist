using System.Collections.Generic;
using System.Data;
using System.Linq;
using CheckList.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace CheckList.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>
    {
        public TarefaRepository(IConfiguration configuration) : base(configuration) {  }

        public override void Add(Tarefa item)
        {
             using (IDbConnection dbConnection = new NpgsqlConnection(ConnectionString))
            {
                string sQuery = "INSERT INTO Tarefa (Titulo, Descricao, Status, DataCriacao, DataEncerramento)"
                                + " VALUES(@Titulo, @Descricao, @Status, @DataCriacao, @DataEncerramento)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);
            }
        }

        public override IEnumerable<Tarefa> FindAll()
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(ConnectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Tarefa>("SELECT * FROM Tarefa");
            }
        }

        public override Tarefa FindByID(int id)
        {
             using (IDbConnection dbConnection = new NpgsqlConnection(ConnectionString))
            {
                string sQuery = "SELECT * FROM Tarefa"
                            + " WHERE Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<Tarefa>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public override void Remove(int id)
        {
             using (IDbConnection dbConnection = new NpgsqlConnection(ConnectionString))
            {
                string sQuery = "DELETE FROM Tarefa"
                            + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public override void Update(Tarefa item)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(ConnectionString))
            {
                string sQuery = "UPDATE Tarefa SET Titulo = @Titulo,"
                            + " Descricao = @Descricao, Status= @Status,"
                            + " DataEncerramento= @DataEncerramento"
                            + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, item);
            }
        }
    }
}