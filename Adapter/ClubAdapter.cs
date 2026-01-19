using System;

namespace Adapter
{
    public class Adult
    {
        protected int Age;

        public Adult(int age)
        {
            Age = age;
        }

        public virtual bool IsAdult()
        {
            return Age >= 18;
        }
    }

    public class Teenager
    {
        public int RealAge { get; }

        public Teenager(int age)
        {
            RealAge = age;
        }
    }

    public class FakeAdult : Adult
    {
        private readonly Teenager _teenager;

        public FakeAdult(Teenager teenager) : base(18)
        {
            _teenager = teenager;
        }

        public override bool IsAdult()
        {
            Console.WriteLine($"[Adapter] Fałszowanie wieku. Prawdziwy wiek: {_teenager.RealAge}");
            return true;
        }
    }

    public class Bouncer
    {
        public void CheckEntry(Adult person)
        {
            if (person.IsAdult())
            {
                Console.WriteLine("Bramkarz: Wchodzisz do klubu. Miłej zabawy!");
            }
            else
            {
                Console.WriteLine("Bramkarz: Wstęp wzbroniony – jesteś niepełnoletni.");
            }
        }
    }
}
