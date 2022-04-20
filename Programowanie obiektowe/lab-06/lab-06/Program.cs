using System;
using System.Collections.Generic;

namespace lab_06
{
    internal class Program
    {

        class Student
        {
            public string Name { get; set; }
            public int Ects { get; set; }


            // metoda Equals aby działała funkcja Contains() dla kolekcji 
            public override bool Equals(object obj)
            {
                Console.WriteLine("Student Equals");
                return obj is Student student &&
                       Name == student.Name &&
                       Ects == student.Ects;
            }

            public override int GetHashCode()
            {
                Console.WriteLine("Student Hash");
                return HashCode.Combine(Name, Ects);
            }

            public override string ToString()
            {
                return $"Name = {Name}, ETCS = {Ects}";
            }
        }
        static void Main(string[] args)
        {

            ICollection<string> names = new List<string>();
            names.Add("Ewa");
            names.Add("Tomek");
            names.Add("Iga");
            names.Add("Rafał");


            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine(names.Contains("Ewa"));
            
            ICollection<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Ewa", Ects = 12});
            students.Add(new Student() { Name = "Tomek", Ects = 23});
         
            Console.WriteLine(students.Contains(new Student() { Name = "Ewa", Ects = 12 }));



            IList<Student> list = (IList<Student>)students;
            Console.WriteLine(list[0]);
            list.Insert(0, new Student() { Name = "Max", Ects = 16});  
            
            int i = list.IndexOf(new Student() { Name = "Tomek", Ects = 23 });
            Console.WriteLine(i);

            // klasa do tworzenia zbiorów
            ISet<string> namesSet = new HashSet<string>();
            namesSet.Add("Ewa");
            namesSet.Add("Ewa");
            namesSet.Add("Ewa");
            //zbiór nie dopuszcza do dodania takiego samego 
            Console.WriteLine(string.Join(",", namesSet));
            // wypisze tylko raz "Ewa"



            ISet<Student> studentGroup = new HashSet<Student>();
            studentGroup.Add(new Student() { Name = "Ewa", Ects = 14 });
            studentGroup.Add(new Student() { Name = "Ewa", Ects = 14 });
            studentGroup.Add(new Student() { Name = "Ewa", Ects = 14 });
            Console.WriteLine(string.Join(",", studentGroup));

            Console.WriteLine(studentGroup.Contains(new Student() { Name = "Ewa", Ects = 14 }));

            ISet<Student> team = new HashSet<Student>();
            team.Add(new Student() { Name = "Ewa", Ects = 14 });
            //czesc wspolna
            studentGroup.IntersectWith(team);
            Console.WriteLine(string.Join(",", studentGroup));



            Dictionary<string, Person> addressBook = new Dictionary<string, Person>();
            Person person = new Person() { Name = "karol", Email = "karol@gmail.com", Phone = "12341234" };
            addressBook.Add(person.Phone, person);
            person = new Person() { Name = "ewa", Email="ewa@gmail.com", Phone="43214321"};
            addressBook.Add(person.Phone, person);
            Console.WriteLine(addressBook["43214321"]);
            Console.WriteLine(addressBook.Keys);
            foreach(var item in addressBook)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }


            string[] arr = { "dd", "aa", "cc", "ss", "aa", "dd", "r", "aa" };
            //oblicz liczbe wystapien kazdego z lancuchow w arr; uzyc slownika
            int[] set1 = { 19, 19, 63, 44, 15, 26, };
            int[] set2 = { 25, 19, 63, 25, 15, 52, };
            //wyznacz czesc wspolna tablic set1 set2
            ISet<int[]> setOne = new HashSet<int[]>();
            setOne.Add(set1);
            ISet<int[]> setTwo = new HashSet<int[]>();
            setTwo.Add(set2);
            setOne.IntersectWith(setTwo);

        }
        class Person
        {
            // czym sie rozni String z wielkiej i string z małej litery?
            public String Phone { get; set; }
            public String Email { get; set; }
            public String Name { get; set; }
        }
    }
}
