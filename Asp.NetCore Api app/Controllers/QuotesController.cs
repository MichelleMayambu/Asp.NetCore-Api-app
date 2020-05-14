using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCore_Api_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore_Api_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        static List<Quote> _quotes = new List<Quote>()
        {
        new Quote()
        {
            Id=1,
            Title="Hard Work",
            Author="Michelle",
            Description="I'ts good to be deliberate about what you want, because eventually you will acquire it," +
            " it's a simple principle of hardwork"
        },
         new Quote()
        {
            Id=2,
            Title="Perseverance",
            Author="Michelle",
            Description="I'ts good to be deliberate about what you want, because eventually you will acquire it," +
             " it's a simple principle of hardwork"
        }
        };

        //get request to get list of quotes
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return _quotes;
        }

        //post objet to list of quotes
        [HttpPost]
        public void Post([FromBody] Quote quote)
        {
            _quotes.Add(quote);
        }

        //update object list quotes
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Quote quote)
        {
            _quotes[id] = quote;
        }

        //delete
        [HttpDelete("{id}")]
        public void Delete( int id)
        {
            _quotes.RemoveAt(id);
        }
    }
}