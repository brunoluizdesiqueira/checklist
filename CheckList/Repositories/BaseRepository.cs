using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using CheckList;
using CheckList.Db;


namespace CheckList.Repositories
{
    public abstract class BaseRepository<T>
    {
       private string _connectionString;
       protected string ConnectionString => _connectionString;
       public BaseRepository(IConfiguration configuration){
            _connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

            Db.Seed.CreateDb(configuration);
        }

        public abstract void Add(T item);
        public abstract void Remove(int id);
        public abstract void Update(T item);
        public abstract T FindByID(int id);
        public abstract IEnumerable<T> FindAll();
    }
}