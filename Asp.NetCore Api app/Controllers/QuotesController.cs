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
        //best practice so that all clients will get lates deta from server
        [ResponseCache(Duration = 60, Location=ResponseCacheLocation.Client )]
        public IActionResult Get()
        {
            return Ok(_quotesDbContext.Quotes);
        }

        // GET: api/Quotes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           var quote = _quotesDbContext.Quotes.Find(id);
            if(quote == null)
            {
                return NotFound("record not found");
            }
            else
            {
                return Ok(quote);
            }
       
        }

        //attribute routing the get() request
        //api/quotes/Test/1
        [HttpGet("[action]/{id}")]
        public int Test (int id)
        {
            return id;
        }

        // POST: api/Quotes
        [HttpPost]
        public IActionResult Post([FromBody] Quote quote)
        {
            _quotesDbContext.Quotes.Add(quote);
            //call to save changes in the database
            _quotesDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Quote quote)
        {
          var entity =  _quotesDbContext.Quotes.Find(id);
            //if  id vaue is not found in the database
             if (entity == null)
            {
                return NotFound("No record found");
            }
            else
            {
                entity.Title = quote.Title;
                entity.Author = quote.Author;
                entity.Description = quote.Description;
                _quotesDbContext.SaveChanges();
                return Ok("Record updated successfully");
            }
        
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
          var quote = _quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound("No record found.....");
            }
            else
            {
                _quotesDbContext.Quotes.Remove(quote);
                _quotesDbContext.SaveChanges();
                return Ok("Record has been deleted....");
            }
            
        }
        
    }
}
