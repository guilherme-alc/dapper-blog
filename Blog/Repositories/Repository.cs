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
            var items = _connection.GetAll<T>();

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

            var entity = _connection.Get<T>(id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Nenhum registro encontrado com o ID {id}.");
            }
            return entity;
        }

        public bool Create(T entity)
        {
            var result = _connection.Insert(entity) > 0;

            if (!result)
                throw new Exception($"Erro ao inserir a entidade:");
            return result;
        }

        public bool Update(T entity)
        {
            var result = _connection.Update(entity);

            if (!result)
                throw new Exception("Erro ao atualizar a entidade");
            return result;
        }

        public bool Delete(T entity)
        {
            var result = _connection.Delete(entity);

            if (!result)
                throw new Exception("Erro ao deletar a entidade");
            return result;
        }

        public bool DeleteById(int id)
        {

            T entity = GetById(id);
            var result = _connection.Delete(entity);

            if (!result)
                throw new Exception("Erro ao deletar a entidade");
            return result;
        }
    }
}
