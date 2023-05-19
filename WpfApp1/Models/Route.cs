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
        public string _name { get; set; }
        public string _time { get; set; }
        public string _date { get; set; }
        public string _car { get; set; }
        public bool _how_often { get; set; }
        
        public Route(string name, string time,string date,string sign,Voyage obj, bool how_often)
        {
            Random rnd = new Random();
            
            Id = rnd.Next(1, 999);
            _name = name;
            Path = obj;
            _time = time;
            _date = date;
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
