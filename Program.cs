using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment1_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of           squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);

        }

        
        private static void printTriangle(int n)
        {
            try
            {
                // write your code here
                int x, y, count = 1; // declaring the required integers
                count = n - 1; // updating count 
                for (y = 1; y <= n; y++)
                {
                    for (x = 1; x <= count; x++) // Print the spaces in the pattern
                        Console.Write(" ");
                    count--;                    // decrementing the count value 
                    for (x = 1; x <= 2 * y - 1; x++)
                        Console.Write("*");    // loop for printing * 
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
            catch (Exception)
            {

                throw;
            }

        }

        
        public static int printPellSeries(int n2)
        {
            try
            {

                if (n2 < 2)                           
                    return n2;
                int a = 0;                       
                int b = 1;                              
                Console.Write(a + " ");                 // printing the first two terms of the sequence
                Console.Write(b + " ");                 
                int c;                                  // declaring an int variable for the next term in the pell series
                for (int i = 3; i <= n2; i++)           //  Loop to print the pellseries
                {
                    c = 2 * b + a;                      // Calculating the number from the previous two numbers in the sequence
                    a = b;                              // To use the variables - reassign
                    b = c;                              //  To use the variables - reassign
                    Console.Write(b + " ");             // Displaying the pellseries
                }

                return b;
            }

            catch (Exception e)
            {

                Console.WriteLine("Please enter a valid input " + e.Message);                    // to throw an alert message for an invalid input
                throw;
            }
        }


     

        private static bool squareSums(int n3)
        {
            try
            {
                // write your code here\
                int x, y; //declare two integers
                for (x = 0; x * x <= n3; x++) // for loop with max value less than or equal to n3
                {
                    for (y = 0; y * y <= n3; y++)
                    {
                        if (x * x + y * y == n3) // comparing the sum of squares of both the integers
                            return true;

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        private static int diffPairs(int[] nums, int k)
        {
            var d = new Dictionary<int, int>(); // To store the values 
            for (int x = 0; x < nums.Length; x++)
            {
                if (!d.ContainsKey(nums[x]))
                {
                    d.Add(nums[x], 1); // Add the value if the key doesn't exists
                }
                else
                    d[nums[x]]++; // Increment if the key exists
            }

            if (k == 0)
            {
                return d.Where(y => y.Value > 1).ToList().Count; // return to dictionary if k=0
            }

            int pairs = 0;
            foreach (var item in d.Keys)
            {
                if (d.ContainsKey(item + k)) //Any value in the dictionary = Sum of the value at some index + k 
                    pairs++; // Increment pairs if the value exists 
            }


            return pairs; //return the number of pairs 
        }

       

        private static int UniqueEmails(List<string> emails)
        {
            //var finalMail = new HashSet();
            HashSet<string> finalMail = new HashSet<string>();

            try
            {
                // write your code here.
                // HashSet<string> finalMail;
                string localName, domainName;
                int par;
                foreach (string a in emails)
                {
                    par = a.IndexOf("@"); //finding the index at @
                    localName = a.Substring(0, par); //finding name before @
                    domainName = a.Substring(par, a.Length - par); //finding name after @

                    localName = localName.Substring(0, localName.IndexOf("+") + 1); //removing all the characters after +
                    localName = localName.Replace(@"+", ""); // replace '+' with ""
                    localName = localName.Replace(@".", ""); // replace '.' with ""
                    localName = localName.Trim(); //remove all the spaces in localName
                    finalMail.Add(localName + domainName); //concat localName and domainName

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return finalMail.Count;
        }
        private static string DestCity(string[,] paths)
        {
            try
            {
                for (int a = 0; a < paths.GetLength(0); a++) 
                {
                    int x = 0;
                    for (int b = 0; b < paths.GetLength(0); b++)
                    {
                        if (paths[b, 0] == paths[a, 1]) // Checking if the start and destination city are same
                        {
                            x = 1;
                            break;

                        }
                    }
                    if (x == 0)
                    {
                        return paths[a, 1]; // returning the destination city - The destination city exists in row[1] ---- also eliminating the destination city in row 0

                    }
                }
                return "";

            
            }

            catch (Exception e)
            {

                Console.WriteLine("Please enter a valid input " + e.Message);
                throw;
            }

        }
    }
}





