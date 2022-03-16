using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{ 
    abstract class AbstractMessage
    {
     public string Content { get; set; }

    public abstract bool Send();
    }

    public interface IFly
    {
        void Fly();
    }
    public interface ISwim
    {
        void Swim();
    }

    public class Duck : IFly, ISwim
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }

    public class Hydroplain : IFly, ISwim
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }


    class EmailMessage : AbstractMessage
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }

        public override bool Send()
        {
            Console.WriteLine($"Sending email from: {From} to {To} with content {Content}");
            return true;
        }
    }

    class smsMessage : AbstractMessage
    {
        public string ToPhone { get; set; }
        public string FromPhone { get; set; }

        public override bool Send()
        {
            Console.WriteLine($"Sending sms from: {FromPhone} to {ToPhone} with content {Content}");
        }
    }

    //zdefinuj klase MessangerMessage
    class MessangerMessage : AbstractMessage
    {
        public override bool Send()
        {
            Console.WriteLine($"Sending messanger message ");
        }
    }


    class User
    {
        public string Name { get; set; }
        public AbstractMessage LastMessage { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string messageType = "sms";
            switch (messageType)
            {
                case "sms":
                    Console.WriteLine("Sending sms");
                    break;
                case "email":
                    Console.WriteLine("Sending email");
                    break;
            }
            Console.WriteLine("");
            User[] users =
            {
                new User() {Name="Karol", LastMessage=new smsMessage(){Content="Hello", FromPhone="12341234", ToPhone="43214321" } },
                new User() {Name="Ewa", LastMessage=new EmailMessage(){Content="Hello", To="ewa@gmail.com", From="ewa@op.pl" } },
                new User() {Name="Adam", LastMessage=new MessangerMessage(){Content="Messanger message"}}
            };






            int EmailCounter = 0;
            foreach (var user in users)
            {
                user.LastMessage.Send();
                //czy wiadomosci w lastmessage jest typu 
                if (user.LastMessage is EmailMessage)
                {
                    EmailCounter++;
                }
                if (user.LastMessage is smsMessage)
                {
                    //rzutowanie lastmessage na typ konkretny
                    smsMessage sms = (smsMessage) user.LastMessage;
                    Console.WriteLine(sms.ToPhone);
                }
            }
            Console.WriteLine($"Wysłano wiadomości email: {EmailCounter}");

            IFly[] flyingObject =
            {
                new Duck(),
                new Hydroplain()
            };

            //przyklad iteratora
            IAggregate aggregate = new SimpleAggregate();
            IIterator iterator = aggregate.createIterator();
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.GetNext());
            }
        }

        public interface IAggregate
        {
            IIterator createIterator();
        }

        public interface IIterator
        {
            bool HasNext();
            int GetNext();
        }

        class SimpleAggregate : IAggregate
        {
            internal int a = 5;
            internal int b = 9;
            internal int c = 2;

            public IIterator createIterator()
            {
                // zmienic iterator na przegladanie od c do a
                return new SimpleAggregateIterator(this);
            }
        }

        class SimpleAggregateIterator : IIterator
        {
            private SimpleAggregate _aggreagate;
            private int count = 0;

            public SimpleAggregateIterator(SimpleAggregate aggregate)
            {
                _aggreagate = aggregate;
            }


            public int GetNext()
            {

                switch (++count)
                {
                    case 1:
                        return _aggreagate.a;
                    case 2:
                        return _aggreagate.b;
                    case 3:
                        return _aggreagate.c;
                    default:
                        throw new ArgumentException("Błąd");
                }
            }

            public bool HasNext()
            {
                return count < 3;
            }
        }
    }
}
