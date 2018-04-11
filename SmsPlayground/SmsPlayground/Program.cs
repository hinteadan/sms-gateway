using System;

namespace SmsPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sms = new SmsGateway())
            {
                string message = "Testicles with URL: https://ebriza.com";

                Console.WriteLine($"{sms.SendMessage("0722913919", message).Result.IsSuccessfull.ToString()}");
                Console.WriteLine($"{sms.SendMessage("0721273700", message).Result.IsSuccessfull.ToString()}");
                Console.WriteLine($"{sms.SendMessage("0746200307", message).Result.IsSuccessfull.ToString()}");
                Console.WriteLine($"{sms.SendMessage("0724016416", message).Result.IsSuccessfull.ToString()}");
            }

            Console.WriteLine($"Done @ {DateTime.Now}");
            Console.ReadLine();
        }
    }
}
