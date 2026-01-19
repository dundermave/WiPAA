using System;

namespace Decorator
{
    public interface IPayment
    {
        void Pay(decimal amount);
    }

    public class CardPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"[Płatność] Zrealizowano płatność kartą na kwotę: {amount:0.00} PLN.");
        }
    }

    public class BlikPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"[Płatność] Zrealizowano płatność BLIK na kwotę: {amount:0.00} PLN.");
        }
    }

    public class BankTransferPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"[Płatność] Zlecono przelew bankowy na kwotę: {amount:0.00} PLN.");
        }
    }

    public abstract class PaymentDecorator : IPayment
    {
        private readonly IPayment _inner;

        protected PaymentDecorator(IPayment inner)
        {
            _inner = inner;
        }

        public virtual void Pay(decimal amount)
        {
            _inner.Pay(amount);
        }
    }

    public class SmsNotificationDecorator : PaymentDecorator
    {
        public SmsNotificationDecorator(IPayment inner) : base(inner) { }

        public override void Pay(decimal amount)
        {
            base.Pay(amount);
            Console.WriteLine("[Dekorator] Wysłano SMS: potwierdzenie płatności.");
        }
    }

    public class LoyaltyPointsDecorator : PaymentDecorator
    {
        public LoyaltyPointsDecorator(IPayment inner) : base(inner) { }

        public override void Pay(decimal amount)
        {
            base.Pay(amount);

            int points = (int)Math.Floor(amount); // 1 punkt za pełną złotówkę (przykład)
            Console.WriteLine($"[Dekorator] Dodano punkty lojalnościowe: +{points}.");
        }
    }

    public class RedirectToHomeDecorator : PaymentDecorator
    {
        public RedirectToHomeDecorator(IPayment inner) : base(inner) { }

        public override void Pay(decimal amount)
        {
            base.Pay(amount);
            Console.WriteLine("[Dekorator] Przekierowanie: strona główna sklepu.");
        }
    }

    public class Shop
    {
        public void Checkout(IPayment paymentMethod, decimal amount)
        {
            Console.WriteLine("Sklep: rozpoczęcie płatności...");
            paymentMethod.Pay(amount);
            Console.WriteLine("Sklep: płatność zakończona.");
        }
    }
}
