using System;
using System.Speech.Synthesis; // For text-to-speech functionality
using System.Threading; // For typing effect delays to make it feel like a real chat

namespace CyberSecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeBot(); //Calls method to set up the bot with greeting and visuals
            string userName = GetUserName(); //gets and store the username
            MainLoop(userName); // Keeps the conversation going
        }

        // Initializes the bot with a voice greeting and displays ASCII art
        static void InitializeBot() // Method to initialize the bot
        {
            SpeechSynthesizer synth = new SpeechSynthesizer(); // Creates a new SpeechSynthesizer object for text-to-speech
            synth.SetOutputToDefaultAudioDevice();
            synth.Volume = 100; //Set the  volume to maximum
            synth.Rate = 0; // Speak on a normal rate
            string welcomeMessage = "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online!";
            synth.Speak(welcomeMessage); // Converts the welcome message to speech and plays it

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n" + new string('═', 45));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
     ╔════════════════════════════╗
     ║  CyberSecurityAwarenessBot ║
     ╚════════════════════════════╝
               [ ]  [ ]  
               |  --  |
                \____/  
              /|      |\
             / |      | \  
            (  |______|  ) 
            ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('═', 45) + "\n");
            Console.ResetColor();
        }

        // Prompts the user for their name and returns it (formatted)
        static string GetUserName() //Method to get user name
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Welcome to the Cybersecurity Awareness Bot!"); //Display welcome text
            Console.ResetColor();
            Console.Write(" Please enter your name: "); // Prompt user for their name
            string userName = Console.ReadLine()?.Trim(); // Reads inputs and remove extra spaces
            if (string.IsNullOrWhiteSpace(userName)) userName = "User";
            else userName = char.ToUpper(userName[0]) + userName.Substring(1).ToLower(); // Capitalizes first letter, lowercases the rest
            return userName;
        }

        // Handles the main interaction loop with the user
        static void MainLoop(string userName) //Method for the main user interaction loop
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n Hello, {userName}! I'm here to help you with cybersecurity awareness."); // Greets user by name
            Console.WriteLine(" You can ask me about:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   - Password safety");
            Console.WriteLine("   - Phishing");
            Console.WriteLine("   - Safe browsing");
            Console.WriteLine("   - Or type 'help' for more topics");
            Console.WriteLine("   - Type 'quit' to exit");
            Console.ResetColor();
            Console.WriteLine(new string('─', 60) + "\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{userName} : "); //Displays prompts with user's name
                string input = Console.ReadLine()?.ToLower().Trim(); //Reads the user input, converts to lowecase and trims spaces
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(input)) //Checks if the input is empty or just whitespace
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeText(" Oops! You forgot to type something. Try again!");
                    Console.ResetColor();
                    Console.WriteLine("\n" + new string('─', 60));
                    continue; //Skips to the next loop inteaction
                }

                if (input == "quit" || input == "exit") // Checks if user wants to quit
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    TypeText(" Goodbye! Stay safe online, and remember, I'm always here to help!");
                    Console.ResetColor();
                    break; // Exits the loop 
                }

                string response = GetResponse(input); // Gets the bot's response based on user input
                Console.ForegroundColor = ConsoleColor.Yellow;
                TypeText($"Bot: {response}"); //Displays the bot response
              
                Console.ResetColor(); //Resets console colour to default
                Console.WriteLine("\n" + new string('─', 60));
            }
        }

        // Simulates typing effect for a more conversational feel
        static void TypeText(string text) // Method to simulate typing effect
        {
            foreach (char c in text) // Loops through each character in the text
            {
                Console.Write(c);
                Thread.Sleep(30); // Adjust delay (in milliseconds) for typing speed
            }
            Console.WriteLine();
        }

        // Returns a response based on the user's input
        static string GetResponse(string input)
        {
            // Check for different keywords in the input and return appropriate responses
            if (input.Contains("how are you"))
                return "I'm a bot, so I'm always doing great and ready to assist you with cybersecurity tips!";
            else if (input.Contains("what's your purpose") || input.Contains("what is your purpose"))
                return "I'm designed to help you learn about cybersecurity best practices and keep you safe online.";
            else if (input.Contains("what can i ask") || input.Contains("what can i ask you about"))
                return "You can ask me about password safety, phishing scams, safe browsing, or just chat with me by asking 'How are you?' or 'What's your purpose?'";
            else if (input.Contains("password"))
                return "A strong password should be at least 12 characters long and include a mix of uppercase letters, lowercase letters, numbers, and special symbols. Avoid using personal info like your name or birthday!";
            else if (input.Contains("phishing"))
                return "Phishing is a scam where attackers pretend to be legit sources to steal your info, like passwords or credit card details. Verify senders and avoid suspicious links!";
            else if (input.Contains("safe browsing"))
                return "For safe browsing, use 'HTTPS' websites, keep your browser updated, and avoid downloads or links from shady sources.";
            else if (input.Contains("help"))
                return "Here’s what I can help with:\n   - Password safety\n   - Phishing\n   - Safe browsing\n   - 'How are you?'\n   - 'What’s your purpose?'\n   - 'What can I ask you about?'";
            else
                return "Hmm, I didn’t catch that. Could you rephrase your question? I’d love to assist!";
        }
    }
}