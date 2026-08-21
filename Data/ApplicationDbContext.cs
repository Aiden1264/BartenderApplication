using Microsoft.EntityFrameworkCore;
using BartenderApplication.Models;

namespace BartenderApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CocktailOrder> CocktailOrders { get; set; }
    }
}
