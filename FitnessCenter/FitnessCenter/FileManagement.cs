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
                sw.WriteLine($"{member.Fee}|{member.Name}|{member.Id}");
            }
            sw.Flush();
            sw.Close();
        }
        

        public static void RemoveFromFile()
        {
            StreamReader sr = new StreamReader(FilePathMember);
            List<Member> members = new List<Member>();
            while (true)
            {
                string line = sr.ReadLine();
                if (line == null)
                {
                    break;
                }
                string[] parts = line.Split('|');
            }
        }

        public static void ReadFile()
        {

        }
    }
}
