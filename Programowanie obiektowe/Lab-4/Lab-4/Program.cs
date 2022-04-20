using System;

namespace Lab_4
{
    internal class Program
    {
        // enum = stała wyliczeniowa
        public enum Degree
        {
            A = 50,
            B = 45,
            C = 40,
            D = 35,
            E = 30,
            F = 20,
            G = 10
        }

        public static double Convert(Degree degree)
        {
            return degree switch
            {
                Degree.A => 5.0,
                Degree.B => 4.5,
                Degree.C => 4.0,
                Degree.D => 3.5,
                Degree.E => 3.0,
                Degree.F => 2.0,
                Degree.G => 1.0
            };
        }

        static void Main(string[] args)
        {
            

            Degree degree = Degree.A;
            Console.WriteLine(degree);
            Console.WriteLine((int)degree);
            string [] names = Enum.GetNames<Degree>();
            Console.WriteLine(names);
            Degree[] degrees = Enum.GetValues<Degree>();
            Array.Sort(degrees, (a, b) => -a.CompareTo(b));
            
            // zmiana kolejnosci z  g f e... na a b c ...
            Console.WriteLine("Wpisz jedną z ocen");

            foreach (var d in degrees)
            {
                Console.WriteLine(d);
            }
            string degreeString = Console.ReadLine();
            try
            {
                Degree studentDegree = Enum.Parse<Degree>(degreeString);
                Console.WriteLine($"Wpisałeś ocenę {studentDegree}");

            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Wpisałeś nie poprawną ocenę");
            }
        }

        public static string MessageFromDegree(Degree degree)
        {
            return degree switch
            {
                Degree.A or Degree.B or Degree.C or Degree.D or Degree.E => "Pozytywna",
                Degree.F or Degree.G => "Negatywna",
                _ => throw new ArgumentException("Zła ocena") // _ to wartość domyślna
            };
        }

    }
}
