using FitnessCenter;

Console.WriteLine("Welcome to Grand Circus Gym! Unless you die, keep going!");
while (true)
{
    Console.WriteLine("\nPlease choose from the following menu options:");
    Console.WriteLine("1. Add Member");
    Console.WriteLine("2. Remove Member");
    Console.WriteLine("3. Display Member Information");
    Console.WriteLine("4. Check Into Club");
    Console.WriteLine("5. Check Membership Fee & Points");
    Console.WriteLine("6. Exit");
    string userAnswer = Console.ReadLine();
    SubMenuSelection.DisplaySelectedSubMenu(ValidateMenuSelection(userAnswer));

    if(ValidateMenuSelection(userAnswer) == -1)
    {
        Console.WriteLine("That is not a valid selection. Please try again.");
    }
    if (ValidateMenuSelection(userAnswer) == 6)
    {
        Console.WriteLine("Hustle for that muscle. Goodbye!");
        Environment.Exit(0);
    }
}

int ValidateMenuSelection(string option)
{
    try
    {
        int userSelection = Convert.ToInt32(option);
        return userSelection;
    }
    catch (System.FormatException)
    {
        return -1;
    }
}
