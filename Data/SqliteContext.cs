using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc_ef.Models;

    public class SqliteContext : DbContext
    {
        public SqliteContext (DbContextOptions<SqliteContext> options)
            : base(options)
        {
        }

        public DbSet<mvc_ef.Models.Person> Person { get; set; }

        public DbSet<mvc_ef.Models.City> City { get; set; }

        public DbSet<mvc_ef.Models.Country> Country { get; set; }

        public DbSet<mvc_ef.Models.Language> Language { get; set; }
    }
