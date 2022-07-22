//////////////////////////////////////////////////////////////////////////////////////
//Date         Developer            Description
//2021-03-5   Isaac K         --Creation of file for program
//2021-03-6   Isaac K         --Completed core functions of program

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        private int[,] gameBoard; //the board for tic tac toe
        public TicTacToe() {
            gameBoard = new int[3, 3]; //creates a 3x3 game board
        }

        public void PlayGame()
        {
            bool gameFinished = false;
            int player = 1;
            while (!gameFinished) //repeats until game is finished (win or stalemate)
            {
                PrintBoard(); //print out the current game board
                GetUserInput(player); //get the valid input from the user and place it on the board
                gameFinished = CheckBoard(); //check the board for wins or stalemates
                player = SwitchPlayer(player); //changes to other player for next loop
            }
        }

        /**
         * <summary>Switches the active player</summary>
         * <param name="player">The current turn's player</param>
         * <returns>The player for next turn</returns>
         */
        private int SwitchPlayer(int player)
        {
            if (player == 1) { return 2; } //switch to player 2 if on player 1
            if (player == 2) { return 1; } //switch to player 1 if on player 2
            Console.WriteLine("Error - player not switched, check SwitchPlayer method"); //something went wrong if it reaches this point
            return 1; //shouldn't reach here, if it does first player goes
        }


        /**
         * <summary>Gets space selection from the user and changes that tile to indicate the user picked it</summary>
         * <param name="playerNum">The current player</param>
         */
        private void GetUserInput(int playerNum) //1 = player 1 | 2 = player 2
        {
            bool availableSpace = false;
            bool validAnswer = false;

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (gameBoard[r, c] == 0) { availableSpace = true; }
                }
            }

            while (availableSpace && !validAnswer) //Will not start if no available square, will stop when a valid square is picked. 
            {
                int arrayX = 0; //x coordinate on array (aka row)
                int arrayY = 0; //y coordinate on array (aka collumn)
                Console.WriteLine($"Player {playerNum}, enter the number of the square you want to play (key below)");
                Console.WriteLine("         [1 2 3]");
                Console.WriteLine("         [4 5 6]");
                Console.WriteLine("         [7 8 9]");
                int selection = int.Parse(Console.ReadLine());

                switch (selection) //get coordinates of selection
                {
                    case (1):
                        arrayX = 0;
                        arrayY = 0;
                        break;
                    case (2):
                        arrayX = 0;
                        arrayY = 1;
                        break;
                    case (3):
                        arrayX = 0;
                        arrayY = 2;
                        break;
                    case (4):
                        arrayX = 1;
                        arrayY = 0;
                        break;
                    case (5):
                        arrayX = 1;
                        arrayY = 1;
                        break;
                    case (6):
                        arrayX = 1;
                        arrayY = 2;
                        break;
                    case (7):
                        arrayX = 2;
                        arrayY = 0;
                        break;
                    case (8):
                        arrayX = 2;
                        arrayY = 1;
                        break;
                    case (9):
                        arrayX = 2;
                        arrayY = 2;
                        break;
                }

                if (gameBoard[arrayX, arrayY] == 0)
                { //0 is the int used when empty, so "if coordinate is empty"
                    gameBoard[arrayX, arrayY] = playerNum;
                    validAnswer = true;
                }
                else
                { 
                    Console.WriteLine("That board spot is already taken. Please select an open space. ");
                    PrintBoard();
                }

            }
        }

        /**
         * <summary>Checks the board for wins or stalemates</summary>
         * <returns>whether or not a stalemate or win has been detected (true means stalemate or win found, stop the game)</returns>
         */
        private bool CheckBoard()
        {
            for (int c = 0; c < 3; c++) //check horizontal rows
            {
                //player 1 wins
                if (gameBoard[c,0] == 1 && gameBoard[c,1] == 1 && gameBoard[c,2] == 1)
                {
                    Console.WriteLine("Player 1 has won the game");
                    PrintBoard();
                    return true; //These "return true" statements are to indicate that the game is over
                }
                //player 2 wins
                if (gameBoard[c, 0] == 2 && gameBoard[c, 1] == 2 && gameBoard[c, 2] == 2)
                {
                    Console.WriteLine("Player 2 has won the game");
                    PrintBoard();
                    return true;
                }
            }

            for (int r = 0; r < 3; r++) //check vertical rows
            {
                //player 1 wins
                if (gameBoard[0, r] == 1 && gameBoard[1, r] == 1 && gameBoard[2, r] == 1)
                {
                    Console.WriteLine("Player 1 has won the game");
                    PrintBoard();
                    return true;
                }
                //player 2 wins
                if (gameBoard[0, r] == 2 && gameBoard[1, r] == 2 && gameBoard[2, r] == 2)
                {
                    Console.WriteLine("Player 2 has won the game!");
                    PrintBoard();
                    return true;
                }
            }
            //last two if statements check diagonal rows
            //player 1 wins
            if (gameBoard[0,0] == 1 && gameBoard[1,1] == 1 && gameBoard[2,2] == 1 || 
                gameBoard[0,2] == 1 && gameBoard[1,1] == 1 && gameBoard[2,0] == 1)
            {
                Console.WriteLine("Player 1 has won the game");
                PrintBoard();
                return true;
            }
            //player 2 wins
            if (gameBoard[0, 0] == 2 && gameBoard[1, 1] == 2 && gameBoard[2, 2] == 2 ||
                gameBoard[0, 2] == 2 && gameBoard[1, 1] == 2 && gameBoard[2, 0] == 2)
            {
                Console.WriteLine("Player 2 has won the game");
                PrintBoard();
                return true;
            }

            bool stalemate = true;

            //nested loop checks all board spaces for empty spaces
            //no empty spaces and no win from above would equal a stalemate, both sides tie
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (gameBoard[r, c] == 0) //check for an empty space
                    {
                        stalemate = false; //there is no stalemate, game can continue
                    }
                }
            }
            if (stalemate) //if there is a stalemate
            {
                Console.WriteLine("Stalemate - both sides tie!");
                PrintBoard();
                return true; //game is over
            }

            //If code makes it here without returning, the game can continue.
            //On a large scale, this many if/else statements per iteration can be
            //very inefficient, but it should be okay for a small game like this. 
            //There is probably a better way to check for wins though, that may be
            //worth looking into in the future. 
            return false;
        }

      
        /**
         * <summary>Prints out the current game board</summary>
         */
        public void PrintBoard()
        {
            Console.WriteLine("    ===Current Board===");
            Console.WriteLine("         =========");

            for (int r = 0; r < 3; r++) //iterate through board to get each value
            {
                Console.Write("         | ");
                for (int c = 0; c < 3; c++)
                {                  
                    Console.Write(gameBoard[r, c] + " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("         =========");
        }
    }
}
