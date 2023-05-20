using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
   public class Transport
    {
        public string Sign { get; }
        private float _max_speed { get; set; }
        private string _manufacture { get; }
        private string _model { get; }
        private int _capacity { get; set; }
        private string _color { get; }

        public Transport(string Manufacture, string Model, int Capacity, float Avg_Speed,string Color)
        {
            Random rnd = new Random();
            Sign = Convert.ToString(rnd.Next(1000, 9999));
            _manufacture = Manufacture;
            _model = Model;
            _capacity = Capacity;
            _max_speed = Avg_Speed;
            _color= Color;
        }
    }

    
}
