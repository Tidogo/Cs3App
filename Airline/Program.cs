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

namespace Airline
{
    // this class contains all method(s) for the Airline project
    class Program
    {
        // this method is the driver method for the Airline project
        static void Main(string[] args)
        {
            bool[] seatingChart = new bool[10];
            bool userInput;
            string seatClass = string.Empty;

            // this while loop will continue until there are no more seats to reserve
            while (SeatsAvailable(seatingChart) > 0)
            {
                Console.WriteLine("Hello! This is a seating reservation program for our airline's one airplane." +
                " We have " + SeatsAvailable(seatingChart) + " seats left for reservation.");
                Console.WriteLine("Enter [1] if you would like to reserve a 1st class seat");
                Console.WriteLine("Enter [2] if you would like to reserve an economy seat");
                // the temp value is used in the parseuserinput method to create a user friendly and legible equivalent to the
                // seat type they chose (1 will become 1st class, 2 will become economy).
                int tempValue = int.Parse(Console.ReadLine());

                // it is essential for the userinput to be also stored as a boolean so that it can be used to seat the customer
                // AND ALSO pick a seat in the opposite section when a chosen section is full.
                userInput = Convert.ToBoolean(tempValue-1);

                // store the boolean result to see if it was possible for the customer to get a seat
                bool gotSeat = SeatCustomer(ref seatingChart, userInput);
                seatClass = ParseUserInput(tempValue);

                // if customer was able to get a seat, tell them so and move on
                if (gotSeat == true)
                {
                    Console.WriteLine("Reservation succesful, welcome aboard!");
                }

                // if no seat was available, prompt them to either get a seat in the opposite section or decline and leave
                else
                {
                    Console.WriteLine($"We are sorry, there are no more {seatClass} seats available. " +
                        "Would you like to get reserve a seat in the other section? \n [1] for yes | [2] for no");
                    tempValue = int.Parse(Console.ReadLine());
                    if (tempValue == 1)
                    {
                        // since userInput is a boolean it can be inverted to pick a seat in the other section for this edge case
                        SeatCustomer(ref seatingChart, !userInput);
                        Console.WriteLine("Reservation succesful, welcome aboard!");
                    }

                    // minor problem: technically, there is an infinite loop that can take place if users continually 
                    // request seats that aren't available and don't settle for a seat in the other section
                    else
                    {
                        Console.WriteLine("Next flight leaves in 3 hours.");
                    }
                }
            }
            Console.ReadKey();
        }

        // this method takes an integer and then returns a string equivalent in the context of the Airline main method.
        private static string ParseUserInput(int userInput)
        {
            string result = string.Empty;
            if (userInput == 1)
            {
                result = "1st class";
            }
            else
            {
                result = "economy";
            }
            return result;
        }

        // this method takes a boolean array seatChart *by reference* and a boolean value and uses those to flip a false value to true
        // in that boolean array. the boolean value seatClass is used to figure out what half of the array to search for an open seat
        // in the seatChart array. returns a boolean value representative of whether or not the operation was succesful.
        private static bool SeatCustomer(ref bool[] seatChart, bool seatClass)
        {
            bool result = true;
            // if seatclass is 0, then it is in the 1st class half of the seating chart array
            if (seatClass == false)
            {
                // this block of code goes through the first half of the seatChart array to find an open seat. If an open seat
                // is found, flip the 'false' (open seat) to 'true' (seat taken) and break out of the loop. if no break has happened
                // and i has reached end of the first half of the array, no seats were available, which means that the method will
                // return 'false' (no seat found for customer)
                for (int i = 0; i < seatChart.Length - 5; i++)
                {
                    if (seatChart[i] == false)
                    {
                        seatChart[i] = true;
                        break;
                    }
                    if (i == seatChart.Length - 6)
                    {
                        result = false;
                    }
                }
            }
            // if seatClass is true (1), search the economy class half of the array to find an open seat. Structurally similar to 
            // the search for a 1st class seat.
            else
            {
                for (int i = 9; i >= seatChart.Length - 5; i--)
                {
                    if (seatChart[i] == false)
                    {
                        seatChart[i] = true;
                        break;
                    }
                    if (i == seatChart.Length - 5)
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        // this method searches through the seatingChart boolean array and returns an integer that is representative of how many 'seats'
        // are still open (bool == false) in the seatingChart
        private static int SeatsAvailable(bool[] seatingChart)
        {
            int result = 0;
            for (int i = 0; i < seatingChart.Length; i++)
            {
                if (seatingChart[i] == false)
                {
                    result++;
                }
            }
            return result;
        }
    }

}
