//////////////////////////////////////////////////////////////////////////////////////
//Date         Developer            Description
//2021-03-3   Isaac K         --Creation of file for program
//2021-03-3   Isaac K         --Completed core functions of program

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elimination
{
    class Program
    {
        private const int Min = 10; //minimum allowed number
        private const int Max = 100; //maximum allowed number
        private const int TotalNumbers = 5; //controls how many numbers the program will process, default is 5
        static void Main(string[] args)
        {         
            PrintIntro();
            int[] array = PromptForNumbers();
            PrintOutput(array);
            PrintExitMessage();
        }

        private static void PrintExitMessage()
        {
            Console.WriteLine("Thank you for using this program!");
        }

        private static int[] PromptForNumbers()
        {
            int[] array = new int[TotalNumbers]; //the main array of the program, holds user input
            for (int i = 0; i < TotalNumbers; i++) { //loop fills each index of the array with a number
                Console.Write($"Enter a number between {Min} and {Max}: ");
                bool valid = false; //whether or not input is valid (within range)

                while (!valid) //will continue until valid input is recieved
                {
                    int response = int.Parse(Console.ReadLine()); //temporarily hold user input before it is checked
                    if (response > Min && response < Max) //this statement is for valid input
                    {
                        array[i] = response;
                        valid = true;
                    } else //this statement is for invalid input
                    {
                        Console.WriteLine("Invalid input, please try again");
                        Console.Write($"Enter a number between {Min} and {Max}: ");
                    }
                }
            }
            return array;
        }

        private static void PrintOutput(int[] array)
        {
            IEnumerable<int> distinct = array.Distinct();
            foreach (int number in distinct) //iterate through distinct numbers in array
            {
                Console.WriteLine(number); //will only print distinct numbers
            }
        }

        private static void PrintIntro()
        {
            Console.WriteLine("This program prompts for 5 numbers between ");
            Console.WriteLine($"{Min} and {Max}. After the 5 numbers are given, this");
            Console.WriteLine("program will return a list of the same numbers");
            Console.WriteLine("with all duplicate numbers removed.");
        }
    }
}
