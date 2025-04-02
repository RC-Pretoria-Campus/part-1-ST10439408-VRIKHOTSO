using System;
using System.Speech.Synthesis;  // For text-to-speech functionality

namespace CyberSecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeBot(); //Calls method to set up the bot with greeting and visuals
            string userName = GetUserName(); //gets and store the username
            MainLoop(userName);
        }

        // Initializes the bot with a voice greeting and displays ASCII art
        static void InitializeBot()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Volume = 100; //Set the  volume to maximum
            synth.Rate = 0; // Speak on a normal rate
            string welcomeMessage = "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online!"; 
            synth.Speak(welcomeMessage);

            // Enhanced ASCII art with colored borders for visual appeal
            Console.ForegroundColor = ConsoleColor.White; //Sets console colour white
            Console.WriteLine(new string('-', 50)); //Sets - 50 white line
            Console.ForegroundColor = ConsoleColor.Yellow; //Changes console colour to yellow
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
            Console.WriteLine(new string('-', 50));
            Console.ResetColor();
        }

        // Prompts the user for their name and returns it (formatted)
        static string GetUserName() //Method to get user name
        {
            Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!"); //Display welcome text
            Console.Write("Please enter your name: "); // Prompt user for their name
            string userName = Console.ReadLine()?.Trim(); // Reads inputs and remove extra spaces
            if (string.IsNullOrWhiteSpace(userName)) userName = "User";
            else userName = char.ToUpper(userName[0]) + userName.Substring(1).ToLower();
            return userName;
        }

        // Handles the main interaction loop with the user
        static void MainLoop(string userName) //Method for the main user interaction loop
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hello, {userName}! I'm here to help you with cybersecurity awareness."); // Greets user by name
            Console.WriteLine("You can ask me about:\n- Password safety\n- Phishing\n- Safe browsing\n- Or type 'help' for a list of topics\n- Type 'quit' to exit");
            Console.ResetColor();
            Console.WriteLine(new string('-', 50));

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{userName}: "); //Displays prompts with user's name
                string input = Console.ReadLine()?.ToLower().Trim(); //Reads the user input, converts to lowecase and trims spaces
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(input)) //Checks if the input is empty or just whitespace
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Oops! You forgot to type something. Try again!");
                    Console.ResetColor();
                    Console.WriteLine(new string('-', 50));
                    continue; //Skips to the next loop inteaction
                }

                if (input == "quit" || input == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Goodbye! Stay safe online, and remember, I'm just a bot, but I'm always here to help!");
                    Console.ResetColor();
                    break; // Exits the loop 
                }

                string response = GetResponse(input);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Bot: {response}"); //Displays the bot response
                Console.ResetColor(); //Resets console colour to default
                Console.WriteLine(new string('-', 50));
            }
        }

        // Returns a response based on the user's input
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
