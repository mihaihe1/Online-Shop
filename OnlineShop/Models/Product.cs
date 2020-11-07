using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public String Description { get; set; }
        //public ? Picture { get; set; }
        [Required]
        public float Price { get; set; }
        public float Rating { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }

    public class ProductDBContext : DbContext
    {
        public ProductDBContext() : base("DBConnectionString") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Revies { get; set; }
    }
}