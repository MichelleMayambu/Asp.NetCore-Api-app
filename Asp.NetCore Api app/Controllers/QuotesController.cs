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

        // GET: api/Quotes //with status code
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_quotesDbContext.Quotes); //status code 200 with data
            //  return NotFound() 404
            //better method to use , define which status code you want to return
           // return StatusCode(200); 
           // return StatusCode(402); 
           // exerllent method to Automatically generate a status code using the StatusCode CLASS
          // return StatusCode(StatusCodes.Status200OK);
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
        public void Put(int id, [FromBody] Quote quote)
        {
          var entity =  _quotesDbContext.Quotes.Find(id);
            entity.Title = quote.Title;
            entity.Author = quote.Author;
            entity.Description = quote.Description;
            _quotesDbContext.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
          var quote = _quotesDbContext.Quotes.Find(id);
            _quotesDbContext.Quotes.Remove(quote);
           
        }
    }
}
