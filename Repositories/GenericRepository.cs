using System;
using System.Collections.Generic;
using System.Data;
using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class GenericRepository<TModel> where TModel : class
    {
        private readonly SqlConnection _connection;

        public GenericRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TModel> GetAll()
        {
            return _connection.GetAll<TModel>();
        }

        public TModel GetById(object id)
        {
            return _connection.Get<TModel>(id);
        }

        public void Create(TModel tmodel)
        {
            _connection.Insert<TModel>(tmodel);
            Console.WriteLine("Usuário inserido com sucesso");
        }

        public void Update(TModel tmodel)
        {
            _connection.Update<TModel>(tmodel);
        }

        public void Delete(TModel tmodel)
        {
            _connection.Delete<TModel>(tmodel);
        }

        public void Delete(int id)
        {
            if (id == 0)
                return;

            var model = _connection.Get<TModel>(id);
            _connection.Delete<TModel>(model);
        }
    }
}

