using Microsoft.Extensions.DependencyInjection;
using TgChecker.Console;
using TgChecker.Lib;

var checker = DependencyAccessor.ServiceProvider.GetRequiredService<TgCheckerService>();

checker.GetVerificationCode += () => 
{
    Console.Write("Please enter your verification code: ");
    return Console.ReadLine()!;
};

Console.Write("Please enter your phone number: ");
string phoneNumber = Console.ReadLine()!;

Console.Write("Please enter your password or skip: ");
string password = Console.ReadLine()!;

checker.ListenTgAccount(phoneNumber, password);

Console.ReadKey();
