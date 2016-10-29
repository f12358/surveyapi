using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using surveyapi.Models;
using surveyapi.Repository;

namespace surveyapi.Controllers
{
    [Route("api/[controller]")]
    public class SurveyController : Controller
    {   
        protected IRepository<Survey> _surveyRepo;
        protected IRepository<Office> _officeRepo;

        public SurveyController()
        {
            _surveyRepo = new MongoRepository<Survey>();
            _officeRepo = new OfficeRepository();
        }
        
        // GET api/survey
        [HttpGet]
        public async Task<IEnumerable<Survey>> Get()
        {
            return await _surveyRepo.GetAll();
        }

        // GET api/survey/5814d88775bb2b0be435f9e3
        [HttpGet("{id}")]
        public async Task<Survey> Get(string id)
        {
            var result = await _surveyRepo.GetSingle(id);

            if (result is VccSurvey) {
                ((VccSurvey)result).Offices = await _officeRepo.GetAll();
            }
            
            return result;
        }

        // POST api/survey
        [HttpPost]
        public async Task<Survey> Post([FromBody]Survey value)
        {
            return await _surveyRepo.Add(value);
        }

        // PUT api/survey/5814d88775bb2b0be435f9e3
        [HttpPut("{id}")]
        public async Task<ReplaceOneResult> Put(string id, [FromBody]Survey survey)
        {
            return await _surveyRepo.Update(id, survey);
        }

        // DELETE api/survey/5814d88775bb2b0be435f9e3
        [HttpDelete("{id}")]
        public async Task<DeleteResult> Delete(string id)
        {
            return await _surveyRepo.Delete(id);
        }
    }
}
