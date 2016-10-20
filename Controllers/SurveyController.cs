using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using surveyapi.Models;

namespace surveyapi.Controllers
{
    [Route("api/surveys")]
    public class SurveyController : Controller
    {   
        protected IMongoClient _client;
        protected IMongoDatabase _database;
        protected IMongoCollection<Survey> _collection;

        public SurveyController()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("Surveys");
            _collection = _database.GetCollection<Survey>("Survey");
        }
        
        // GET api/values
        [HttpGet]
        public async Task<List<Survey>> Get()
        {
            var filter = Builders<Survey>.Filter.Empty;
            return await _collection.Find(filter).ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Survey> Get(string id)
        {
            var filter = Builders<Survey>.Filter.Eq("_id", ObjectId.Parse(id));
            var document = await _collection.Find(filter).FirstAsync();
            
            return document;
        }

        // POST api/values
        [HttpPost]
        public async Task<Survey> Post([FromBody]Survey value)
        {
            await _collection.InsertOneAsync(value);
            return value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Task<ReplaceOneResult> Put(string id, [FromBody]Survey survey)
        {
            var filter = Builders<Survey>.Filter.Eq("_id", ObjectId.Parse(id));
            return _collection.ReplaceOneAsync(filter,  survey);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<DeleteResult> Delete(string id)
        {
            var filter = Builders<Survey>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _collection.DeleteOneAsync(filter);
        }
    }
}
