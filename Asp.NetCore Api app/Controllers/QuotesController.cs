using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCore_Api_app.Data;
using Asp.NetCore_Api_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore_Api_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        //get dbContext
        private QuotesDbContext _quotesDbContext;

        //dbcontext constructor
        public QuotesController(QuotesDbContext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }

        // GET: api/Quotes
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return _quotesDbContext.Quotes;
        }

        // GET: api/Quotes/5
        [HttpGet("{id}")]
        public Quote Get(int id)
        {
           var quote = _quotesDbContext.Quotes.Find(id);
            return quote;
        }

        // POST: api/Quotes
        [HttpPost]
        public void Post([FromBody] Quote quote)
        {
            _quotesDbContext.Quotes.Add(quote);
            //call to save changes in the database
            _quotesDbContext.SaveChanges();
        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
