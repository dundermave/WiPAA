using System;

namespace Builder
{
    public class Strzelec : Wojownik
    {
        public Strzelec(string imie) : base(imie) { }

        public override void Opis()
        {
            Console.WriteLine($"Nazywam sie {Imie}. Jestem strzelecem!");
        }
    }
}