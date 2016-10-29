using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace surveyapi.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetSingle(string id);

        Task<T> Add(T value);

        Task<ReplaceOneResult> Update(string id, T survey);

        Task<DeleteResult> Delete(string id);
    }
}
