using FitnessCenter;

Console.WriteLine("Welcome to Grand Circus Gym! Unless you die, keep going!");
while (true)
{
    Console.WriteLine("\nPlease choose from the following menu options:");
    Console.WriteLine("1. Add Member");
    Console.WriteLine("2. Remove Member");
    Console.WriteLine("3. Display Member Information");
    Console.WriteLine("4. Check Into Club");
    Console.WriteLine("5. Generate Bill Of Fees");
    Console.WriteLine("6. Display All Current Members");
    Console.WriteLine("7. Exit");
    string userAnswer = Console.ReadLine();
    int itemNum = ValidateMenuSelection(userAnswer);
    if (itemNum == - 1)
    {
        Console.WriteLine("That is not a valid selection. Please try again.");
    }
    else if (itemNum == 7)
    {
        Console.WriteLine("Hustle for that muscle. Goodbye!");
        Console.ReadKey();
        Environment.Exit(0);
    }
    else
    {
        SubMenuSelection.DisplaySelectedSubMenu(ValidateMenuSelection(userAnswer));
    }
}

int ValidateMenuSelection(string option)
{
    try
    {
        int userSelection = Convert.ToInt32(option);
        if (userSelection > 7 || userSelection < 1)
        {
            return -1;
        }
        return userSelection;
    }
    catch (System.FormatException)
    {
        return -1;
    }
}
//secret