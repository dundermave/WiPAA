using System;

namespace Builder
{
    public abstract class Wojownik : IWarrior
    {
        public string Imie { get; set; }

        protected Wojownik(string imie)
        {
            Imie = imie;
        }

        public abstract void Opis();
    }
}