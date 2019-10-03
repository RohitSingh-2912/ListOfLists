using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ListofLists
{
    public class ListofLists
    {
        public static IMongoClient _client;
        public static IMongoDatabase _database;

        public static IMongoCollection<Course> GetCollectionCourse()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("ListOfList");
            var _collection = _database.GetCollection<Course>("Course");
            return _collection;
        }
        public static Course GetCourse()
        {
            Console.WriteLine("Enter CourseId");
            int courseId =int.Parse(Console.ReadLine());

            Console.WriteLine("Enter CourseName");
            string courseName = Console.ReadLine();

            Console.WriteLine("Enter CourseDuration");
            int courseDuration = int.Parse(Console.ReadLine());

            List<Subject> subjects = Subject.CreateSubjectList();

            Course course = new Course(courseId, courseName, courseDuration,subjects);
          

            return course;

        }

        public static void InsertCourse()
        {
            var collection = GetCollectionCourse();
            collection.InsertOne(GetCourse());
        }

        public static void UpdateCourseByID()
        { 
            var collection = GetCollectionCourse();

            var updateCourse = GetCourse();
    
            collection.FindOneAndUpdate<Course>
                (Builders<Course>.Filter.Eq("CourseId", updateCourse.CourseId),
                 Builders<Course>.Update.Set("CourseName", updateCourse.CourseName)
                 .Set("CourseDuration", updateCourse.CourseDuration)
                 .Set("Subjects", updateCourse.Subjects));
        }

       

        public static void DeleteCourse()
        {
           var collection= GetCollectionCourse();

            Console.WriteLine("Please Enter the Course Id to delete the record : ");
            var deleteCourseId = int.Parse(Console.ReadLine());
            collection.DeleteOne(s => s.CourseId == deleteCourseId);

        }

       

            public static void GetAllCourses()
        {
            var collection = GetCollectionCourse();

            var all = collection.Find(new BsonDocument());
            Console.WriteLine();

            foreach (var i in all.ToEnumerable())
            {
                Console.WriteLine( $"CourseId : {i.CourseId} "
                                 + $"CourseName : {i.CourseName} " 
                                 + $"CourseDuration :{i.CourseDuration}\n" );

                foreach (var subject in i.Subjects)
                {
                    Console.WriteLine($"SubjectId : {subject.SubjectId}"+ "\t"+
                        $"SubjectName : {subject.SubjectName}\n"
                        );

                    foreach (var mark in subject.MarksRequired)
                    {
                        Console.WriteLine($"TotalMarks : {mark.TotalMarks}"+ "\t"+
                                           $"RequiredMarks : {mark.RequiredMarks}\n");
                    }
                }
                

            }
        }


        public static void GetCoursesById(int id)
        {
            var collection = GetCollectionCourse();

           
           

            var all = collection.Find<Course>
                (Builders<Course>.Filter.Eq("CourseId", id));
            Console.WriteLine();

            foreach (var i in all.ToEnumerable())
            {
                Console.WriteLine($"CourseId : {i.CourseId} "
                                 + $"CourseName : {i.CourseName} "
                                 + $"CourseDuration :{i.CourseDuration}\n");

                foreach (var subject in i.Subjects)
                {
                    Console.WriteLine($"SubjectId : {subject.SubjectId}" + "\t" +
                        $"SubjectName : {subject.SubjectName}\n"
                        );

                    foreach (var mark in subject.MarksRequired)
                    {
                        Console.WriteLine($"TotalMarks : {mark.TotalMarks}" + "\t" +
                                           $"RequiredMarks : {mark.RequiredMarks}\n");
                    }
                }


            }
        }

        public static void GetCoursesByName(String name)
        {
            var collection = GetCollectionCourse();




            var all = collection.Find<Course>
                (Builders<Course>.Filter.Eq("CourseName",name ));
            Console.WriteLine();

            foreach (var i in all.ToEnumerable())
            {
                Console.WriteLine($"CourseId : {i.CourseId} "
                                 + $"CourseName : {i.CourseName} "
                                 + $"CourseDuration :{i.CourseDuration}\n");

                foreach (var subject in i.Subjects)
                {
                    Console.WriteLine($"SubjectId : {subject.SubjectId}" + "\t" +
                        $"SubjectName : {subject.SubjectName}\n"
                        );

                    foreach (var mark in subject.MarksRequired)
                    {
                        Console.WriteLine($"TotalMarks : {mark.TotalMarks}" + "\t" +
                                           $"RequiredMarks : {mark.RequiredMarks}\n");
                    }
                }


            }
        }

        public static void GetCoursesByDuration(int duration)
        {
            var collection = GetCollectionCourse();




            var all = collection.Find<Course>
                (Builders<Course>.Filter.Eq("CourseDuration", duration));
            Console.WriteLine();

            foreach (var i in all.ToEnumerable())
            {
                Console.WriteLine($"CourseId : {i.CourseId} "
                                 + $"CourseName : {i.CourseName} "
                                 + $"CourseDuration :{i.CourseDuration}\n");

                foreach (var subject in i.Subjects)
                {
                    Console.WriteLine($"SubjectId : {subject.SubjectId}" + "\t" +
                        $"SubjectName : {subject.SubjectName}\n"
                        );

                    foreach (var mark in subject.MarksRequired)
                    {
                        Console.WriteLine($"TotalMarks : {mark.TotalMarks}" + "\t" +
                                           $"RequiredMarks : {mark.RequiredMarks}\n");
                    }
                }


            }
        }


        //Method for CRUD Operation
        public void CRUDOperation()
        {

            var collection = GetCollectionCourse();

            Console.WriteLine
                ("Press select your option from the following\n1 - InsertCourse\n" +
                "2 - UpdateCourseById  \n3 - DeleteCourse " +
                "\n4 - Read AllCourse" + "\n5 - Read CourseById" + "\n6 - Read CourseByName" + "\n7 - Read CourseByDuration\n");


            string userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":
                    //Insert
                    InsertCourse();
                    break;

                case "2":
                    //UpdateById 
                    UpdateCourseByID();
                    break;

                case "3":
                    //Find and Delete  
                    DeleteCourse();
                    break;

                case "4":
                    //Read all existing document  
                    GetAllCourses();
                    break;

                case "5":
                    //Read all existing document  
                    Console.WriteLine("Enter the id for Course");
                    int id = int.Parse(Console.ReadLine());
                    GetCoursesById(id);
                    break;

                case "6":
                    //Read all existing document  
                    Console.WriteLine("Enter the Name for Course");
                    String name= Console.ReadLine();
                    GetCoursesByName(name);
                    break;
                case "7":
                    //Read all existing document  
                    Console.WriteLine("Enter the Duration for Course");
                    int duration = int.Parse(Console.ReadLine());
                    GetCoursesByDuration(duration);
                    break;


                default:
                    Console.WriteLine("Please choose a correct option");
                    break;
            }

            //To continue with Program  
            Console.WriteLine("\n----------------------------------\nPress Y for continue...\n");
            string userChoice = Console.ReadLine();

            if (userChoice == "Y" || userChoice == "y")
            {
                this.CRUDOperation();
            }
        }

        public static void Main(string[] args)
        {
            ListofLists crud = new ListofLists();
            crud.CRUDOperation();


            //Hold the screen by logic  
            Console.WriteLine("Press any key to trminated the program");
            Console.ReadKey();
        }

    }

}



