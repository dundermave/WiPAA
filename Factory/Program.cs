using System;
using System.Collections.Generic;

namespace Factory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var garnizon = new Garnizon();

            var plan = new (string profesja, int liczba, string prefix)[]
            {
                ("piechur",  3, "Piechur"),
                ("konny",    3, "Konny"),
                ("strzelec", 4, "Strzelec"),
            };

            var wojownicy = new List<Wojownik>(capacity: 10);

            foreach (var (profesja, liczba, prefix) in plan)
            {
                for (int i = 1; i <= liczba; i++)
                {
                    string imie = $"{prefix}{i}";
                    wojownicy.Add(garnizon.SzkolenieWojownika(profesja, imie));
                }
            }

            Console.WriteLine("Wojownicy w garnizonie:");
            foreach (var wojownik in wojownicy)
            {
                wojownik.Opis();
            }
        }
    }
}
