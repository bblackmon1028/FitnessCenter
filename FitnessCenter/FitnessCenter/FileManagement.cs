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
            CreateDataFileIfNotExists();
            StreamWriter sw = new StreamWriter(FilePathMember);
            
            foreach (var member in members)
            {
                if (member is MultiClubMember)
                {
                    sw.WriteLine($"{"Multi"}|{member.Fee}|{member.Name}|{member.Id}");
                }
                if (member is SingleClubMember)
                {
                    var singleClubMember = member as SingleClubMember;
                    sw.WriteLine($"{"Single"}|{member.Fee}|{member.Name}|{member.Id}|{singleClubMember.ClubMember}");
                }
            }
            sw.Close();
        }

        public static List<Member> ReadFile()
        {
            CreateDataFileIfNotExists();
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

                if (parts[0] == "Single")
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
                if (parts[0] == "Multi")
                {
                    MultiClubMember multiClubMember = new MultiClubMember
                    {
                        Fee = Convert.ToDouble(parts[1]),
                        Name = parts[2],
                        Id = Convert.ToInt32(parts[3]),
                        
                    };
                    multiClubMembers.Add(multiClubMember);
                }
            }
            foreach (var member in multiClubMembers)
            {
                members.Add(member);
            }
            foreach (var member in singleClubMembers)
            {
                members.Add(member);
            }
            sr.Close();
            return members;
        }

        private static void CreateDataFileIfNotExists()
        {
            if (!Directory.Exists(Path.GetDirectoryName(FilePathMember)))
                Directory.CreateDirectory(Path.GetDirectoryName(FilePathMember));
            if (!File.Exists(FilePathMember))
                File.Create(FilePathMember).Dispose();
        }
    }
}
