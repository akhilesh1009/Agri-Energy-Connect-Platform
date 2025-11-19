using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ST10281011_PROG7311_POE_PART_2.Models;

namespace ST10281011_PROG7311_POE_PART_2.Data
{

    //Source: tutorialsEU - C# (2023) ASP.NET User Roles - Create and Assign Roles for AUTHORIZATION!, 23 February.
    //Avaliable At: <https://www.youtube.com/watch?v=Y6DCP-yH-9Q> [Accessed 12 May 2025]

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}

