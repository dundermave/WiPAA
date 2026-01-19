using System;

namespace Builder
{
    public class Piechur : Wojownik
    {
        public Piechur(string imie) : base(imie) { }

        public override void Opis()
        {
            Console.WriteLine($"Nazywam sie {Imie}. Jestem piechurem!");
        }
    }
}