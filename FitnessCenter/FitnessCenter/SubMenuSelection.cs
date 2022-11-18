using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter
{
    public static class SubMenuSelection
    {
        public static void DisplaySelectedSubMenu(int userAnswer)
        {
            while (true)
            {
                switch (userAnswer)
                {
                    case 1:
                        Console.WriteLine("Please enter the name of the member you would like to add:");
                        string addMember = Console.ReadLine();
                        ValidateAddMember(addMember);
                        break;
                    case 2:
                        Console.WriteLine("Please enter the name of the member you would like to remove:");
                        string remove = Console.ReadLine();
                        ValidateRemoveMember(remove);
                        break;
                    case 3:
                        Console.WriteLine("Please enter the name of the member info you would like to display;")
                        ManageMember.DisplayMemberInformation();
                        break;
                    case 4:
                        //();
                        break;

                    default:
                        "That is not a valid answer, please select again";
                        break;
                }
            }
        }
        public static bool ValidateAddMember(string readLine)
        {
            try
            {
                ManageMember.AddMember(readLine);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("That is not a valid member name. Please try again.");
                return false;
            }
        }

        public static bool ValidateRemoveMember(string readLine)
        {
            try
            {
                ManageMember.RemoveMember(readLine);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("That is not a valid member name. Please try again.");
                return false;
            }
        }

        public static bool ValidateDisplayMemberInfo(string readLine)
        {
            try
            {
                bool canConvert = int.TryParse(readLine);
                if (Convert.ToInt32(readLine))
                    
                    ManageMember.DisplayMemberInfo
            }
        }
    }
}
