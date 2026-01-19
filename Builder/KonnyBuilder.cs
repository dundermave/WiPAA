using System;

namespace Builder
{
    public class KonnyBuilder : WarriorBuilder
    {
        protected override IWarrior CreateWarrior(string imie)
        {
            return new Konny(imie);
        }
    }
}