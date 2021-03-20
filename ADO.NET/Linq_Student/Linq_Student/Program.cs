using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Student
{
    class Program
    {
        static List<Student> students = new List<Student>
 {
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O’Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
 new Student {First="Sven", Last="Mortensen", ID=113, Scores=
new List<int> {88, 94, 65, 91}},
 new Student {First="Cesar", Last="Garcia", ID=114, Scores=
new List<int> {97, 89, 85, 82}},
 new Student {First="Debra", Last="Garcia", ID=115, Scores=
new List<int> {35, 72, 91, 70}},
 };

        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 1");
            int studentCountW = students.Where(st => st.Scores[0] > 90
&& st.Scores[3] < 80).Count();
            var studentList = (
 from student in students
 where student.Scores[0] > 90 && student.Scores[3] < 80
 orderby student.Last descending
 select student).ToList();

            foreach (Student student in studentList)
            {
                Console.WriteLine("{0}, {1} {2}", student.Last, student.First,
student.Scores[0]);

                Console.WriteLine("Упражнение 2");
                var studentQuery2 =
 from student1 in students
 group student1 by student1.Last[0];
                foreach (var studentGroup in studentQuery2)
                {
                    Console.WriteLine(studentGroup.Key);
                    foreach (Student student1 in studentGroup)
                    {
                        Console.WriteLine(" {0}, {1}",
                        student1.Last, student1.First);
                    }
                }
                Console.WriteLine("Упражнение 3");

                var studentQuery3 =
 from student2 in students
 group student2 by student2.Last[0];
                foreach (var groupOfStudents in studentQuery3)
                {
                    Console.WriteLine(groupOfStudents.Key);
                    foreach (var student2 in groupOfStudents)
                    {
                        Console.WriteLine(" {0}, {1}",
                        student2.Last, student2.First);
                    }
                }
                Console.WriteLine("Упражнение 4");
                var studentQuery4 =
 from student3 in students
 group student3 by student3.Last[0] into studentGroup
 orderby studentGroup.Key
 select studentGroup;
                foreach (var groupOfStudents in studentQuery4)
                {
                    Console.WriteLine(groupOfStudents.Key);
                    foreach (var student3 in groupOfStudents)
                    {
                        Console.WriteLine(" {0}, {1}",
                        student3.Last, student3.First);
                    }
                }
                Console.WriteLine("Упражнение 5");
                var studentQuery5 =
 from student4 in students
 let totalScore = student4.Scores[0] + student4.Scores[1] +
 student4.Scores[2] + student4.Scores[3]
 where totalScore / 4 < student4.Scores[0]
 select student4.Last + " " + student4.First;
                foreach (string s in studentQuery5)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("Упражнение 6");
                var studentQuery6 =
 from student5 in students
 let totalScore = student5.Scores[0] + student5.Scores[1] +
 student5.Scores[2] + student5.Scores[3]
 select totalScore;
                double averageScore = studentQuery6.Average();
                Console.WriteLine("Class average score = {0}", averageScore);
                Console.WriteLine("Упражнение 7");
                IEnumerable<string> studentQuery7 =
 from student6 in students
 where student6.Last == "Garcia"
 select student6.First;
                Console.WriteLine("The Garcias in the class are:");
                foreach (string s in studentQuery7)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("Упражнение 8");
                var studentQuery8 =
 from student7 in students
 let x = student7.Scores[0] + student7.Scores[1] +
 student7.Scores[2] + student7.Scores[3]
 where x > averageScore
 select new { id = student7.ID, score = x };
                foreach (var item in studentQuery8)
                {
                    Console.WriteLine("Student ID: {0}, Score: {1}", item.id,
                   item.score);
                }

            }
        }
    }
}
