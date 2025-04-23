using System;
using System.Text.RegularExpressions;
using System.Media;

class MyApp
{
    private static string registeredUsername = "";
    private static string registeredPassword = "";

    static void Main()
    {
        Welcome();
        UserDetails();
        BasicQuestions();
        RegisterUser();
        LoginUser();
    }

    public static void Welcome()
    {
        Console.WriteLine("Welcome to MyApp, we hope you will enjoy having a conversation with us");

        // ASCII logo
        Console.WriteLine("    ____      _                                        _ _            \r\n / ___|   _| |__   ___ _ __ ___  ___  ___ _   _ _ __(_) |_ _   _    \r\n| |  | | | | '_ \\ / _ \\ '__/ __|/ _ \\/ __| | | | '__| | __| | | |   \r\n| |__| |_| | |_) |  __/ |  \\__ \\  __/ (__| |_| | |  | | |_| |_| |   \r\n \\____\\__, |_.__/ \\___|_|  |___/\\___|\\___|\\__,_|_|  |_|\\__|\\__, |   \r\n   / \\|___/   ____ _ _ __ ___ _ __   ___  ___ ___  | __ )  |___/ |_ \r\n  / _ \\ \\ /\\ / / _` | '__/ _ \\ '_ \\ / _ \\/ __/ __| |  _ \\ / _ \\| __|\r\n / ___ \\ V  V / (_| | | |  __/ | | |  __/\\__ \\__ \\ | |_) | (_) | |_ \r\n/_/   \\_\\_/\\_/ \\__,_|_|  \\___|_| |_|\\___||___/___/ |____/ \\___/ \\__|  ");

        // Optional: Play a welcome sound (Windows only)

    }

    public static void UserDetails()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine($"Hi {name}!");
    }

    public static void BasicQuestions()
    {
        Console.Write("Ask me something (e.g., 'How are you?', 'How is your day going?', 'What can i ask you about?'): ");
        string question = Console.ReadLine().ToLower();

        if (question.Contains("how are you"))
            Console.WriteLine("I'm just a program, but I'm doing great! Thanks for asking.");
        if (question.Contains("how is your day"))
            Console.WriteLine("My day is going well, thank you! How about yours?");
        if (question.Contains("What can I ask you about?"))
            Console.WriteLine("I can tell you about multiple things regarding cybersecurity!");
        else
            Console.WriteLine("I'm not sure how to answer that, but I'm happy to chat!");
    }

    public static void RegisterUser()
    {
        Console.Write("Enter your username (must start with 'ST' and contain '@gmail.com' or 'Qiie...'): ");
        string username = Console.ReadLine();

        if (!Regex.IsMatch(username, @"^ST.*(@gmail\.com|Qiie.*)$"))
        {
            Console.WriteLine("Invalid username format. Please try again.");
            return;
        }

        Console.Write("Enter your password (at least 8 chars, 1 uppercase, 1 lowercase, 1 number): ");
        string password = Console.ReadLine();

        if (!Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}$"))
        {
            Console.WriteLine("Password does not meet security requirements.");
            return;
        }

        registeredUsername = username;
        registeredPassword = password;
        Console.WriteLine("Registration successful!");
    }

    public static void LoginUser()
    {
        if (string.IsNullOrEmpty(registeredUsername))
        {
            Console.WriteLine("No user registered. Please register first.");
            return;
        }

        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        if (username == registeredUsername && password == registeredPassword)
            Console.WriteLine("Login successful! Welcome back.");
        else
            Console.WriteLine("Invalid username or password. Try again.");
    }
}

