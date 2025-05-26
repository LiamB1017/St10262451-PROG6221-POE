using System;
using System.Collections.Generic;
using System.Media;
using System.Text.RegularExpressions;

class MyApp
{
    private static string registeredUsername = "";
    private static string registeredPassword = "";
    private static Dictionary<string, string> userMemory = new Dictionary<string, string>();
    private static Random rand = new Random();

    static void Main()
    {
        PlayWelcomeSound();
        Welcome();
        UserDetails();
        BasicQuestions();
        RegisterUser();
        LoginUser();
        Questions();
        StartChatLoop();
    }

    public static void PlayWelcomeSound()
    {
        try
        {
            SoundPlayer player = new SoundPlayer(@"clip-Charlotte-2025_04_23.wav");
            player.Play();
        }
        catch (Exception ex)
        {
            Console.WriteLine("[Audio Error] " + ex.Message);
        }
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
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(@"    ____      _                                        _ _            
 / ___|   _| |__   ___ _ __ ___  ___  ___ _   _ _ __(_) |_ _   _    
| |  | | | | '_ \ / _ \ '__/ __|/ _ \/ __| | | | '__| | __| | | |   
| |__| |_| | |_) |  __/ |  \__ \  __/ (__| |_| | |  | | |_| |_| |   
 \____\__, |_.__/ \___|_|  |___/\___|\___|\__,_|_|  |_|\__|\__, |   
   / \|___/   ____ _ _ __ ___ _ __   ___  ___ ___  | __ )  |___/ |_ 
  / _ \ \ /\ / / _ | '__/ _ \ '_ \ / _ \/ __/ __|  |  _ \ / _ \| __|
 / ___ \ V  V / (_| | | |  __/ | | |  __/\__ \__ \ | |_) | (_) | |_ 
/_/   \_\_/\_/ \__,_|_|  \___|_| |_|\___||___/___/ |____/ \___/ \__|");
        Console.ResetColor();
    }
    public static void UserDetails()
    {
        Console.Write("\nBefore we begin, what's your name? ");
        string name = Console.ReadLine();
        userMemory["name"] = name;

        Console.WriteLine($"Nice to meet you, {name}!");
    }

    public static void BasicQuestions()
    {
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

        Console.Write("\nHow are you feeling today? ");
        string mood = Console.ReadLine();
        userMemory["mood"] = mood;

        if (mood.ToLower().Contains("good") || mood.ToLower().Contains("great") || mood.ToLower().Contains("happy"))
        {
            Console.WriteLine("😊 I'm glad to hear that!");
        }
        else if (mood.ToLower().Contains("bad") || mood.ToLower().Contains("sad") || mood.ToLower().Contains("angry"))
        {
            Console.WriteLine("😔 I'm sorry to hear that. I hope I can help cheer you up!");
        }
        else
        {
            Console.WriteLine("🙂 Thanks for sharing how you're feeling.");
        }
    }

    public static void RegisterUser()
    {
        Console.WriteLine("\n=== User Registration ===");

        Console.Write("Choose a username: ");
        registeredUsername = Console.ReadLine();

        while (true)
        {
            Console.Write("Choose a password (at least 6 characters): ");
            registeredPassword = Console.ReadLine();

            if (registeredPassword.Length < 6)
            {
                Console.WriteLine("⚠️ Password too short. Please try again.");
            }
            else
            {
                break;
            }
        }

        Console.WriteLine("✅ Registration successful!");
    }

    public static void Questions()
    {
        Console.WriteLine("\n=== Chatbot Ready ===");
        Console.WriteLine("Ask me about cybersecurity: password, privacy, phishing, scams, etc.");
        Console.WriteLine("Type 'exit' to end the chat.\n");

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("You: ");
            Console.ResetColor();
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("👋 Thanks for chatting! Stay cyber safe!");
                break;
            }

            KeywordResponder(input);
        }
    }

    public static void LoginUser()
    {
        Console.WriteLine("\n=== User Login ===");

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        if (username == registeredUsername && password == registeredPassword)
        {
            Console.WriteLine("🔓 Login successful. Welcome back!");
        }
        else
        {
            Console.WriteLine("❌ Invalid credentials. Access denied.");
        }
    }

    public static void KeywordResponder(string input)
    {
        input = input.ToLower();

        if (input.Contains("password"))
        {
            List<string> tips = new List<string>
            {
                "Use strong, unique passwords for each account.",
                "Don't reuse passwords across different websites.",
                "Use a password manager to store your passwords.",
                "Include numbers, symbols, and capital letters in your password.",
                "Change your passwords regularly."
            };
            Console.WriteLine(tips[rand.Next(tips.Count)]);
        }
        else if (input.Contains("privacy"))
        {
            List<string> tips = new List<string>
            {
                "Check your privacy settings on social media regularly.",
                "Limit the personal info you share online.",
                "Use incognito/private browsing modes when necessary.",
                "Use VPNs on public Wi-Fi.",
                "Protect your devices with passwords or biometrics."
            };
            Console.WriteLine(tips[rand.Next(tips.Count)]);
        }
        else if (input.Contains("phishing"))
        {
            List<string> tips = new List<string>
            {
                "Don't click on suspicious email links.",
                "Watch for spelling errors in emails.",
                "Be cautious of urgent or threatening messages.",
                "Check the sender’s email address carefully.",
                "Enable multi-factor authentication."
            };
            Console.WriteLine(tips[rand.Next(tips.Count)]);
        }
        else if (input.Contains("scam"))
        {
            List<string> tips = new List<string>
            {
                "Never share personal info with unknown sources.",
                "Don't give out your banking details easily.",
                "Be suspicious of unsolicited phone calls.",
                "If it sounds too good to be true, it probably is.",
                "Verify sources before clicking on offers or giveaways."
            };
            Console.WriteLine(tips[rand.Next(tips.Count)]);
        }
        else
        {
            Console.WriteLine("I'm still learning. Try asking something about passwords, scams, privacy or phishing.");
        }
    }
        public static void StartChatLoop()
    {
        while (true)
        {
            LoginUser();     // Log in again
            Questions();     // Ask more questions after logging in
        }
    }
}
