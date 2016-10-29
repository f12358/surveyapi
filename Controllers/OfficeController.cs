using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using surveyapi.Models;
using surveyapi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace surveyapi.Controllers
{
    [Route("api/[controller]")]
    public class OfficeController : Controller
    {
        protected IRepository<Office> _officeRepo;

        public OfficeController()
        {
            _officeRepo = new OfficeRepository();
        }
        
        // GET api/office
        [HttpGet]
        public async Task<IEnumerable<Office>> Get()
        {
            return await _officeRepo.GetAll();
        }

        // GET api/office/5814d88775bb2b0be435f9e2
        [HttpGet("{id}")]
        public async Task<Office> Get(string id)
        {
            return await _officeRepo.GetSingle(id);
        }

        // POST api/office
        [HttpPost]
        public async Task<Office> Post([FromBody]Office value)
        {
            return await _officeRepo.Add(value);
        }

        // PUT api/office/5814d88775bb2b0be435f9e2
        [HttpPut("{id}")]
        public async Task<ReplaceOneResult> Put(string id, [FromBody]Office office)
        {
            return await _officeRepo.Update(id, office);
        }

        // DELETE api/office/5814d88775bb2b0be435f9e2
        [HttpDelete("{id}")]
        public async Task<DeleteResult> Delete(string id)
        {
            return await _officeRepo.Delete(id);
        }
    }
}
