using System;
using System.Collections.Generic;

namespace Builder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var garnizon = new Garnizon();

            foreach (var spec in GetWarriorSpecs())
            {
                AddWarriors(garnizon, spec.builderFactory, spec.namePrefix, spec.count);
            }

            foreach (var wojownik in garnizon.Wojownicy)
            {
                wojownik.Opis();
            }
        }

        private static IEnumerable<(Func<WarriorBuilder> builderFactory, string namePrefix, int count)> GetWarriorSpecs()
        {
            return new (Func<WarriorBuilder>, string, int)[]
            {
                (() => new PiechurBuilder(),  "Piechur",   2),
                (() => new KonnyBuilder(),    "Konny",     2),
                (() => new StrzelecBuilder(), "Strzelec",  2),
            };
        }

        private static void AddWarriors(
            Garnizon garnizon,
            Func<WarriorBuilder> builderFactory,
            string namePrefix,
            int count)
        {
            for (int i = 1; i <= count; i++)
            {
                var builder = builderFactory();
                garnizon.Szkolenie(builder, $"{namePrefix}{i}");
            }
        }
    }
}
