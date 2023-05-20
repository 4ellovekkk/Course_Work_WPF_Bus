using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WpfApp1.Models
{
    [Table("Route")]
    public class Route
    {
        [Key]
        public int Id { get; set; }
        public Voyage Path { get; set; }
        public string _time { get; set; }
        public int _car { get; set; }
        public string _how_often { get; set; }
        
        public Route(string name, string time,string date,int sign,Voyage obj, string how_often)
        {
            Random rnd = new Random();
            
            Id = rnd.Next(1, 999);
            Path = obj;
            _time = time;
            _car = sign;
            _how_often = how_often;
        }
    }

    public class RouteContext : DbContext
    {
        public RouteContext() : base("DefaultConnection")
        {

        }
        public DbSet<Route> Routes { get; set; }
    }

}
