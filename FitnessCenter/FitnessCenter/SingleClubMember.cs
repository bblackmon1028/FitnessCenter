using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter
{
    public class SingleMemberClub : Member
    {
        public string ClubMember { get; set; }
        public SingleMemberClub(int id, string name , string clubMember)
        {
            Id = id;
            Name = name;
            ClubMember = clubMember;
            Fee = 8;
        }
        public override void CheckIn(Club club)
        {

            if (club != ClubMember)
            {
                throw new Exception("member does not belong to input club");
            }

        }
    }
}