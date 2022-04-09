using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Net6WebApi2.DalEfImpl.Models;

namespace Net6WebApi2.DalEfImpl.NoteDbContext
{
    public class NoteDbContext : DbContext
    {

        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options)
        {

        }

        public NoteDbContext()
        {
        }

        public DbSet<Note> Notes => Set<Note>();
    }


    //public class NoteDbContextFactory : IDesignTimeDbContextFactory<NoteDbContext>
    //{
    //    public NoteDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<NoteDbContext>();
    //        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=dbfrt2;User Id=postgres;Password=postgres");

    //        return new NoteDbContext(optionsBuilder.Options);
    //    }
    //}
}

