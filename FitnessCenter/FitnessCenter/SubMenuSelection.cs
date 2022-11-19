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
            bool validInput = true;
            do
            {
                switch (userAnswer)
                {
                    case 1:
                        Console.WriteLine("Please enter the name of the member you would like to add:");
                        string addMember = Console.ReadLine();
                        Console.WriteLine("Please select a membership type:\n1.Single\n2.Multi-Club");
                        string membershipType = Console.ReadLine();

                        if (Convert.ToInt32(membershipType) == 1)
                        {
                            validInput = ValidateAddMember(addMember, membershipType);
                        }
                        else
                        {
                            validInput = ValidateAddMember(addMember);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Please enter the name of the member you would like to remove:");
                        string remove = Console.ReadLine();
                        validInput = ValidateRemoveMember(remove);
                        break;
                    case 3:
                        Console.WriteLine("Please enter the name of the member info you would like to display;");
                        string display = Console.ReadLine();
                        validInput = ValidateDisplayMemberInfo(display);
                        break;
                    default:
                        break;
                }
            }
            while (validInput == false);
        }
        public static bool ValidateAddMember(string readLine)
        {
            try
            {
                ManageMember member = new ManageMember();
                member.AddMember(readLine);
                Console.WriteLine($"{readLine} has been successfully added!");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Member can't be added at this time. Please try again.");
                return false;
            }
        }
        public static bool ValidateAddMember(string readLine, string memberType)
        {
            try
            {
                ManageMember member = new ManageMember();
                member.AddMember(readLine, memberType);
                Console.WriteLine($"{readLine} has been successfully added!");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Member can't be added at this time. Please try again.");
                return false;
            }
        }
        public static bool ValidateRemoveMember(string readLine)
        {
            try
            {
                ManageMember member = new ManageMember();
                member.RemoveMember(readLine);
                Console.WriteLine($"{readLine} has been successfully removed.");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a current member. Press 0 to enter a new name or press 9 to return to main menu:");
                return ReturnToMainMenu();
            }
        }

        public static bool ValidateDisplayMemberInfo(string readLine)
        {
            try
            {
                ManageMember member = new ManageMember();
                bool canConvert = int.TryParse(readLine, out int result);
                if (canConvert)
                {
                    Member requestedMember = member.GetMember(result);
                    Console.WriteLine($"Name:{requestedMember.Name}" +
                        $"\nId Number: {requestedMember.Id}" +
                        $"\nMember Fee:{requestedMember.Fee}" +
                        $"\nClub Member:{requestedMember.ClubMember}");
                    return true;
                }
                else
                {
                    Member requestedMember = member.GetMember(readLine);
                    Console.WriteLine($"Name:{requestedMember.Name}" +
                        $"\nId Number: {requestedMember.Id}" +
                        $"\nMember Fee:{requestedMember.Fee}" +
                        $"\nClub Member:{requestedMember.ClubMember}");
                    return true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a valid member name. Press 0 to enter a new name or press 9 to return to main menu:");
                return ReturnToMainMenu();
            }
        }

        public static bool ReturnToMainMenu()
        {
            string catchResponse = Console.ReadLine();

            try
            {
                if (Convert.ToInt32(catchResponse) == 9)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
