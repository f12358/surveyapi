using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace surveyapi.Repository
{
    public class MongoRepository<T> : IRepository<T>
    {
        protected IMongoClient _client;
        protected IMongoDatabase _database;
        protected IMongoCollection<T> _collection;
        
        public MongoRepository()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("Surveys");
            _collection = _database.GetCollection<T>(typeof(T).Name);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var filter = Builders<T>.Filter.Empty;
            return await _collection.Find(filter).ToListAsync();
        }

        public virtual async Task<T> GetSingle(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            var document = await _collection.Find(filter).FirstAsync();
            
            return document;
        }

        public virtual async Task<T> Add(T value)
        {
            await _collection.InsertOneAsync(value);
            return value;
        }

        public virtual async Task<ReplaceOneResult> Update(string id, T survey)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _collection.ReplaceOneAsync(filter,  survey);
        }

        public virtual async Task<DeleteResult> Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _collection.DeleteOneAsync(filter);
        }
    }
}
