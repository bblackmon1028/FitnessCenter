using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter
{
    public class MultiClubMember : Member
    {
        public int MemberPoints { get; private set; }

        public override void CheckIn(Club club)
        {
            MemberPoints++;
        }
    }
}
