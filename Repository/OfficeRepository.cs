using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using surveyapi.Models;

namespace surveyapi.Repository
{
    public class OfficeRepository : MongoRepository<Office>
    {
        public OfficeRepository()
        {
            // Ensure we have a 2DSphere Index on Location field
            _collection.Indexes.CreateOne(Builders<Office>.IndexKeys.Geo2DSphere("Location"));
        }
    }
}
