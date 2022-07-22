//////////////////////////////////////////////////////////////////////////////////////
//Date         Developer            Description
//2021-03-5   Isaac K         --Creation of file for program
//2021-03-5   Isaac K         --Completed core functions of program
//2021-03-6   Isaac K         --Finished commenting of program

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    class Program
    {

        static void Main(string[] args)
        {
            PrintIntro();
            bool repeat = true;
            bool[] seatingChart = new bool[10]; //0 through 4 is first class, 5 through 9 is economy
            while (repeat)
            {
                DisplayMenu(); //display main menu for program
                int selection = int.Parse(Console.ReadLine()); //get user selection from menu
                switch (selection) //decode user selection
                {
                    case 1:
                        PrintSeatingChart(seatingChart); //print out the current seating chart
                        break;
                    case 2:
                        seatingChart = BookSeat(seatingChart); //book a new seat to the seating chart
                        break;
                    default: //any input that isn't 1 or 2 is treated as a 3 and ends the program
                        repeat = false;
                        break;
                }
            }
            PrintExit(); //print exit message to program
        }

        private static void DisplayMenu()
        {
            Console.WriteLine(@"
**************************************
Please select an option:
[1] Display current seating chart
[2] Add a booking to the seating chart
[3] Exit program
**************************************
");
        }

        private static void PrintIntro()
        {
            Console.WriteLine(@"
*********************************************************************
 This program keeps track of assigned seats on an airline. You will be
 given the opportunity to add bookings in either first class 
 or economy. When the airline is full, you will not be able to add more
 bookings.");
        }

        //this next method gets confusing, but to summarize the process, it first checks for available space,
        //then checks user input for which type of seat they want to book, then checks that type of seat for availability,
        //then gives final options based on that.
        private static bool[] BookSeat(bool[] seatingChart)
        {
            if (FindAvailableSpace(seatingChart)) //check for available space on plane
            {
                Console.WriteLine("Enter [1] to book for first class, or [2] to book for economy. Enter [0] to return to menu.");
                int response = int.Parse(Console.ReadLine()); //capture user input
                if (response == 1) //first class
                {
                    if (CheckFirstClassAvailability(seatingChart)) //check for availability in first class
                    {
                        return BookFirstClass(seatingChart); //returns new seating chart with first class spot booked
                    }
                    else //offer spot in economoy if first class is full
                    {
                        Console.WriteLine("First class is full. Would you like to book for economy instead? [1] for yes, [0] for no");
                        if (PromptYesOrNo())
                        {
                            return BookEconomy(seatingChart); //List has already been checked for available spots, so there should be space in economy. 
                        }
                    }           
                }
                else if (response == 2) //economy
                {
                    if (CheckEcoAvailability(seatingChart)) //check availabiliy in economy
                    {
                        return BookEconomy(seatingChart); //return new seating chart with economy spot booked
                    }
                    else //offer spot in first class if economy is full
                    {
                        Console.WriteLine("Economy is full. Would you like to book first class instead? [1] for yes, [0] for no");
                        if (PromptYesOrNo())
                        {
                            return BookFirstClass(seatingChart); //List has already been checked for available spots, so there should be space in first class. 
                        }
                    }
                } else //user wants to return to menu
                {
                    Console.WriteLine("Returning to menu");
                }
            }
            else //plane is full
            {
                Console.WriteLine("Plane is full.");
                Console.WriteLine("Next flight leaves in 3 hours.");
            }

            return seatingChart; //If code hits here, the returned chart will be no different. 
        }

        private static bool[] BookFirstClass(bool[] seatingChart) //books a first class spot
        {
            for (int i = 0; i < 5; i++) //iterate through first class
            {
                if (seatingChart[i] == false) //skip over filled seats
                {
                    seatingChart[i] = true; //change first empty seat to filled
                    return seatingChart;
                }               
            }
            Console.WriteLine("ERROR - No empty seats! Check that chart is properly searched for empty seats");
            Console.WriteLine("No changes made to seating chart");
            return seatingChart;
        }

        private static bool[] BookEconomy(bool[] seatingChart) //books an economy spot
        {
            for (int i = 5; i < 10; i++) //iterate through economy
            {
                if (seatingChart[i] == false) //skip over filled seats
                {
                    seatingChart[i] = true; //change first empty seat to filled
                    return seatingChart;
                }
            }
            Console.WriteLine("ERROR - No empty seats! Check that chart is properly searched for empty seats");
            Console.WriteLine("No changes made to seating chart");
            return seatingChart;
        }

        /**
         * Made sense to do a proper comment for this method
         * 
         * <summary>Searches for available spots in seating chart</summary>
         * <param name="seatingChart">The seating chart being searched</param>
         * <returns>true indicating there is space, false if there is no space</returns>
         */
        private static bool FindAvailableSpace(bool[] seatingChart) 
        {
            foreach (bool occupied in seatingChart)
            {
                if (occupied == false)
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * <summary>Searches for available spots in first class</summary>
         * <param name="seatingChart">The seating chart being searched</param>
         * <returns>true indicating there is space, false if there is no space</returns>
         */
        private static bool CheckFirstClassAvailability(bool[] seatingChart)
        {
            for (int i = 0; i < 5; i++) //iterate through first class
            {
                if (seatingChart[i] == false) //find first empty eat
                {
                    return true; //first class seating IS available
                }
            }
            return false;
        }

        /**
         * <summary>Searches for available spots in economy</summary>
         * <param name="seatingChart">The seating chart being searched</param>
         * <returns>true indicating there is space, false if there is no space</returns>
         */
        private static bool CheckEcoAvailability(bool[] seatingChart)
        {
            for (int i = 5; i < 10; i++) //iterate through economy
            {
                if (seatingChart[i] == false) //find first empty eat
                {
                    return true; //economy seating IS available
                }
            }
            return false;
        }

        static bool PromptYesOrNo() //yes = true, anything else = no. 
        {
            string reply = Console.ReadLine(); //I used a string instead of parse int so that any unexpected input is treated as a no
            if (reply == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void PrintSeatingChart(bool[] seatingChart) //prints out a formatted seating chart
        {
            Console.WriteLine($"====First class====");
            for (int i = 0; i < 5; i++) //iterate through first class
            {
                string status;
                if (seatingChart[i] == true)
                {
                    status = "Filled"; //print filled when spot is labeled "true"
                } else
                {
                    status = "Empty"; //print empty when spot is labeled "false"
                }
                Console.WriteLine($"Seat {i}: " + status); //print the status for each seat as well as the number of that seat
            }
            Console.WriteLine($"======Economy======");
            for (int i = 5; i < 10; i++)
            {
                string status;
                if (seatingChart[i] == true)
                {
                    status = "Filled"; //print filled when spot is labeled "true"
                }
                else
                {
                    status = "Empty"; //print empty when spot is labeled "false"
                }
                Console.WriteLine($"Seat {i}: " + status); //print the status for each seat as well as the number of that seat
            }
        }

        private static void PrintExit()
        {
            Console.WriteLine("Thank you for using this program!");
        }
    }
}

