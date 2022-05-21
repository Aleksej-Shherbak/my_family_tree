using Microsoft.AspNetCore.Identity;

namespace CreateUserApp;

public class Printer
{
    private readonly string _spacer = new(' ', 20);

    public void PrintSuccess(string message)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine($"{_spacer}{message}{_spacer}");
    }

    public void PrintError(string message)
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine($"{_spacer}{message}{_spacer}");
    }

    public void PrintMenu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("What do you want?");
        Console.WriteLine("1. Create new user.");
        Console.WriteLine("2. Update an existing user.");
        Console.WriteLine("3. Delete user.");
        Console.WriteLine("4. Exit.");
    }

    public void PrintErrorIdentityErrors(IdentityResult res)
    {
        PrintError("Can not create user. Errors:");
        foreach (var resError in res.Errors)
        {
            PrintError($"{resError.Code}: {resError.Description}");
        }
    }
}