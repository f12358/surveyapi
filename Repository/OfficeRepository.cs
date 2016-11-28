using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using surveyapi.Models;

namespace surveyapi.Repository
{
    public class OfficeRepository : MongoRepository<Office>, IOfficeRepository
    {
        public OfficeRepository()
        {
            // Ensure we have a 2DSphere Index on Location field
            _collection.Indexes.CreateOne(Builders<Office>.IndexKeys.Geo2DSphere("Location"));
        }

        public async Task<IEnumerable<Office>> FindNearByOffices(double latitude, double longitude)
        {
            var point = GeoJson.Point(GeoJson.Geographic(longitude, latitude));
            var locFilter = Builders<Office>.Filter.NearSphere(x => x.Location, point, 5 * 1609.34);
            return await _collection.Find(locFilter).ToListAsync();
        }
    }
}
