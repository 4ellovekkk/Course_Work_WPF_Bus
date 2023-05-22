using WpfApp1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Windows;

namespace WpfApp1.DB
{
    public class MyDbContext : DbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<Transport> Buses { get; set; }
        public DbSet<Voyage> Pathes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(VYDRA-PC)\\mssqllocaldb;Database=Course_Work_WPF_Bus;TrustedConnection=True;");
        }

    }
    
}