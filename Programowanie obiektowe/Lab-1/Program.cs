using System;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //PersonProperties person = person.FirstName("asd");
            //Console.WriteLine(person.FirstName);
            DateTime day = DateTime.Parse("31-02-2022");
        }
    }

    public class PersonProperties
    {
        private string firstName;

        private PersonProperties(string firstName)
        {
            firstName = firstName;
        }

        public static PersonProperties Of(string firstName)
        {
            if (firstName.Length <= 2)
            {
                return new PersonProperties(firstName);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Imię jest za krótkie");
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value.Length >= 2)
                {
                    firstName = value;
                }
            }
        }
    }

    public class PersonField
    {
        private string FirstName;
        public string getFirstName()
        {
            return FirstName;
        }
        public void setFirstName(string value)
        {
            FirstName = value;
        }
    }

    public enum Currency
    {
        PLN = 1,
        USD = 2,
        EUR = 3
    }


    public class Money
    {
        private readonly decimal _value;
        
        private readonly Currency _currency;
        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }

    }
    public decimal Value
    {
        get;
    }


    public static Money? Of(decimal value, Currency currency)
    {
        return value < 0 ? null : new Money(value, currency);
    }

    public static Money? OfWithException(decimal value, Currency currency)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException("Argument mniejszy niż 0");
        }
        else
        {
            return new Money(value, currency);
        }
    }

    public static Money operator*(Money money, decimal value)
    {
        return Money.Of(money.Value * value, money.Currency);
    }
   
}