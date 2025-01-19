using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<T> GetAll()
        {
            using var connection = _connection;
            var items = connection.GetAll<T>();

            if (items == null)
                throw new Exception("Erro ao buscar todos os registros");
            return items;
        }

        public T GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID deve ser maior que zero.");
            }

            using var connection = _connection;
            var entity = connection.Get<T>(id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Nenhum registro encontrado com o ID {id}.");
            }
            return entity;
        }

        public bool Create(T entity)
        {
            using var connection = _connection;
            var result = connection.Insert(entity) > 0;

            if (!result)
                throw new Exception($"Erro ao inserir a entidade:");
            return result;
        }

        public bool Update(T entity)
        {
            using var connection = _connection;
            var result = connection.Update(entity);

            if (!result)
                throw new Exception("Erro ao atualizar a entidade");
            return result;
        }

        public bool Delete(T entity)
        {
            using var connection = _connection;
            var result = connection.Delete(entity);

            if (!result)
                throw new Exception("Erro ao deletar a entidade");
            return result;
        }

        public bool DeleteById(int id)
        {

            T entity = GetById(id);
            using var connection = _connection;
            var result = connection.Delete(entity);

            if (!result)
                throw new Exception("Erro ao deletar a entidade");
            return result;
        }
    }
}
