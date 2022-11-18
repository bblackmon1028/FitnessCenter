using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FitnessCenter
{
    public static class FileManagement
    {
        
        public const string FilePathMember = @"C:\stuff\FitnessMembers.txt";
        public static void WriteFile(List<Member> members)
        {
            StreamWriter sw = new StreamWriter(FilePathMember);
            
            foreach (var member in members)
            {
                if (member is MultiClubMember)
                {
                    sw.WriteLine($"{"M"}|{member.Fee}|{member.Name}|{member.Id}");
                }
                if (member is SingleClubMember)
                {
                    sw.WriteLine($"{"S"}|{member.Fee}|{member.Name}|{member.Id}|{member.ClubMember}");
                }
                
            }
            
            sw.Close();
        }
        

        public static void RemoveFromFile()
        {
            StreamReader sr = new StreamReader(FilePathMember);
            List<Member> members = new List<Member>();
            while (true)
            {
                var line = sr.ReadLine();
                if (line == null)
                {
                    break;
                }
                string[] parts = line.Split('|');
                
            }
        }

        public static List<Member> ReadFile()
        {
            StreamReader sr = new StreamReader(FilePathMember);
            List<Member> members = new List<Member>();
            List<SingleClubMember> singleClubMembers = new List<SingleClubMember>();
            List<MultiClubMember> multiClubMembers = new List<MultiClubMember>();

            while (true)
            {
                var line = sr.ReadLine();
                if (line == null)
                {
                    break;
                }
                string[] parts = line.Split('|');
                
                if (parts[0] == "S")
                {
                    SingleClubMember singleClubMember = new SingleClubMember
                    {
                        Fee = Convert.ToDouble(parts[1]),
                        Name = parts[2],
                        Id = Convert.ToInt32(parts[3]),
                        ClubMember = parts[4]
                    };
                    singleClubMembers.Add(singleClubMember);
                }
                if (parts[0] == "M")
                {
                    MultiClubMember multiClubMember = new MultiClubMember
                    {
                        Fee = Convert.ToDouble(parts[1]),
                        Name = parts[2],
                        Id = Convert.ToInt32(parts[3]),
                        ClubMember = parts[4]
                    };
                    multiClubMembers.Add(multiClubMember);
                }


                members = multiClubMembers.Union(singleClubMembers);



            }




            return members;
        }
    }
}
