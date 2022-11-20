using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter
{
    public class SingleClubMember : Member
    {
        
        public SingleClubMember(int id, string name , string clubMember)
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

            if (club.Name != ClubMember)
            {
                throw new Exception("member does not belong to input club");
            }

        }
    }
}