using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace projectZ.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Users> Userss { get; set; }
        public DbSet<Products> Productss { get; set; }
        public DbSet<Basket> Baskets { get; set; }
    }
}
