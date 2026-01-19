using System;
using Decorator;

namespace Decorator
{
    internal class Program
    {
        static void Main()
        {
            Shop shop = new Shop();
            decimal amount = 149.99m;

            Console.WriteLine("== Płatność BLIK (bez dekoratorów) ==");
            shop.Checkout(new BlikPayment(), amount);

            Console.WriteLine();

            Console.WriteLine("== Przelew (bez dekoratorów) ==");
            shop.Checkout(new BankTransferPayment(), amount);

            Console.WriteLine();

            Console.WriteLine("== Karta (z dekoratorami) ==");
            IPayment card = new CardPayment();

            card = new SmsNotificationDecorator(card);
            card = new LoyaltyPointsDecorator(card);
            card = new RedirectToHomeDecorator(card);

            shop.Checkout(card, amount);
        }
    }
}
