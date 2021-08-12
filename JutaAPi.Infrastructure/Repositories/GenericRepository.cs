using Dapper;
using JutaApi.Core.Entities;
using JutaAPi.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JutaAPi.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private string _tableName;
        
        private readonly IConfiguration _config;

        internal string Connection
        {
            get { return _config.GetConnectionString("DefaultConnection"); }
        }

        public GenericRepository(string tablename,IConfiguration config)
        {
            _config = config;
            _tableName = tablename;
        }

        internal virtual dynamic Mapping(T item)
        {
            return item;
        }

        public async Task<int> AddAsync(T item)
        {
            using (var connection = new SqlConnection(Connection))
            {
                var parameters = (object)Mapping(item);              
                return await connection.ExecuteAsync(_tableName, parameters);
            }           
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T item = default(T);
            
            using (var connection = new SqlConnection(Connection))
            {               
                var result = await connection.QueryAsync<T>("SELECT * FROM " + _tableName + " WHERE ID=@ID", new { ID = id });
                item = result.FirstOrDefault();
            }
            return item;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<T> items = null;           
            using (var connection = new SqlConnection(Connection))
            {               
                items = await connection.QueryAsync<T>("SELECT * FROM " + _tableName);
            }
            return items;
        }

        //public virtual void Update(T item)
        //{
        //    using (IDbConnection cn = Connection)
        //    {
        //        var parameters = (object)Mapping(item);
        //        cn.Open();
        //        cn.Update(_tableName, parameters);
        //    }
        //}

        //public virtual void Remove(T item)
        //{
        //    using (IDbConnection cn = Connection)
        //    {
        //        cn.Open();
        //        cn.Execute("DELETE FROM " + _tableName + " WHERE ID=@ID", new { ID = item.ID });
        //    }
        //}

        //public virtual T FindByID(Guid id)
        //{
        //    T item = default(T);

        //    using (IDbConnection cn = Connection)
        //    {
        //        cn.Open();
        //        item = cn.Query<T>("SELECT * FROM " + _tableName + " WHERE ID=@ID", new { ID = id }).SingleOrDefault();
        //    }

        //    return item;
        //}



        //public virtual IEnumerable<T> FindAll()
        //{
        //    IEnumerable<T> items = null;

        //    using (IDbConnection cn = Connection)
        //    {
        //        cn.Open();
        //        items = cn.Query<T>("SELECT * FROM " + _tableName);
        //    }

        //    return items;
        //}


    }
}
