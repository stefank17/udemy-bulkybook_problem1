using BulkyBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// We will use code first approach of building this application, by automatically creating the database with code

// Rather than building the database and then work on the code

namespace BulkyBook.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // "ctor" code snippet for constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories
        {
        get; set; 
        }

        public DbSet<CoverType> CoverTypes
        {
            get; set;
        }
        public DbSet<Product> Products
        {
            get; set;
        }
    }
}
