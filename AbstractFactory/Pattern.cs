// Я РОЗУМІЮ ПАТЕРН ЛИШЕ ПОВЕРХНЬО, ТОЖ ЧАСТИНУ КОДА БУЛО ЗГЕНЕРОВАНО ДЛЯ РОБОТИ З МЕТОДОМ, I/O РОБИВ САМ.

using System;
using System.IO;

namespace AbstractFactory
{
    public interface IMail
    {
        string SendMail();
    }

    public class RegularMail : IMail
    {
        public string SendMail()
        {
            return "Sending Regular Mail.";
        }
    }

    public class ExpressMail : IMail
    {
        public string SendMail()
        {
            return "Sending Express Mail.";
        }
    }

    public class OvernightMail : IMail
    {
        public string SendMail()
        {
            return "Sending Overnight Mail.";
        }
    }

    public interface IMailFactory
    {
        IMail CreateMail();
    }

    public class RegularMailFactory : IMailFactory
    {
        public IMail CreateMail()
        {
            return new RegularMail();
        }
    }

    public class ExpressMailFactory : IMailFactory
    {
        public IMail CreateMail()
        {
            return new ExpressMail();
        }
    }

    public class OvernightMailFactory : IMailFactory
    {
        public IMail CreateMail()
        {
            return new OvernightMail();
        }
    }

    public class MailClient
    {
        public void SendMail(IMailFactory mailFactory)
        {
            IMail mail = mailFactory.CreateMail();
            Console.WriteLine(mail.SendMail());
        }
    }

    public class Pattern
    {
        public static void Main()
        {
            MailClient client = new();

            while (true)
            {
                Console.WriteLine("Select mail type to send:");
                Console.WriteLine("1. Regular Mail");
                Console.WriteLine("2. Express Mail");
                Console.WriteLine("3. Overnight Mail");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    break;
                }

                IMailFactory? mailFactory = choice switch
                {
                    "1" => new RegularMailFactory(),
                    "2" => new ExpressMailFactory(),
                    "3" => new OvernightMailFactory(),
                    _ => null // explicity allowing null
                };

                if (mailFactory != null)
                {
                    client.SendMail(mailFactory!); // warning on line 90 likely occurs when passing this
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }

                Console.WriteLine(); // blank line for space
            }
        }
    }
}