using System;

namespace Builder
{
    public class Konny : Wojownik
    {
        public Konny(string imie) : base(imie) { }

        public override void Opis()
        {
            Console.WriteLine($"Nazywam sie {Imie}. Jestem konnym!");
        }
    }
}