using System;
using System.Speech.Synthesis;

namespace CyberSecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up the tool that turns text into speech
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Volume = 100; // Make the voice as loud as possible
            synth.Rate = 0; // Keep the speaking speed normal

            // Create a welcome message for the bot to say out loud
            string welcomeMessage = "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online";
            synth.Speak(welcomeMessage); // Make the bot say the welcome message

            // Show ASCII design in the console
            Console.WriteLine(@"
  ┌───────┐ 
  │  _ _  │
  │       │
  │   -   │
  └───────┘ 
  |       |
  |       |
            ");

            // Say hi to the user and ask for their name
            Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!");
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userName)) userName = "User"; // If user don’t type a name, call them "User"

            // Change the text color to yellow for these lines
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hello, {userName}! I'm here to help you with cybersecurity awareness.");
            Console.WriteLine("You can ask me about password safety, phishing, safe browsing, what is my purpose or general questions like 'How are you?' or Quit/Exit");
            Console.ResetColor(); // Switch the text color back to normal

            Console.WriteLine(new string('-', 50)); // Draw a line to separate things

            // Start a loop to keep talking to the user
            while (true)
            {
                // Change the text color to cyan for the user’s input
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{userName}: "); // Show the user’s name and wait for their question
                string input = Console.ReadLine()?.ToLower(); // Get what they type and make it all lowercase

                // If they didn’t type anything, tell them to ask something
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please ask me a question.");
                    Console.ResetColor();
                    Console.WriteLine(new string('-', 50));
                    continue; // Go back to the start of the loop
                }

                // If they say "exit" or "quit," say goodbye and stop the program
                if (input.Contains("exit") || input.Contains("quit"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Goodbye! Stay safe online.");
                    Console.ResetColor();
                    break; // Stop the loop and end the program
                }

                // Change the text color to yellow and give an answer
                Console.ForegroundColor = ConsoleColor.Yellow;
                string response = GetResponse(input); // Get the bot’s answer based on what the user asked
                Console.WriteLine($"Bot: {response}"); // Show the bot’s answer
                Console.ResetColor();
                Console.WriteLine(new string('-', 50)); // Draw another line
            }
        }

        // This part figures out what to say based on the user’s question
        static string GetResponse(string input)
        {
            if (input.Contains("how are you"))
                return "I'm a bot, so I'm always doing great and ready to assist you with cybersecurity tips!";
            else if (input.Contains("what is your purpose"))
                return "I'm designed to help you learn about cybersecurity best practices and keep you safe online.";
            else if (input.Contains("what can i ask"))
                return "Feel free to ask me about password safety, phishing scams, safe browsing habits, or anything else related to staying secure online!";
            else if (input.Contains("password"))
                return "A strong password should be at least 12 characters long and include a mix of uppercase letters, lowercase letters, numbers, and special symbols. Never use personal information like your name or birthday, as it’s easy to guess.";
            else if (input.Contains("phishing"))
                return "Phishing is a cyberattack where scammers pretend to be trustworthy sources to trick you into sharing sensitive information, like passwords or credit card details. Always verify the sender’s identity and avoid clicking on suspicious links or attachments.";
            else if (input.Contains("safe browsing"))
                return "To browse safely, stick to websites with 'HTTPS' in the URL, keep your browser and security software up to date, and avoid downloading files or clicking links from untrusted sources.";
            else
                return "Hmm, I didn’t quite catch that. Could you please rephrase your question? I’d love to help!";
        }
    }
}