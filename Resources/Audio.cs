using System;
using System.Media;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=====================================");
        Console.WriteLine("       🚀 Welcome to My App!");
        Console.WriteLine("=====================================");
        Console.ResetColor();

        PlayWelcomeSound();

        // Your app logic here...
    }

    static void PlayWelcomeSound()
    {
        try
        {
            string soundFilePath = "Assets/clip-Charlotte-2025_04_23.wav"; // Adjust path as needed
            using (SoundPlayer player = new SoundPlayer(soundFilePath))
            {
                Console.WriteLine("\n🔊 Playing welcome audio...\n");
                player.PlaySync(); // PlaySync waits until it finishes playing
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"⚠️ Error playing sound: {ex.Message}");
            Console.ResetColor();
        }
    }
}
