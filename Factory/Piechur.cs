using System;

namespace Factory
{
    public class Piechur : Wojownik
    {
        public Piechur(string imie) : base(imie) { }

        public override void Opisz()
        {
            Console.WriteLine($"Nazywam sie {Imie}. Jestem piechurem!");
        }
    }
}