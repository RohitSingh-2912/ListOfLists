using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace ListofLists
{
   public class Course
    {
        public ObjectId Id { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int CourseDuration { get; set; }

        public List<Subject> Subjects { get; set; }
        

        public Course(int courseId, String courseName, int courseDuration, List<Subject> subjects)
        {
            CourseId = courseId;
            CourseName = courseName;
            CourseDuration = courseDuration;
            Subjects = subjects;
        }

        //Creating List of Course
        public static List<Course> CreateCourseList()
        {
            string userInput;

            List<Course> course = new List<Course>();

            do
            {
                Console.WriteLine("Enter the CourseId:");
                int courseId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the CourseName:");
                String courseName = Console.ReadLine();

                Console.WriteLine("Enter the CourseDuration:");
                int courseDuration = int.Parse(Console.ReadLine());

                List<Subject> subjects = Subject.CreateSubjectList();


                course.Add(new Course(courseId, courseName, courseDuration, subjects));

                Console.WriteLine("Do you want to Continue with Course: press 'y' or 'Y' ");
                userInput = Console.ReadLine();

            } while (userInput == "y" || userInput == "Y");
            return course;
        }


    }
}
