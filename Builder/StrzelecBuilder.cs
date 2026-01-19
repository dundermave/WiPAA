using System;

namespace Builder
{
    public class StrzelecBuilder : WarriorBuilder
    {
        protected override IWarrior CreateWarrior(string imie)
        {
            return new Strzelec(imie);
        }
    }
}