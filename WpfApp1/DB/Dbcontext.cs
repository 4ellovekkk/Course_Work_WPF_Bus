using WpfApp1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KP_speedrun.Models;

namespace WpfApp1.DB
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("KP_DB")
        {

        }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Transport> Buses { get; set; }
        public DbSet<Voyage> Pathes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}