using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc_ef.Models;
// using System.Data.Entity.ModelConfiguration.Conventions;
// using System.Data.Entity.Core.Metadata.Edm;

public class SqliteContext : DbContext
{
    public SqliteContext (DbContextOptions<SqliteContext> options)
	: base(options)
    {
    }

    public DbSet<mvc_ef.Models.Person> People { get; set; }

    public DbSet<mvc_ef.Models.City> Cities { get; set; }

    public DbSet<mvc_ef.Models.Country> Countries { get; set; }

    public DbSet<mvc_ef.Models.Language> Languages { get; set; }


    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
	base.OnModelCreating(modelbuilder);			  
	modelbuilder.Entity<Person>()
	    .HasMany(p => p.Languages)
	    .WithMany(c => c.People)
	    .UsingEntity(j => j.HasData(new { PeoplePersonId = 1, LanguagesLanguageId = 1 }));
    }
    public void OnModelCreatingUnprotected()
    {
	ModelBuilder modelbuilder = new ModelBuilder();
	// modelBuilder.Conventions.Add<PKConvention>();
	OnModelCreating(modelbuilder);
    }

//     public class PKConvention : Convention
//     {
// 	public PKConvention()
// 	{
// 	    modelbuilder.Entity<Person>()
// 		.HasMany(p => p.Languages)
// 		.WithMany(c => c.People)
// 		.UsingEntity(j => j.HasData(new { PeoplePersonId = 1, LanguagesLanguageId = 1 }));
// 	}
//     }
}
