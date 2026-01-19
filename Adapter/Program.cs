using Adapter;

namespace Adapter
{
    internal class Program
    {
        static void Main()
        {
            Teenager krzys = new Teenager(17);

            Bouncer bouncer = new Bouncer();

            Console.WriteLine("== Próba wejścia bez adaptera ==");
            Adult realAttempt = new Adult(17);
            bouncer.CheckEntry(realAttempt);

            Console.WriteLine();
            Console.WriteLine("== Próba wejścia z adapterem FakeAdult ==");
            Adult fakeAdult = new FakeAdult(krzys);
            bouncer.CheckEntry(fakeAdult);
        }
    }
}
