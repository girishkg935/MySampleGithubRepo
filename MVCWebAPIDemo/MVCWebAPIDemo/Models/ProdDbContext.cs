using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCWebAPIDemo.Models
{
    public class ProdDbContext : DbContext
    {


        public DbSet<Product> Products { get; set; }
    }
}