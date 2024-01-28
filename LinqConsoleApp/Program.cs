using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //BasicLinq();
            FilterWithWhere();
        }

        private static void BasicLinq()
        {
            string[] names = { "Peter", "Günther", "Manfred", "Uwe" };

            // LINQ-Abfrage

            var query = from name in names
                        where name.Contains('t')
                        select name;

            // Linq-Abfrage einfach
            foreach (string name in query)
            {
                Console.WriteLine(name);
            }
            Console.ReadKey(true);

            // Änderung des Arrays an der 0. Stelle
            names[0] = "Gustav";
            Console.Clear();

            // LINQ-Abfrage mit kompakter Methodensyntax
            foreach (string name in names.Where(n => n.Contains('t')))
            {
                Console.WriteLine(name);
            }
            Console.ReadKey();
        }
        private static void FilterWithWhere()
        {
            List<Student> studentsList = new List<Student>();
            studentsList.Add(new Student(
                                         "Peter",
                                         "Müller",
                                         Studiengang.Informatik,
                                         2
                                         ));
            studentsList.Add(new Student(
                                         "Günther",
                                         "Schmidt",
                                         Studiengang.Wirtschaftsinformatik,
                                         3
                                         ));
            studentsList.Add(new Student(
                                         "Manfred",
                                         "Schulze",
                                         Studiengang.Wirtschaftsingenieurwesen,
                                         4
                                         ));
            studentsList.Add(new Student(
                                         "Uwe", 
                                         "Meier", 
                                         Studiengang.Maschinenbau, 
                                         5
                                         ));

            var informatikStudenten = from student in studentsList
                                      where student.Studiengang == Studiengang.Informatik
                                      select student;

            foreach (Student student in informatikStudenten)
            {
                Console.WriteLine(student.ToString());
            }
            Console.ReadKey(true);
        }
        enum Studiengang
        {
            Informatik,
            Wirtschaftsinformatik,
            Wirtschaftsingenieurwesen,
            Maschinenbau,
            Elektrotechnik
        }

        class Student
        {
            public Studiengang Studiengang { get; set; }

            public int Semester { get; set; }

            public string Vorname { get; set; }
            public string Nachname { get; set; }
            public Student(string vorname, string nachname, Studiengang studiengang, int semester)
            {
                Vorname = vorname;
                Nachname = nachname;
                Studiengang = studiengang;
                Semester = semester;
            }
            public override string ToString()
            {
                return $"{Vorname}, {Nachname} ({Studiengang}, {Semester}. Semester)";
            }
        }
    }
}
