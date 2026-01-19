using System;

namespace Factory
{
    public class Strzelec : Wojownik
    {
        public Strzelec(string imie) : base(imie) { }

        public override void Opisz()
        {
            Console.WriteLine($"Nazywam sie {Imie}. Jestem strzelcem!");
        }
    }
}