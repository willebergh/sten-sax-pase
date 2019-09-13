using System;

class MainClass
{
    public static void Main(string[] args)
    {

        Console.Clear();

        // Print welcome message
        Console.WriteLine("Välkommen till dampgang's sten-sax-påse");

        // Ask if the user is ready
        Console.Write("Är du redo att spela och lovar du att inte gråta? (Y/N) ");
        string isPlayerReady = Console.ReadLine();

        // Check if isPlayerReady is a valid awnser
        if (isPlayerReady.ToLower() == "y" || isPlayerReady.ToLower() == "n")
        {

            // If the player is ready; start the game
            // else ask if user if they are sure to quit
            if (isPlayerReady.ToLower() == "y")
            {

                Game();

            }
            else
            {

                Console.Write("Är du säker att du vill avsluta? (Y/N) ");
                string awnser = Console.ReadLine();

                if (awnser.ToLower() == "n")
                {

                    Game();

                }
                else
                {

                    Console.WriteLine("Quitting...");

                }

            }

        }

    }

    private static async void Game()
    {

        Console.Clear();
        Console.WriteLine("============================================="); // Line 0
        Console.WriteLine("DampGang DampGang DampGang DampGang DampGang"); // Line 1
        Console.WriteLine("DampGang DampGang DampGang DampGang DampGang"); // Line 2
        Console.WriteLine("DampGang DampGang DampGang DampGang DampGang"); // Line 3
        Console.WriteLine("DampGang DampGang DampGang DampGang DampGang"); // Line 4
        Console.WriteLine("DampGang DampGang DampGang DampGang DampGang"); // Line 5
        Console.WriteLine("============================================="); // Line 6
        Console.WriteLine("Starting the game! Let's go."); // Line 7
        Console.WriteLine(""); // Line 8



        int roundNr = 0;

        string winner = "";
        string playerOneName = "";
        string playerTwoName = "";
        int playerOnePoints = 0;
        int playerTwoPoints = 0;

        bool gameHasStarted = false;
        bool gameHasEnded = false;



        if (!gameHasStarted)
        {

            Console.WriteLine("Please enter your names");

            // Get name for player 1
            Console.Write("Player 1: ");
            playerOneName = Console.ReadLine();

            // Get name for player 2
            Console.Write("Player 2: ");
            playerTwoName = Console.ReadLine();

            // Clear
            Console.SetCursorPosition(0, 10); Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.SetCursorPosition(0, 11); Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");

            gameHasStarted = true;

        }

        while (!gameHasEnded)
        {

            // Update round number
            roundNr++;
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("Round: " + roundNr.ToString()); // Line 9

            // Update player scores
            Console.SetCursorPosition(0, 11);
            Console.WriteLine(playerOneName + ": " + playerOnePoints.ToString()); // Line 11

            Console.SetCursorPosition(0, 12);
            Console.WriteLine(playerTwoName + ": " + playerTwoPoints.ToString()); // Line 12

            // Clear for next round
            for (var i = 13; i < 22; i++)
            {
                Console.SetCursorPosition(0, i); Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            }
            Console.SetCursorPosition(0, 14);




            string roundWinner = Round(playerOneName, playerTwoName);

            if (roundWinner == "playerOne")
            {

                playerOnePoints++;
                if (playerOnePoints == 3)
                {

                    winner = playerOneName;
                    gameHasEnded = true;

                }
                else
                {

                    // Update player scores
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine(playerOneName + ": " + playerOnePoints.ToString()); // Line 11
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine(playerTwoName + ": " + playerTwoPoints.ToString()); // Line 12

                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(playerOneName + " wins round " + roundNr.ToString());

                    Console.WriteLine("Press ENTER to continue");
                    do
                    {
                        while (!Console.KeyAvailable)
                        {

                        }
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);


                }

            }
            else if (roundWinner == "playerTwo")
            {

                playerTwoPoints++;
                if (playerTwoPoints == 3)
                {

                    winner = playerTwoName;
                    gameHasEnded = true;

                }
                else
                {

                    // Update player scores
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine(playerOneName + ": " + playerOnePoints.ToString()); // Line 11
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine(playerTwoName + ": " + playerTwoPoints.ToString()); // Line 12

                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(playerTwoName + " wins round " + roundNr.ToString());

                    Console.WriteLine("Press ENTER to continue");
                    do
                    {
                        while (!Console.KeyAvailable)
                        {

                        }
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);


                }

            }
            else
            {

            }



        }

        // Update player scores
        Console.SetCursorPosition(0, 11);
        Console.WriteLine(playerOneName + ": " + playerOnePoints.ToString()); // Line 11
        Console.SetCursorPosition(0, 12);
        Console.WriteLine(playerTwoName + ": " + playerTwoPoints.ToString()); // Line 12

        for (var i = 13; i < 22; i++)
        {
            Console.SetCursorPosition(0, i); Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
        }
        Console.SetCursorPosition(0, 15);

        // Print the winner!
        if (winner == playerOneName)
        {
            Console.WriteLine(playerOneName + " won with " + playerOnePoints.ToString() + " - " + playerTwoPoints.ToString());
        }
        else
        {
            Console.WriteLine(playerTwoPoints + " won with " + playerTwoPoints.ToString() + " - " + playerOnePoints.ToString());
        }

        Console.WriteLine("Game complete. Thanks for playing :()");
        Console.WriteLine("The game was developed by Willim Bergh");
        Console.WriteLine("https://github.com/willebergh");

    }

    private static string Round(string playerOneName, string playerTwoName)
    {

        Console.WriteLine("Välj sten, sax eller påse");

        // Get player 1 input
        Console.Write(playerOneName + ": ");
        string playerOneInput = HiddenInput();
        Console.WriteLine("");

        // Get player 2 input
        Console.Write(playerTwoName + ": ");
        string playerTwoInput = HiddenInput();
        Console.WriteLine("");

        Console.SetCursorPosition(playerOneName.Length + 2, 15);
        Console.WriteLine(playerOneInput);
        Console.SetCursorPosition(playerTwoName.Length + 2, 16);
        Console.WriteLine(playerTwoInput);

        if (playerOneInput == playerTwoInput)
        {
            return "draw";
        }

        switch (playerOneInput)
        {

            case "sten":
                if (playerTwoInput == "påse")
                {
                    return "playerTwo";
                }
                else
                {
                    return "playerOne";
                }

            case "sax":
                if (playerTwoInput == "sten")
                {
                    return "playerTwo";
                }
                else
                {
                    return "playerOne";
                }

            case "påse":
                if (playerTwoInput == "sax")
                {
                    return "playerTwo";
                }
                else
                {
                    return "playerOne";
                }

            default: return "error";

        }



    }

    private static string HiddenInput()
    {
        string input = "";
        do
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            // Backspace Should Not Work
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                input += key.KeyChar;
            }
            else
            {
                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, (input.Length - 1));
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        } while (true);

        return input;
    }
}

