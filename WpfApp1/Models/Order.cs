using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId {get; set; }
        public int RouteID { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string time_ordered { get; set; }
    }
}
