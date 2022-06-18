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
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public void PrintInformation(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
    }

    public void PrintError(string message)
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine($"{_spacer}{message}{_spacer}");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void PrintMenu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("What do you want?");
        Console.WriteLine("1. Create new user.");
        Console.WriteLine("2. Update an existing user.");
        Console.WriteLine("3. Delete user.");
        Console.WriteLine("4. Show users list.");
        Console.WriteLine("5. Exit.");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
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