using Domains;
using Microsoft.AspNetCore.Identity;

namespace CreateUserApp;

public class CreateUserService
{
    private readonly UserManager<User> _userManager;
    private readonly Printer _printer;
    private readonly Validation _validation;
    private bool IsRunning { get; set; } = true;

    public CreateUserService(UserManager<User> userManager, Printer printer, Validation validation)
    {
        _userManager = userManager;
        _printer = printer;
        _validation = validation;
    }

    public void Run()
    {
        while (IsRunning)
        {
            try
            {
                Execute();
            }
            catch (CreateUserException e)
            {
                _printer.PrintError(e.Message);
            }
        }
    }

    private void Execute()
    {
        _printer.PrintMenu();
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CreateUser();
                break;
            case "2":
                UpdateUser();
                break;
            case "3":
                DeleteUser();
                break;
            case "4":
                Exit();
                break;
            default:
                _printer.PrintError("Unknown command!");
                break;
        }
    }

    private void Exit()
    {
        IsRunning = false;
        _printer.PrintSuccess("Buy!");
    }

    private void CreateUser()
    {
        var userDto = CollectAndValidateUserInput();
        var user = new User
        {
            Email = userDto.Email,
            UserName = userDto.Username,
        };

        var res = _userManager.CreateAsync(user, userDto.Password).GetAwaiter().GetResult();

        if (!res.Succeeded)
        {
            _printer.PrintErrorIdentityErrors(res);
        }
        else
        {
            _printer.PrintSuccess("Success!");
        }
    }

    private void UpdateUser()
    {
        Console.WriteLine("Enter Email:");
        var email = Console.ReadLine();
        _validation.ValidateEmailOrThrow(email);

        var user = GetUserByEmailOrThrow(email);

        var userDto = CollectAndValidateUserInput();

        user.Email = userDto.Email;
        user.UserName = userDto.Username;
        _userManager.UpdateAsync(user).GetAwaiter().GetResult();
        _userManager.RemovePasswordAsync(user).GetAwaiter().GetResult();
        _userManager.AddPasswordAsync(user, userDto.Password).GetAwaiter().GetResult();
        _printer.PrintSuccess("Success!");
    }

    private void DeleteUser()
    {
        Console.WriteLine("Enter Email:");
        var email = Console.ReadLine();
        _validation.ValidateIfEmailCorrectOrThrow(email);
        var user = GetUserByEmailOrThrow(email);

        var res = _userManager.DeleteAsync(user).GetAwaiter().GetResult();

        if (!res.Succeeded)
        {
            _printer.PrintErrorIdentityErrors(res);
        }

        _printer.PrintSuccess("Success!");
    }

    private UserDto CollectAndValidateUserInput()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Enter Username:");
        var username = Console.ReadLine();

        _validation.ValidateUsernameOrThrow(username);

        Console.WriteLine("Enter Email:");
        var email = Console.ReadLine();
        _validation.ValidateEmailOrThrow(email);

        Console.WriteLine("Enter Password:");
        var password = Console.ReadLine();

        return new UserDto(username: username, email: email, password: password);
    }

    private User GetUserByEmailOrThrow(string email)
    {
        var user = _userManager.FindByEmailAsync(email).GetAwaiter().GetResult();

        if (user == null)
        {
            throw new CreateUserException("User not found!");
        }

        return user;
    }
}