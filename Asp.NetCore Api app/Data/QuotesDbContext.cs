﻿using Asp.NetCore_Api_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore_Api_app.Data
{
    public class QuotesDbContext : DbContext
    {
        public QuotesDbContext(DbContextOptions<QuotesDbContext> options) : base(options)
        {

        }
        public DbSet<Quote> Quotes { get; set; }
    }
}
