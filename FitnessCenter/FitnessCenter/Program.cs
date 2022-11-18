using FitnessCenter;

Console.WriteLine("Welcome to Grand Circus Gym!\nUnless you die, keep going!");
Console.WriteLine("Please choose from the following menu options:");
Console.WriteLine("1. Add Member");
Console.WriteLine("2. Remove Member");
Console.WriteLine("3. Display Member Information");
Console.WriteLine("4. Check Into Club");
Console.WriteLine("5. Check Membership Fee & Points");
string userAnswer = Console.ReadLine();

SubMenuSelection.DisplaySelectedSubMenu(ValidateMenuSelection(userAnswer));


int ValidateMenuSelection(string option)
{
    try
    {
        int userSelection = Convert.ToInt32(option);
        return userSelection;
    }
    catch (ArithmeticException)
    {
        Console.WriteLine("That is not a valid selection. Please try again.");
        return -1;
    }
}
