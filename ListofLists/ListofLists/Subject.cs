using System;
using System.Collections.Generic;

namespace ListofLists
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public String SubjectName { get; set; }

        public List<CutOffMarks> MarksRequired { get; set; }

      
        public Subject(int subjectId, String subjectName, List<CutOffMarks> marksRequired)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            MarksRequired = marksRequired;
      
        }


        //Creating list of Subject
        public static List<Subject> CreateSubjectList()
        {
            string userInput;
            List<Subject> subject = new List<Subject>();
            do
            {
                Console.WriteLine("Enter the SubjectId:");
                int subjectId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the SubjectName:");
                String subjectName = Console.ReadLine();

                List<CutOffMarks> marksRequired= CutOffMarks.CreateCutOffList();


                subject.Add(new Subject(subjectId,subjectName,marksRequired));
               
                Console.WriteLine("Do you want to Continue with Subject: press 'y' or 'Y' ");
                userInput = Console.ReadLine();

            } while (userInput == "y" || userInput == "Y");
            return subject;
        }

       

    }
  
}
