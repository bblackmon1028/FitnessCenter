using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                        string memberName = Console.ReadLine();

                        if (ValidateMemberName(memberName) == false)
                        {
                            validInput = false;
                            continue;
                        }

                        do
                        {
                            Console.WriteLine("Please select a membership type:\n1.Single\n2.Multi-Club");
                            string membershipType = Console.ReadLine();
                            validInput = ValidateMemberShipType(memberName, membershipType);
                        }
                        while (!validInput);
                        ClearDisplay();
                        break;
                    case 2:
                        Console.WriteLine("Please enter the ID of the member you would like to remove:");
                        string remove = Console.ReadLine();
                        validInput = ValidateRemoveMember(remove);
                        ClearDisplay();
                        break;
                    case 3:
                        Console.WriteLine("Please enter the ID of the member information you would like to display:");
                        string display = Console.ReadLine();
                        validInput = ValidateDisplayMemberInfo(display);
                        ClearDisplay();
                        break;
                    case 4:
                        Console.WriteLine("Please enter the ID of the member checking in:");
                        string memberId = Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Please select the club you would like to check into");
                            DisplayAvailableClubs();
                        }
                        while (!validInput);
                        validInput = ValidateCheckIntoClub(memberId);
                        ClearDisplay();
                        break;
                    case 5:
                        Console.WriteLine("Please enter the name or ID of the member you would like to generate bill for:");
                        string generateBill = Console.ReadLine();
                        validInput = ValidateGenerateBillInfo(generateBill);
                        ClearDisplay();
                        break;
                    case 6:
                        Console.WriteLine("Current Members are:");
                        List<Member> members = FileManagement.ReadFile();
                        var memberbyId = members.OrderBy(x => x.Name).ToList();
                        memberbyId.ForEach(x => Console.WriteLine($"Id:{x.Id,-2} | Name: {x.Name}"));
                        ClearDisplay();
                        break;
                    default:
                        break;
                }
            }
            while (validInput == false);
        }

        public static bool ValidateMemberName(string memberName)
        {
            if (string.IsNullOrEmpty(memberName))
            {
                Console.WriteLine("That is not a valid member name. Please try again.");
                return false;
            }
            return true;
        }

        public static bool ValidateAddMember(string userSelection)
        {
            try
            {
                ManageMember member = new ManageMember();
                member.AddMember(userSelection);
                Console.WriteLine($"{userSelection} has been successfully added!");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Member can't be added at this time. Please try again.");
                return false;
            }
        }

        public static bool ValidateAddMember(string userSelection, Club club)
        {
            try
            {
                ManageMember member = new ManageMember();
                member.AddMember(userSelection, club);
                Console.WriteLine($"{userSelection} has been successfully added to {club.Name}!");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Member can't be added at this time. Please try again.");
                return false;
            }
        }

        public static bool ValidateMemberShipType(string userName, string userSelection)
        {
            try
            {
                ManageMember member = new ManageMember();
                if (Convert.ToInt32(userSelection) == 1)
                {
                    Console.WriteLine("Please select your club:");
                    DisplayAvailableClubs();
                    Club club = SelectClub();
                    member.AddMember(userName, club);
                    Console.WriteLine($"{userName} has been successfully added to {club.Name}!");
                    return true;
                }
                else if(Convert.ToInt32(userSelection) == 2)
                {
                    member.AddMember(userName);
                    Console.WriteLine($"{userName} has been successfully added!");
                    return true;
                }
                else
                {
                    Console.WriteLine("That is not a valid selection. Please try again.");
                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a valid selection. Press enter to try again or press 9 to return to the main menu.");
                return ReturnToMainMenu();
            }
        }
        public static Club SelectClub()
        {
            List<Club> clubs = GetAvailableClubList();
            string selectedClub = Console.ReadLine();
            int convertedClubSelection = ConvertClubSelectionToInt(selectedClub);

            while (convertedClubSelection > 4 || convertedClubSelection <= 0)
            {
                Console.WriteLine("That is not a valid club. Please select again:");
                DisplayAvailableClubs();
                string newClubSelection = Console.ReadLine();
                convertedClubSelection = ConvertClubSelectionToInt(newClubSelection);
            }

            switch (convertedClubSelection)
            {
                case 1:
                    return clubs[0];
                case 2:
                    return clubs[1];
                case 3:
                    return clubs[2];
                case 4:
                    return clubs[3];
                default:
                    throw new ArgumentException("That is not a valid club selection.");
                    break;
            }
        }

        public static int ConvertClubSelectionToInt(string clubSelection)
        {
            bool canConvert = int.TryParse(clubSelection, out int result);
            if (canConvert)
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        public static bool ValidateRemoveMember(string userSelection)
        {
            try
            {
                ManageMember member = new ManageMember();
                bool canConvert = int.TryParse(userSelection, out int result);
                var getMember = member.GetMember(result);
                if (canConvert)
                {
                    member.RemoveMember(result);
                }
                Console.WriteLine($"{getMember.Name} has been successfully removed.");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a current member. Press enter to try again or press 9 to return to main menu.");
                return ReturnToMainMenu();
            }
        }

        public static bool ValidateDisplayMemberInfo(string userSelection)
        {
            try
            {
                ManageMember member = new ManageMember();
                bool canConvert = int.TryParse(userSelection, out int result);
                if (canConvert)
                {
                    Member requestedMember = member.GetMember(result);

                    if (requestedMember is SingleClubMember)
                    {
                        var singleClubMember = requestedMember as SingleClubMember;
                        Console.WriteLine($"Name:{requestedMember.Name}" +
                    $"\nId Number: {requestedMember.Id}" +
                    $"\nMember Fee:{requestedMember.Fee:C}" +
                    $"\nMembership Type: Single Club Member" +
                    $"\nMember's Club: {singleClubMember.ClubMember}");

                    }
                    else
                    {
                        var multiClubMember = requestedMember as MultiClubMember;
                        Console.WriteLine($"Name:{requestedMember.Name}" +
                    $"\nId Number: {requestedMember.Id}" +
                    $"\nMember Fee: {requestedMember.Fee:C}" +
                    $"\nMembership Type: Multi-Club Member" +
                    $"\nMembership Points: {multiClubMember.MemberPoints}");
                    }
                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a valid member. Press enter to try again or press 9 to return to main menu.");
                return ReturnToMainMenu();
            }
        }

        public static bool ValidateCheckIntoClub(string memberID)
        {
            Club club = SelectClub();
            try
            {
                ManageMember member = new ManageMember();
                bool canConvert = int.TryParse(memberID, out int ID);
                if (canConvert)
                {
                    member.GetMember(ID).CheckIn(club);
                    Console.WriteLine($"You have successfully checked into {club.Name}!");
                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Member does not belong to selected club. Press enter to try again or press 9 to return to the main menu.");
                return ReturnToMainMenu();
            }
        }

        public static bool ValidateGenerateBillInfo(string userSelection)
        {
            try
            {
                ManageMember member = new ManageMember();
                bool canConvert = int.TryParse(userSelection, out int result);
                if (canConvert)
                {
                    Member requestedMember = member.GetMember(result);
                    Console.WriteLine($"Name: {requestedMember.Name}" +
                        $"\nMember Fee: {requestedMember.Fee:C}");
                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a valid member name. Press enter to to try again or press 9 to return to main menu.");
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
                    Console.Clear();
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

        public static void ClearDisplay()
        {
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
        }

        public static List<Club> GetAvailableClubList()
        {
            List<Club> clubs = new List<Club>();
            clubs.Add(new Club("Grand Circus Cuyahoga", "1969 Portage Trail", "Cuyahoga Falls"));
            clubs.Add(new Club("Grand Circus Akron", "1698 Merriman Rd", "Akron"));
            clubs.Add(new Club("Grand Circus Hudson", "1540 Georgetown Rd", "Hudson"));
            clubs.Add(new Club("Grand Circus Macedonia", "949 E Aurora Rd", "Macedonia"));
            return clubs;
        }

        public static void DisplayAvailableClubs()
        {
            List<Club> clubs = GetAvailableClubList();
            clubs = GetAvailableClubList();
            for (int i = 0; i < clubs.Count; i++)
            {
                Console.Write($"{i + 1}. {clubs[i].Name}\n");
            }
        }
    }
}