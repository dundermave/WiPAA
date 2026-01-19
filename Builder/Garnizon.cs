using System;
using System.Collections.Generic;

namespace Builder
{
    public class Garnizon
    {
        public List<IWarrior> Wojownicy { get; private set; } = new List<IWarrior>();

        public void Szkolenie(WarriorBuilder builder, string imie)
        {
            builder.ZapisywnieDoArmii(imie);
            builder.PobieranieBroni();
            builder.TreningWalki();
            IWarrior warrior = builder.GetWarrior();
            Wojownicy.Add(warrior);
        }
    }
}