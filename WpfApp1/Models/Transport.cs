using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_speedrun.Models
{
   public class Transport
    {
        public string Sign { get; }
        private float _avg_speed { get; set; }
        private string _manufacture { get; }
        private string _model { get; }
        private int _capacity { get; set; }
        private int _year { get; }

        public Transport(string Manufacture, string Model, int Capacity, float Avg_Speed,int Year)
        {
            Random rnd = new Random();
            Sign = Convert.ToString(rnd.Next(1000, 9999));
            _manufacture = Manufacture;
            _model = Model;
            _capacity = Capacity;
            _avg_speed = Avg_Speed;
            _year= Year;
        }
    }

    
}
