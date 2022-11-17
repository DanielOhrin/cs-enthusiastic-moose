using System;
using Default;

namespace EnthusiasticMoose
{
    class Program
    {
        static void Main()
        {
            //! Uncomment a Game to Play it
            // Games.MagicMoose();
            Games.RockPaperScissors();
        }
    }
    class Games
    {
        internal static void MagicMoose()
        {
            Moose.Says("Ask me a question");

            string question = "initial";

            while (!string.IsNullOrWhiteSpace(question))
            {
                // Waits for the user to ask the moose a question
                question = Console.ReadLine();
                Moose.Answer(question);
            }
        }
        internal static void RockPaperScissors()
        {
            Console.Clear();

            string[] choices = new string[3] { "Rock", "Paper", "Scissors" };
            int[] scores = new int[3] { 0, 0, 0 };
            string result = "";

            Random r = new Random();

            while (scores[0] < 3 && scores[1] < 3)
            {
                Console.WriteLine($@"-----------------------------
| Player: {scores[0]}  |  Computer: {scores[1]} |
-----------------------------
1) Rock
2) Paper
3) Scissors");
                Console.Write("Choose your weapon: ");
                int playerChoice = Convert.ToInt16(Console.ReadLine());
                int computerChoice = r.Next(1, 3);

                Console.Clear();
                Console.WriteLine($"{choices[playerChoice - 1]} vs {choices[computerChoice - 1]}");

                scores[Moose.RPSCalculator(playerChoice, computerChoice)]++;

                if (scores[0] == 3)
                {
                    result = "WIN";
                }
                else if (scores[1] == 3)
                {
                    result = "LOSE";
                }
            }

            Console.Clear();
            Console.WriteLine($"YOU {result}!");
        }
    }
}

namespace Default
{
    class Moose
    {
        internal static void Says(string message)
        {
            Console.WriteLine($@"
                                                _.--^^^--,
                                                .'          `\
            .-^^^^^^-.                      .'              |
            /          '.                   /            .-._/
            |             `.                |             |
            \              \          .-._ |          _   \
            `^^'-.         \_.-.     \   `          ( \__/
                    |             )     '=.       .,   \
                /             (         \     /  \  /
                /`               `\        |   /    `'
                '..-`\        _.-. `\ _.__/   .=.
                    |  _    / \  '.-`    `-.'  /
                    \_/ |  |   './ _     _  \.'
                        '-'    | /       \ |
                                |  .-. .-.  |
                                \ / o| |o \ /
                                |   / \   |    {message}
                                / `^`   `^` \
                                /             \
                                | '._.'         \
                                |  /             |
                                \ |             |
                                ||    _    _   /
                                /|\  (_\  /_) /
                                \ \'._  ` '_.'
                                `^^` `^^^`
                
                ");
        }
        // Defines a function - MooseAsks - with a string parameter that returns a boolean
        internal static bool Ask(string question)
        {
            // Prints the question in Console and awaits a response to store it as "answer"
            // Notice we used .Write instead of .WriteLine -- This allows user input on the same line
            Console.Write($"{question} (Y/N): ");
            string answer = Console.ReadLine().ToLower();

            // Checks if their answer was valid. If not, it will ask again until it gets a valid answer or you stop the app.
            while (answer != "y" && answer != "n")
            {
                Console.Write($"{question} (Y/N): ");
                answer = Console.ReadLine().ToLower();
            }

            // Converts yes/no to true/false and returns it.
            if (answer == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal static void Answer(string question)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                Moose.Says("Goodbye");
                return;
            }

            Random r = new Random();

            // My solutions were to make a List or Array, or use a switch statement
            // If I had done the list/array, I would have initialized a variable with all possible responses, then just did Moose.Says(response[r.Next(0, 19)]) to get a random one

            switch (r.Next(0, 19))
            {
                case 0:
                    Moose.Says("As I see it, yes.");
                    break;
                case 1:
                    Moose.Says("Ask again later.");
                    break;
                case 2:
                    Moose.Says("Better not tell you now.");
                    break;
                case 3:
                    Moose.Says("Cannot predict now.");
                    break;
                case 4:
                    Moose.Says("Concentrate and ask again.");
                    break;
                case 5:
                    Moose.Says("Don't count on it.");
                    break;
                case 6:
                    Moose.Says("It is certain.");
                    break;
                case 7:
                    Moose.Says("It is decidedly so.");
                    break;
                case 8:
                    Moose.Says("Most likely.");
                    break;
                case 9:
                    Moose.Says("My reply is no.");
                    break;
                case 10:
                    Moose.Says("My sources say no.");
                    break;
                case 11:
                    Moose.Says("Outlook not so good.");
                    break;
                case 12:
                    Moose.Says("Outlook good.");
                    break;
                case 13:
                    Moose.Says("Reply hazy, try again.");
                    break;
                case 14:
                    Moose.Says("Signs point to yes.");
                    break;
                case 15:
                    Moose.Says("Very doubtful.");
                    break;
                case 16:
                    Moose.Says("Without a doubt.");
                    break;
                case 17:
                    Moose.Says("Yes.");
                    break;
                case 18:
                    Moose.Says("Yes - definitely.");
                    break;
                case 19:
                    Moose.Says("You may rely on it.");
                    break;
                default:
                    Moose.Says("I am uncertain.");
                    break;
            }
        }
        internal static int RPSCalculator(int playerChoice, int compChoice)
        {
            if (playerChoice == compChoice)
            {
                return 2;
            }

            // Return 1 for player, 2 for Computer
            if (playerChoice == 1)
            {
                switch (compChoice)
                {
                    case 2:
                        return 1;
                    case 3:
                        return 0;
                    default:
                        break;
                }
            }
            else if (playerChoice == 2)
            {
                switch (compChoice)
                {
                    case 1:
                        return 0;
                    case 3:
                        return 1;
                    default:
                        break;
                }
            }
            else if (playerChoice == 3)
            {
                switch (compChoice)
                {
                    case 1:
                        return 1;
                    case 2:
                        return 0;
                    default:
                        break;
                }
            }
            // If user fails to choose a valid answer, computer gets a point
            return 2;
        }
    }
}