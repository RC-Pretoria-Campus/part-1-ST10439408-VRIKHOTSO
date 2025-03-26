using System;
using System.Speech.Synthesis;  //For text-to-speech functionality

namespace CyberSecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize text-to-speech engine for the greeting only
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();  // Use default audio output
            synth.Volume = 100;  // Maximum volume
            synth.Rate = 0;  // Normal speech rate

            // Welcome message that will be spoken aloud
            string welcomeMessage = "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online!";
            synth.Speak(welcomeMessage);  // Speak the welcome message

            // Display enhanced ASCII art with color for visual appeal
            Console.ForegroundColor = ConsoleColor.Yellow;  // Set text color to yellow
            Console.WriteLine(@"
     ╔════════════════════════════╗
     ║  🤖 CyberSec Awareness Bot ║
     ╚════════════════════════════╝
               [ ]  [ ]  
               |  --  |
                \____/  
              /|      |\
             / |      | \  
            (  |______|  ) 
            ");
            Console.ResetColor();  // Reset to default text color

            // Get user's name for personalized interaction
            Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!");
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();

            // Default to "User" if no name is provided
            if (string.IsNullOrWhiteSpace(userName)) userName = "User";

            // Display introduction and available topics
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hello, {userName}! I'm here to help you with cybersecurity awareness.");
            Console.WriteLine("You can ask me about:\n- Password safety\n- Phishing\n- Safe browsing\n- What is my purpose\n- General questions like 'How are you?'\n- Or type 'Quit' to exit");
            Console.ResetColor();
            Console.WriteLine(new string('-', 50));  // Visual separator

            // Main interaction loop
            while (true)
            {
                // Prompt for user input
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{userName}: ");
                string input = Console.ReadLine()?.ToLower();  // Read input and convert to lowercase
                Console.ResetColor();

                // Handle empty input
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Oops! You forgot to type something. Try again!");
                    Console.ResetColor();
                    Console.WriteLine(new string('-', 50));
                    continue;  // Skip to next iteration
                }

                // Exit condition
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) || input.Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Goodbye! Stay safe online, and don't click suspicious links! 😉");
                    Console.ResetColor();
                    break;  // Exit the loop
                }

                // Get and display response based on user input
                string response = GetResponse(input);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Bot: {response}");
                Console.ResetColor();
                Console.WriteLine(new string('-', 50));  // Visual separator
            }
        }

        static string GetResponse(string input)
        {
            // Check for different keywords in the input and return appropriate responses
            if (input.Contains("how are you"))
                return "I'm a bot, so I'm always doing great and ready to assist you with cybersecurity tips!";
            else if (input.Contains("what is your purpose"))
                return "I'm designed to help you learn about cybersecurity best practices and keep you safe online.";
            else if (input.Contains("what can i ask"))
                return "Feel free to ask me about password safety, phishing scams, safe browsing habits, or anything else related to staying secure online!";
            else if (input.Contains("password"))
                return "A strong password should be at least 12 characters long and include a mix of uppercase letters, lowercase letters, numbers, and special symbols. Never use personal information like your name or birthday, as it's easy to guess.";
            else if (input.Contains("phishing"))
                return "Phishing is a cyberattack where scammers pretend to be trustworthy sources to trick you into sharing sensitive information, like passwords or credit card details. Always verify the sender's identity and avoid clicking on suspicious links or attachments.";
            else if (input.Contains("safe browsing"))
                return "To browse safely, stick to websites with 'HTTPS' in the URL, keep your browser and security software up to date, and avoid downloading files or clicking links from untrusted sources.";
            else
                return "Hmm, I didn't quite catch that. Could you please rephrase your question? I'd love to help!";
        }
    }
}