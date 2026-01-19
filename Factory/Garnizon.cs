using System;

namespace Factory
{
    public class Garnizon
    {
        public Wojownik SzkolenieWojownika(string profesja, string imie)
        {
            if (string.IsNullOrWhiteSpace(profesja))
                throw new ArgumentException("Profesja jest wymagana.");

            string typ = profesja.Trim().ToLowerInvariant();

            return typ switch
            {
                "piechur"  => new Piechur(imie),
                "strzelec" => new Strzelec(imie),
                "konny"    => new Konny(imie),
                _ => throw new ArgumentException(
                        $"Brak możliwości wyszkolenia: {profesja}"
                    )
            };
        }
    }
}
