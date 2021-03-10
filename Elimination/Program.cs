///////////////////////////////////////////////////////////
/// Change History
/// Date        Developer       Description
/// 2021-03-05  goddard         -creation of file and all method(s)
/// 2021-03-06  goddard         -addition of commenting
/// 2021-03-06  goddard         -added nominal checks for valid input (10-100 inclusive integers)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elimination
{
    // this class contains the Main method for the Elimination program. 
    class Program
    {
        // this main method contains all code for the operation of the Elimination program
        static void Main(string[] args)
        {
            // userInput array will store *all* 5 user inputs
            int[] userInput = new int[5];

            // userInt is a variable to store readline() input temporarily to check in later code
            int userInt = 0;

            Console.WriteLine("Greetings! This program will take 5 integers between 10-100 (inclusive) and only display" +
                " those integers that are not duplicates");
            // outer for loop purpose is to ensure that the program takes in 5 integers and stores them in userInput array
            for (int i = 0; i < userInput.Length; i++)
            {

                // minor note: "i+1" is for readability, otherwise it will display 0-4 which is less user friendly
                Console.Write($"Please enter integer #{i + 1} [10-100]: ");

                // next, store the user input in a temporary variable and check if they've entered a valid int
                userInt = int.Parse(Console.ReadLine());
                if (userInt >= 10 && userInt <= 100)
                {
                    userInput[i] = userInt;
                    // purpose of results var is to create parallel collection with only distinct integers
                    var results = userInput.Distinct();

                    // this foreach loop's purpose is to display only the unique ints that the user has inputted
                    foreach (var result in results)
                    {
                        // bonus "if" statement to avoid printing default integers in result var from the userInput array.
                        if (result != 0)
                        {
                            Console.Write(result.ToString() + " ");
                        }
                    }
                    Console.WriteLine();
                }

                // this is a bit hacky, but the else statement will just inform the user that they've entered an invalid number
                // and continue on to the next iteration of the for loop.
                else
                {
                    Console.WriteLine($"{userInt} is not between 10 and 100 inclusive. Please enter a valid number. Program " +
                        " will ignore your input and continue.");
                }

            }
            // I usually put a readkey or read statement at the end so that I can halt the program from
            // instantly closing after last code is read. Allows for inspection of the console outputs.
            Console.ReadKey();
        }
    }
}
