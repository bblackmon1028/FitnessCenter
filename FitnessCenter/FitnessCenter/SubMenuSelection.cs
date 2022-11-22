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
            ManageMember manageMember = new ManageMember();
            switch (userAnswer)
            {
                case 1:
                    Console.WriteLine("Please enter the name of the member you would like to add:");
                    string memberName = Console.ReadLine();

                    while (!ValidNameInput(memberName))
                    {
                        Console.WriteLine("That is not a valid member name. Please try again.");
                        memberName = Console.ReadLine();
                    }

                    Console.WriteLine("Please select a membership type:\n1.Single\n2.Multi-Club");
                    string membershipType = Console.ReadLine();

                    while (!ValidMemberTypeInput(membershipType))
                    {
                        Console.WriteLine("That is not a valid membership type. Please try again.");
                        Console.WriteLine("Please select a membership type:\n1.Single\n2.Multi-Club");
                        membershipType = Console.ReadLine();
                    }

                    if (Convert.ToInt32(membershipType) == 1)
                    {
                        Console.WriteLine("Please select a club to join:");
                        DisplayAvailableClubs();
                        string selectedClub = Console.ReadLine();
                        while (!ValidateClubSelection(selectedClub))
                        {
                            Console.WriteLine("That is not a valid club. Please try again.");
                            DisplayAvailableClubs();
                            selectedClub = Console.ReadLine();
                        }
                        Club selectClub = GetSelectedClub(Convert.ToInt32(selectedClub));
                        manageMember.AddMember(memberName, selectClub);
                        Console.WriteLine($"{memberName} has been successfully added to {selectClub.Name}!");
                    }
                    else
                    {
                        manageMember.AddMember(memberName);
                        Console.WriteLine($"{memberName} has been successfully added as a Multi-Club member!");
                    }
                    break;
                case 2:
                    Console.WriteLine("Please enter the ID of the member you would like to remove:");
                    DisplayAllMembers();
                    string removeMemberId = Console.ReadLine();

                    while (!ValidateMemberID(removeMemberId))
                    {
                        Console.WriteLine("That is not a valid member ID. Please try again.");
                        Console.WriteLine("Please enter the ID of the member you would like to remove:");
                        removeMemberId = Console.ReadLine();
                    }
                    Member memberInfo = GetMemberInfo(Convert.ToInt32(removeMemberId));
                    manageMember.RemoveMember(Convert.ToInt32(removeMemberId));
                    Console.WriteLine($"Member #{memberInfo.Id}: {memberInfo.Name} has been successfully removed.");
                    break;
                case 3:
                    Console.WriteLine("Please enter the ID of the member information you would like to display:");
                    DisplayAllMembers();
                    string displayMemberId = Console.ReadLine();

                    while (!ValidateMemberID(displayMemberId))
                    {
                        Console.WriteLine("That is not a valid member ID. Please try again.");
                        Console.WriteLine("Please enter the ID of the member information you would like to display:");
                        displayMemberId = Console.ReadLine();
                    }

                    Member requestedMember = GetMemberInfo(Convert.ToInt32(displayMemberId));
                    string clubText = string.Empty;
                    if (requestedMember is SingleClubMember)
                    {
                        var singleClubMember = requestedMember as SingleClubMember;
                        clubText = $"Membership Type: Single Member\nMember's Club: {singleClubMember.ClubMember}";
                    }
                    else
                    {
                        var multiClubMember = requestedMember as MultiClubMember;
                        clubText = $"Membership Type: Multi-Club Member\nMembership Points: {multiClubMember.MemberPoints}";
                    }

                    Console.WriteLine($"Name: {requestedMember.Name}" +
                    $"\nId Number: {requestedMember.Id}" +
                    $"\nMember Fee: {requestedMember.Fee:C}" +
                    $"\n{clubText}");

                    break;
                case 4:
                    Console.WriteLine("Please enter the ID of the member checking in:");
                    DisplayAllMembers();
                    string memberId = Console.ReadLine();

                    while (!ValidateMemberID(memberId))
                    {
                        Console.WriteLine("That is not a valid member ID. Please try again.");
                        Console.WriteLine("Please enter the ID of the member checking in:");
                        memberId = Console.ReadLine();
                    }

                    Console.WriteLine("Please select the club you are checking into:");
                    DisplayAvailableClubs();
                    string clubChoice = Console.ReadLine();

                    while (!ValidateClubCheckIn(clubChoice, Convert.ToInt32(memberId)))
                    {
                        Console.WriteLine("Please select the club you are checking into:");
                        DisplayAvailableClubs();
                        clubChoice = Console.ReadLine();
                    }

                    Member checkInMember = GetMemberInfo(Convert.ToInt32(memberId));
                    Club club = GetSelectedClub(Convert.ToInt32(clubChoice));
                    Console.WriteLine($"{checkInMember.Name} was successfully checked into {club.Name}.");
                    break;
                case 5:
                    Console.WriteLine("Please enter the ID of the member you would like to generate a bill for:");
                    DisplayAllMembers();
                    string memberIdForBill = Console.ReadLine();

                    while (!ValidateMemberID(memberIdForBill))
                    {
                        Console.WriteLine("That is not a valid member ID. Please try again.");
                        Console.WriteLine("Please enter the name or ID of the member you would like to generate a bill for:");
                        memberIdForBill = Console.ReadLine();
                    }
                    Member billMember = GetMemberInfo(Convert.ToInt32(memberIdForBill));
                    Console.WriteLine($"Name: {billMember.Name}" +
                        $"\nMonthly Membership Fee: {billMember.Fee:C}");
                    break;
                case 6:
                    Console.WriteLine("Current Members are:");
                    DisplayAllMembers();
                    break;
                default:
                    break;
            }
            ClearDisplay();
        }

        public static void DisplayAllMembers()
        {
            List<Member> members = FileManagement.ReadFile();
            var memberbyId = members.OrderBy(x => x.Name).ToList();
            memberbyId.ForEach(x => Console.WriteLine($"Id:{x.Id,-2} | Name: {x.Name}"));
        }

        public static Member GetMemberInfo(int ID)
        {
            ManageMember manageMember = new ManageMember();
            Member requestedMember = manageMember.GetMember(ID);
            return requestedMember;
        }

        public static bool ValidateMemberID(string membID)
        {
            try
            {
                int ID = int.Parse(membID);
                ManageMember manageMember = new ManageMember();
                if (manageMember.GetMember(ID) == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidNameInput(string memberName)
        {
            if (string.IsNullOrEmpty(memberName))
            {
                return false;
            }
            return true;
        }

        public static bool ValidMemberTypeInput(string userSelection)
        {
            try
            {
                int.TryParse(userSelection, out int clubSelection);
                if (clubSelection == 1 || clubSelection == 2)
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

        public static bool ValidateClubCheckIn(string clubSelection, int memberID)
        {
            if (!ValidateClubSelection(clubSelection) ||
                !CheckIntoClub(memberID, Convert.ToInt32(clubSelection)))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateClubSelection(string clubSelection)
        {
            try
            {
                int.TryParse(clubSelection, out int convertedClubSelection);
                if (convertedClubSelection <= 4 && convertedClubSelection > 0)
                {
                    return true;
                }
                throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a valid club choice. Please try again.");
                return false;
            }
        }

        public static Club GetSelectedClub(int clubSelection)
        {
            List<Club> clubs = GetAvailableClubList();
            switch (clubSelection)
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

        public static bool CheckIntoClub(int memberID, int clubSelection)
        {
            try
            {
                ManageMember memberManager = new ManageMember();
                Club club = GetSelectedClub(clubSelection);
                memberManager.GetMember(memberID)
                             .CheckIn(club);
                FileManagement.WriteFile(memberManager.Members); 
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Check in unsuccessful. Member does not belong to specified club.");
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