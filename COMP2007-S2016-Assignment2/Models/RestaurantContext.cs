using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace COMP2007_S2016_Assignment2.Models
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext()
            : base("name=RestaurantConnection")
        {
        }
        public virtual DbSet<MenuItems> MenuItems { get; set; }
    }
}