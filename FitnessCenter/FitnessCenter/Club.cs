using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FitnessCenter
{
    public class Club
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }

        public Club (string name, string address, string city)

        {
            Name = name;
            Address = address;
            City = city;
        }
    }
}