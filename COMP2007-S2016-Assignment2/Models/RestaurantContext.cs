using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//File: RestaurantContext.cs
//Authors: Amanda, Anthony
//Website: http://comp2007-s2016-assignment2-restaurant.azurewebsites.net
//Description: Db connection set up
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