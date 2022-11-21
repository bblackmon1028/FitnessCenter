using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter
{
    public class SingleClubMember : Member
    {
        public string ClubMember { get; set; }
        public SingleClubMember(int id, string name, string clubMember)
        {
            Id = id;
            Name = name;
            ClubMember = clubMember;
            Fee = 8;
        }
        public SingleClubMember()
        {

        }
        public override void CheckIn(Club club)
        {
            if (club.Name == ClubMember)
            {
                Console.WriteLine("Member has been checked in!");
            }
            else
            {
                Console.WriteLine("Member does not belong to this club.");
            }

        }
    }
}