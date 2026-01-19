using System;

namespace Factory
{
    public class Konny : Wojownik
    {
        public Konny(string imie) : base(imie) { }

        public override void Opisz()
        {
            Console.WriteLine($"Nazywam sie {Imie}. Jestem konnym!");
        }
    }
}