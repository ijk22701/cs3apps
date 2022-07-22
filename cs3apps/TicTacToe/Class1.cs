//////////////////////////////////////////////////////////////////////////////////////
//Date         Developer            Description
//2021-03-5   Isaac K         --Creation and completion of test program

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToeTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program is the game Tic Tac Toe");
            Console.WriteLine("The current board will be displayed, and on your turn");
            Console.WriteLine("pick the square on the key that you want to play. The game");
            Console.WriteLine("will end when a winner or stalemate has been found.");
            TicTacToe game = new TicTacToe();
            game.PlayGame();
        }
    }
}
