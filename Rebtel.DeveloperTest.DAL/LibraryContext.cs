using Microsoft.EntityFrameworkCore;
using Rebtel.DeveloperTest.DAL;
using System;
using System.Collections.Generic;

public class LibraryContext : DbContext, ILibraryContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Borrower> Borrowers { get; set; }
    public DbSet<BorrowerHistory> BorrowerHistories { get; set; }

    public string DbPath { get; }

    public LibraryContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "Rebtel.DeveloperTest.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        LibraryContextSeedData.SeedLibraryDataContext(modelBuilder);

    }
}
