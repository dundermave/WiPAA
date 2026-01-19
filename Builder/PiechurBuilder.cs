using System;

namespace Builder
{
    public class PiechurBuilder : WarriorBuilder
    {
        protected override IWarrior CreateWarrior(string imie)
        {
            return new Piechur(imie);
        }
    }
}