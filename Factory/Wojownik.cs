
using System;

namespace Factory
{
    public abstract class Wojownik
    {
        public string Imie { get; set; }

        protected Wojownik(string imie)
        {
            Imie = imie;
        }

        public abstract void Opis();
    }
}