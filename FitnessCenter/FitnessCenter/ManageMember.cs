using System.Diagnostics.Metrics;

namespace FitnessCenter
{
    public class ManageMember
    {
        public List<Member> Members { get; set; }

        public ManageMember()
        {
            //Members = new List<Member>() { new SingleClubMember(1, "Bob", "ABC Club"), new MultiClubMember(2, "Sue") };
            Members = FileManagement.ReadFile();
        }

        public void AddMember(string memberName)
        {
            if (!string.IsNullOrEmpty(memberName)
            {
                Members.Add(new MultiClubMember(GetNextId(), memberName));
                FileManagement.WriteFile(Members);
            }
            else
                throw new Exception("Invalid member name passed when trying to add member");
        }

        public void AddMember(string memberName, string clubName)
        {
            if (!string.IsNullOrEmpty(memberName) && !string.IsNullOrEmpty(clubName))
            {

                Members.Add(new SingleClubMember(GetNextId(), memberName, clubName));
                FileManagement.WriteFile(Members);
            }
            else
                throw new Exception("Invalid member name/club passed when trying to add member");
        }

        public void RemoveMember(int id)
        {
            Member member = GetMember(id);

            if (member != null)
            {
                Members.Remove(member);
                FileManagement.WriteFile(Members);
            }
            else throw new Exception("Unable to remove member");
        }

        public void RemoveMember(string memberName)
        {
            Member member = GetMember(memberName);

            if (member != null)
            {
                Members.Remove(member);
                FileManagement.WriteFile(Members);
            }
            else throw new Exception("Unable to remove member");
        }
        
        public Member GetMember(int id)
        {
            try
            {
                return Members.Where(x => x.Id == id).First();
            }

            catch
            {
                throw new Exception("Could not find this member ID");
            }
        }

        public Member GetMember(string memberName)
        {
            try
            {
                return Members.Where(x => x.Name.ToLower() == memberName.ToLower()).First();
            }

            catch
            {
                throw new Exception("Could not find this member name");
            }
        }

        private int GetNextId()
        {
            if (Members.Count == 0)
                return 1;
            else
                return Members.Select(x => x.Id).Max() + 1;
        }
    }
}
