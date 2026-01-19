using System;
using System.Collections.Generic;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ork> listaOrkow = new List<Ork>();

            Ork prototyp = new Ork("Orc Warrior", 30, 70);

            Console.WriteLine("Klonowanie orków na podstawie prototypu:\n");

            for (int i = 0; i < 5; i++)
            {
                Ork klon = prototyp.CreateCopy();
                klon.WyswietlStatus();
                listaOrkow.Add(klon);
            }
        }
    }
}
