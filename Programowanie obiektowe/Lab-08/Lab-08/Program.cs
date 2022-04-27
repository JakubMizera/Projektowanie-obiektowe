using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_08
{
    internal class Program
    {
        record Student(string Name, int Ects);

        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "adam", "ewa", "ola", "karol", "robert" };

            Predicate<string> NamesA = s => {
                Console.WriteLine("Predicate " + s);
                return s.StartsWith("a");
                };

            IEnumerable<string> result =
                from name in names
                where NamesA.Invoke(name) && name.Length == 4
                select name;

            Console.WriteLine("Ewaluacja");
            Console.WriteLine(string.Join("\n", result));

            int[] ints = { 4, 2, 6, 3, 6, 8, 2, 8 };

            IEnumerable<int> evens =
                from i in ints
                where i % 2 == 0
                select i;
            Console.WriteLine(string.Join(", ", evens));


            Student[] students =
            {
                new Student("ewa", 23),
                new Student("adam", 23),
                new Student("olaf", 67),
                new Student("ola", 34),
                new Student("tomek", 15)
            };
            IEnumerable<string> std =
                from student in students
                where student.Ects > 20
                select student.Name.ToUpper();
            Console.WriteLine(string.Join(", ", std));

            //w () zwracamy wiecej niz jeden argument
            IEnumerable<(string Name, string)> egzamin =
                from student in students
                // gdy wybieramy wiecej niz 1 agrument uzywamy nawiasów
                select (student.Name, student.Ects > 20 ? "zdał" : "nie zdał");
            Console.WriteLine(string.Join(", ", egzamin));

            IEnumerable<IGrouping<int, object>> etcs =
                from s in students
                group s by s.Ects;
            

            foreach(var item in etcs)
            {
                Console.WriteLine(item.Key + " " + String.Join(",", item));
            }

            //grupowanie ints po wartosciach

            // fluent api
            students
                .Where(student => student.Ects > 20)
                .Select(student => student.Name);
            //stworz zapytanie  liste parzystych liczb
            ints.Where(i => i % 2 == 0).Select(i => i);
            Console.WriteLine(ints.Last());
            //dla int zwroci 0 jesli nie znajdzie elementu
            Console.WriteLine(ints.ElementAtOrDefault(10));
            //zwroci null jesli nie znajdzie
            Console.WriteLine(students.ElementAtOrDefault(10));

            //oblicz sume i srednia z tablicy int

            Console.WriteLine(ints.Sum());
            Console.WriteLine(ints.Average());
            //funkcja agregujaca
            string intsString = ints.Aggregate("", (accu, item) => accu + item);
            Console.WriteLine(intsString);


            IEnumerable<int> from0to10 = Enumerable.Range(0, 10);
            Console.WriteLine(string.Join(", ", from0to10));

            int x = Enumerable.Range(0, 100).Where(n => n % 2 == 0).Sum();

            Random random = new Random();
            random.Next(10);
            Console.WriteLine(String.Join(", ", random));
            //wygeneruj tablice 100 liczb losowych od 0 do 9

            int[] y = Enumerable
                .Range(0, 100)
                .Select(n => random.Next(10))
                .ToArray();


        }
    }
}
