Console.WriteLine("Welcome to Grand Circus Gym!");
Console.WriteLine("\nUnless you die, keep going!");
Console.WriteLine("\n\nPlease choose from the following menu options:");
Console.WriteLine("1. Add Member");
Console.WriteLine("2. Remove Member");
Console.WriteLine("3. Display Member Information");
Console.WriteLine("4. Check Into Club");
Console.WriteLine("5. Check Membership Fee & Points");
string userAnswer = Console.ReadLine();

if (ValidateMenuSelection(userAnswer) == 4) 
{
    Console.WriteLine("Please select a club:");
    //Write out club options.
}


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