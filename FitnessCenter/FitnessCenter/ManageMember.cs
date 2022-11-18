namespace FitnessCenter
{
    public class ManageMember
    {
        public List<Member> Members { get; set; }

        public ManageMember()
        {
            Members = new List<Member>() { new SingleClubMember(1, "Bob", "ABC Club"), new MultiClubMember(2, "Sue") };
            //read Members from text file
        }

        public void AddMember(string memberName)
        {
            Members.Add(new MultiClubMember(GetNextId(), memberName));
            //update text file
        }

        public void AddMember(string memberName, string clubName)
        {
            Members.Add(new SingleClubMember(GetNextId(), memberName, clubName));
            //update text file
        }

        public bool RemoveMember(int id)
        {
            Member member = GetMember(id);
            
            if (member != null)
            {
                Members.Remove(member);
                //update text file

                return true;
            }

            return false;
        }

        public bool RemoveMember(string memberName)
        {
            Member member = GetMember(memberName);

            if (member != null)
            {
                Members.Remove(member);
                //update text file

                return true;
            }

            return false;
        }
        
        public Member GetMember(int id)
        {
            return Members.Where(x => x.Id == id).First();
        }

        public Member GetMember(string memberName)
        {
            return Members.Where(x => x.Name.ToLower() == memberName.ToLower()).First();
        }

        private int GetNextId()
        {
            return Members.Select(x => x.Id).Max() + 1;
        }
    }
}
