using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using surveyapi.Models;

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

    public interface IOfficeRepository : IRepository<Office>
    {
        Task<IEnumerable<Office>> FindNearByOffices(double latitude, double longitude);
    }
}
