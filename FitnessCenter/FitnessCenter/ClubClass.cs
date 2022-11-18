using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter
{
    public class Club
    {
        public string name { get; set; }
        public string  address { get; set; }
        public string city { get; set; }

        

         public static void FitnessCenter( string name, string address, string city)
        {
            Club Club = new Club();
            
            Club.name = name; Club.address = address; Club.city = city;

            Club.name = $" Hello {name}welcome to the Fitness Center";

            Club.address = $"In our system your address is {address}";

            Club.city = $"Your current city location is {city}";
        }
    }
}
