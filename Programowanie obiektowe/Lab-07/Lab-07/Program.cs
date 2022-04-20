using System;

namespace Lab_07
{
    //przykład delegatu
    delegate double op(double x, double y);
    internal class Program
    {
        

        static double AddFunction(double a, double b)
        {
            return a + b;
        }

        static double MulFunction(double a, double b)
        {
            return (a * b);
        }

        static double DivFunction(double a, double b)
        {
            return a / b;
        }
        static void Main(string[] args)
        {
            //funkcje jako delegaty
            Func<double, double, double> Sub = delegate (double x, double y)
            {
                return x - y;
            };

            Func<int, string> Format = delegate (int i)
            {
                return string.Format("{0:X}", i);
            };

            //predykat zwraca bool wiec te funkcje sa takie same
            //predykat przyjmuje jeden argument, aby przyjac wiecej nalezy uzyc funckji 
            Func<string, bool> filter1 = delegate (string s)
            {
                return s.Length == 6;
            };
            Predicate<string> filter2 = delegate (string s)
            {
                return s.Length == 6;
            };
            //Action nic nie zwraca, przyjmuje dowolna liczbe argumentów
            Action<string> print = delegate (string s)
            {
                Console.WriteLine(s.ToUpper());
            };



            // zmienne które są funkcjami
            op Add = AddFunction;
            op Mul = MulFunction;
            op Div = DivFunction;

            // .Invoke() = wywołanie funkcji
            Console.WriteLine(Add.Invoke(2, 4.2));
            Console.WriteLine(Mul.Invoke(2, 4.2));
            Console.WriteLine(Div.Invoke(2, 4.2));
            Console.WriteLine(Format.Invoke(10));

            //przyklad lambda
            Action<string> printLambda = (s) => Console.WriteLine(s);
            printLambda("text");

            Predicate<string> FilterLambda = s => s.Length == 6;
            Func<double, double, double> DivLambda = (a, b) =>
            {
                if( b != 0)
                {
                    return a / b;
                } else
                {
                    throw new Exception("nie można dzielić przez 0");
                }
            };
            var Lambda = DivLambda;
            Func<Func<double>, int, double[]> FillArray = (supplier, size) =>
            {
                double [] arr = new double[size];
                for(int i = 0; i < size; i++)
                {
                    arr[i] = supplier.Invoke();
                }
                return arr;
            };
            double[] arr = new double[10];
            Random rand = new Random();
            FillArray.Invoke(() => rand.NextDouble(), 10);
            foreach(double value in arr)
            {
                Console.WriteLine(value);
            }


        }
    }
}
