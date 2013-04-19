using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Organics.Models
{
    public class Business
    {
        
        public int ID {get;set;}
        public string name { get; set; }
        public string description { get; set; }
        public DateTime addDate { get; set; }
        public DateTime updatedDate { get; set; }
        public ICollection<ProductModels> Products { get; set; }
    }
    public class OrganicsDBContext : DbContext
    {
        public DbSet<Business> Businesses { get; set; }
        public DbSet<ProductModels> Products { get; set; }
    }
}