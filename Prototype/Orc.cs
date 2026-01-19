using Newtonsoft.Json;
using System;

namespace Prototype
{
    public class Ork : OrkPrototype
    {
        private static readonly Random randomGenerator = new Random();

        public string Nazwa { get; set; }
        public int Lata { get; set; }
        public int Moc { get; set; }

        public Ork(string nazwa, int lata, int moc)
        {
            Nazwa = nazwa;
            Lata = lata;
            Moc = moc;
        }

        public override Ork CreateCopy()
        {
            string jsonData = JsonConvert.SerializeObject(this);

            Ork nowyOrk = JsonConvert.DeserializeObject<Ork>(jsonData)!;

            nowyOrk.Moc = randomGenerator.Next(40, 120);
            nowyOrk.Lata = randomGenerator.Next(18, 55);

            return nowyOrk;
        }

        public void WyswietlStatus()
        {
            Console.WriteLine(
                $"[ORK] Nazwa: {Nazwa}, Wiek: {Lata} lat, Poziom mocy: {Moc}"
            );
        }
    }
}
