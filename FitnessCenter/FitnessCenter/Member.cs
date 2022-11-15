using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter
{
    public abstract class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract void CheckIn(Club club);
    }
}
