using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FitnessCenter
{
    public class FileManagement
    {
        public const string FilePathClubs = @"C:\stuff\FitnessClubs.txt";
        public const string FilePathMember = @"C:\stuff\FitnessMembers.txt";
        public void AddToFile(string name, string address)
        {
            StreamWriter sw = new StreamWriter(FilePathClubs, true);
            sw.Flush();
            sw.Close();
        }
        public void AddToFile(int id, string name, string clubMember)
        {
            StreamReader sw = new StreamReader(FilePathMember, true);
        }

        public void RemoveFromFile()
        {

        }

        public void ReadFile()
        {

        }
    }
}
