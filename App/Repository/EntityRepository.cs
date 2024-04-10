using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;


namespace App.Repository
{

    public abstract class EntityRepository<T>
    {
        protected readonly string _connectionString;

        protected EntityRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected List<T> ExecuteQuery(string query, Func<IDataReader, T> mapper, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        var entities = new List<T>();

                        while (reader.Read())
                        {
                            entities.Add(mapper(reader));
                        }

                        return entities;
                    }
                }
            }
        }

        protected bool ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }


        public abstract T getById(int id);
        public abstract List<T> getAll();
        public abstract bool Add(T entity);
        public abstract bool Update(T entity);
        public abstract bool Delete(T entity);
    }
}