///////////////////////////////////////////////////////////
/// Change History
/// Date        Developer       Description
/// 2021-03-06  goddard         -creation of file and all method(s)
/// 2021-03-06  goddard         -addition of commenting

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    // this class contains all method(s) for the TicTacToe project
    class Program
    {
        public static int[] board = new int[9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
        public static int playerChoice = 0;

        // current player stored as boolean instead of integer for use in methods and easy inversion 
        // between iterations in main method
        public static bool currentPlayer = false;

        // this main method is used to call the methods used to create a tic tac toe game
        static void Main(string[] args)
        {
            Console.WriteLine(@"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~  TIC TAC TOE   ~~~~~~~~~
Welcome to the Tic-Tac-Toe game!
This is a two player experience
This board is a 3x3 grid
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            
Here is the board:

1   |   2   |   3
4   |   5   |   6
7   |   8   |   9

To place a piece on the board, enter the number that is on that place on the board.
If you choose a spot already claimed, you forfeit your turn. CHOOSE CAREFULLY

            ");
            // local variables for use in do/while loop
            int equivalentInt = 0;
            int playerChoice = 0;

            // while there is no winner and no draw, continue to perform the iterations of the tic-tac-toe game
            do
            {
                // first, show the current state of the board and then prompt the user to select a location
                // to claim
                ShowBoard();
                equivalentInt = Convert.ToInt32(currentPlayer);
                equivalentInt += 1;
                Console.Write($"Player {equivalentInt} please enter where you want to put your next piece: ");
                playerChoice = int.Parse(Console.ReadLine());

                // check to see if it's an empty spot and then go about placing the player token on that spot once verified
                if (board[playerChoice - 1] != 1 && board[playerChoice - 1] != 2)
                {
                    Place(playerChoice - 1, currentPlayer);
                }

                else
                {
                    Console.WriteLine("Sorry, this location is already been claimed!");
                }
                currentPlayer = !currentPlayer;
            } while (Won() != true && Draw() != true);

            // if we've gotten here, someone has either won or a draw has been reached
            // display that info to user and quit
            if (Won() == true)
            {
                Console.WriteLine($"Player {equivalentInt} has won! Congratulations! Here is the final board state:");
                ShowBoard();
                Console.ReadKey();
            }

            // we can safely assume that if won is not true then draw is true because the do/while loop has ended.
            else
            {
                Console.WriteLine("Both players have reached a draw! Here is the final board state:");
                ShowBoard();
                Console.ReadKey();
            }
        }

        // this methods prints out the board array to the console
        private static void ShowBoard()
        {
            Console.WriteLine(board[0] + "  |  " + board[1] + "  |  " + board[2]);
            Console.WriteLine(board[3] + "  |  " + board[4] + "  |  " + board[5]);
            Console.WriteLine(board[6] + "  |  " + board[7] + "  |  " + board[8]);
        }

        // this method takes the placement choice of the player along with the current player boolean
        // and place the current player's token into that space on the board
        private static void Place(int playerChoice, bool currentPlayer)
        {
            // convert boolean and then add 1 to get the equivalent player number
            int equivalentInt = Convert.ToInt32(currentPlayer);
            equivalentInt += 1;

            board[playerChoice] = equivalentInt;
        }

        // this method checks all possible 3x3 tic-tac-toe win states and returns true or false depending on if
        // any of those states have been achieved.
        private static bool Won()
        {
            bool result = false;
            // this long if-elseif block of code checks all possible win states for 3x3 tic-tac-toe
            // going from horizontal, to vertical, to across.
            if (board[0] == board[1] && board[0] == board[2])
            {
                if (!(board[0] == 0))
                {
                    result = true;
                }
            }
            else if (board[3] == board[4] && board[3] == board[5])
            {
                if (!(board[3] == 0))
                {
                    result = true;
                }
            }
            else if (board[6] == board[7] && board[6] == board[8])
            {
                if (!(board[6] == 0))
                {
                    result = true;
                }
            }
            else if (board[0] == board[3] && board[0] == board[6])
            {
                if (!(board[0] == 0))
                {
                    result = true;
                }
            }
            else if (board[1] == board[4] && board[1] == board[7])
            {
                if (!(board[1] == 0))
                {
                    result = true;
                }
            }
            else if (board[2] == board[5] && board[2] == board[8])
            {
                if (!(board[2] == 0))
                {
                    result = true;
                }
            }
            else if (board[0] == board[4] && board[0] == board[8])
            {
                if (!(board[0] == 0))
                {
                    result = true;
                }
            }
            else if (board[2] == board[4] && board[2] == board[6])
            {
                if (!(board[2] == 0))
                {
                    result = true;
                }
            }
            return result;
        }

        // this method checks for the exceptional case where both players have reached a 'draw' in the game and returns
        // true or false.
        private static bool Draw()
        {
            bool result = false;
            int spotsTaken = 0;

            // iterate through entire board and add 1 to spots taken for every spot claimed by a player
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] != 0)
                {
                    spotsTaken++;
                }
            }

            // a draw state is reached when there are no possible moves left to make on the board
            if (spotsTaken >= 9)
            {
                result = true;
            }
            return result;
        }
    }
}
