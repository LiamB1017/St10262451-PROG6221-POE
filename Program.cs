using System;
using System.Text.RegularExpressions;

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
        Questions();
        LoginUser();
    }

    public static void Welcome()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=============================================================");
        Console.WriteLine("           Welcome to MyApp!");
        Console.WriteLine("   We hope you enjoy having a conversation with us.");
        Console.WriteLine("=============================================================");
        Console.ResetColor();

        // ASCII logo
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"    ____      _                                        _ _            
 / ___|   _| |__   ___ _ __ ___  ___  ___ _   _ _ __(_) |_ _   _    
| |  | | | | '_ \ / _ \ '__/ __|/ _ \/ __| | | | '__| | __| | | |   
| |__| |_| | |_) |  __/ |  \__ \  __/ (__| |_| | |  | | |_| |_| |   
 \____\__, |_.__/ \___|_|  |___/\___|\___|\__,_|_|  |_|\__|\__, |   
   / \|___/   ____ _ _ __ ___ _ __   ___  ___ ___  | __ )  |___/ |_ 
  / _ \ \ /\ / / _ | '__/ _ \ '_ \ / _ \/ __/ __| |  _ \ / _ \| __|
 / ___ \ V  V / (_| | | |  __/ | | |  __/\__ \__ \ | |_) | (_) | |_ 
/_/   \_\_/\_/ \__,_|_|  \___|_| |_|\___||___/___/ |____/ \___/ \__|");
        Console.ResetColor();
    }

        // Optional: Play a welcome sound (Windows only)
      

    public static void UserDetails()
    {
        Console.Write("\nPlease enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine($"Hi {name}!");
    }

    public static void BasicQuestions()
    {
        Console.Write("\nAsk me something (e.g., 'How are you?', 'How is your day going?', 'What can I ask you about?'): ");
        string question = Console.ReadLine().ToLower();

        if (question.Contains("how are you"))
            Console.WriteLine("I'm just a program, but I'm doing great! Thanks for asking.");
        else if (question.Contains("how is your day"))
            Console.WriteLine("My day is going well, thank you! How about yours?");
        else if (question.Contains("what can i ask you about"))
            Console.WriteLine("I can tell you about multiple things regarding cybersecurity, such as password safety, phishing and safe browsing!");
        else
            Console.WriteLine("I'm not sure how to answer that, but I'm happy to chat!");
    }

    public static void Questions()
    {
        Console.Write("\nAsk me something about cybersecurity (e.g., 'Tell me about password safety', 'Tell me about phishing', 'Tell me about safe browsing'): ");
        string question = Console.ReadLine().ToLower();

        if (question.Contains("password safety"))
            Console.WriteLine("Password safety includes creating unique, complex passwords, using password managers, and avoiding reuse of passwords.");
        else if (question.Contains("phishing"))
            Console.WriteLine("Phishing is a cybercrime where attackers trick individuals into revealing sensitive information, like passwords or credit card details.");
        else if (question.Contains("safe browsing"))
            Console.WriteLine("Safe browsing means avoiding suspicious links, keeping your browser updated, and using tools that block malicious websites.");
        else
            Console.WriteLine("I'm not sure how to answer that, but I'm happy to chat!");
    }

    public static void RegisterUser()
    {
        Console.Write("\nEnter your username (must start with 'ST' and contain '@gmail.com'): ");
        string username = Console.ReadLine();

        while (!Regex.IsMatch(username, @"^ST.*@gmail\.com$"))
        {
            Console.WriteLine("Invalid username format. Try again.");
            Console.Write("Enter your username (must start with 'ST' and contain '@gmail.com'): ");
            username = Console.ReadLine();
        }

        Console.Write("Enter your password (min 8 characters, must include uppercase, lowercase, number and symbol): ");
        string password = Console.ReadLine();

        while (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$"))
        {
            Console.WriteLine("Password does not meet the criteria. Try again.");
            Console.Write("Enter your password: ");
            password = Console.ReadLine();
        }

        registeredUsername = username;
        registeredPassword = password;
        Console.WriteLine("Registration successful!");
    }

    public static void LoginUser()
    {
        Console.WriteLine("\nNow, please log in.");

        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        if (username == registeredUsername && password == registeredPassword)
            Console.WriteLine("Login successful! Welcome back.");
        else
            Console.WriteLine("Login failed. Incorrect username or password.");
    }
}

