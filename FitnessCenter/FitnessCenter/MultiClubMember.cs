using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter
{
    public class MultiClubMember : Member
    {
        public int MemberPoints { get; set; }
        public MultiClubMember(int id, string name)
        { 
            Id = id;
            Name = name;
            Fee = 12;
            MemberPoints = 100;
        }
        public MultiClubMember()
        {

        }

        public override void CheckIn(Club club)
        {
            MemberPoints += 50;
            ManageMember manageMember = new ManageMember();
            FileManagement.WriteFile(manageMember.Members);
        }
    }
}
