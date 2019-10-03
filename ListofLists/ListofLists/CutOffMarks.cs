using System;
using System.Collections.Generic;

namespace ListofLists
{
    public class CutOffMarks
    {
        public int TotalMarks { get; set; }

        public int RequiredMarks { get; set; }

        public CutOffMarks(int totalMarks, int requiredMarks)
        {
            TotalMarks = totalMarks;
            RequiredMarks = requiredMarks;
        }

        //Creating List of CutOffMarks
        public static List<CutOffMarks> CreateCutOffList()
        {
            string userInput;

            var mark = new List<CutOffMarks>();

            do
            {
                Console.WriteLine("Enter the totalMarks:");
                int totalMarks = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the requiredMarks:");
                int requiredMarks = int.Parse(Console.ReadLine());

                mark.Add(new CutOffMarks(totalMarks, requiredMarks));

                Console.WriteLine("Do you want to Continue with Marks: press 'y' or 'Y' ");
                userInput = Console.ReadLine();

            } while (userInput == "y" || userInput == "Y");

            return mark;
        }



    }
  
}
