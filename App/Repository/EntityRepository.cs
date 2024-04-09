using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace App.Repository
{

    public abstract class EntityRepository<T>
    {
        protected readonly string _connectionString;

        protected EntityRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected List<T> ExecuteQuery(string query, Func<IDataReader, T> mapper, params SqlParameters[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connetion.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.addRange(parameters);
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

        protected bool ExecuteNonQuery(string query, params SqlParameters[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connetion.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.addRange(parameters);
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        protected static string GetStringOrNull(IDataReader reader, string columnName)
        {
            int ordinal = reader.GetOrdinal(columnName);
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }

        public abstract T getById(int id);
        public abstract List<T> getAll();
        public abstract bool Add(T entity);
        public abstract bool Update(T entity);
        public abstract bool Delete(T entity);
    }
}