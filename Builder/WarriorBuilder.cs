using System;

namespace Builder
{
    public abstract class WarriorBuilder
    {
      protected IWarrior? _warrior;

      public void ZapisywnieDoArmii(string imie)
      {
          _warrior = CreateWarrior(imie);
          Console.WriteLine($"{imie} zostaje zapisany do armii.");
      }

      public void PobieranieBroni()
      {
          EnsureWarriorExists();
          Console.WriteLine($"{_warrior!.imie} otrzymuje swoje uzbrojenie.");
      }

      public void TreningWalki()
      {
          EnsureWarriorExists();
          Console.WriteLine($"{_warrior!.imie} rozpoczyna szkolenie bojowe.");
      }

      public IWarrior GetWarrior()
      {
          EnsureWarriorExists();
          return _warrior!;
      }

      protected abstract IWarrior CreateWarrior(string imie);

      private void EnsureWarriorExists()
      {
          if (_warrior == null)
              throw new InvalidOperationException("Proces tworzenia wojownika nie został jeszcze zakończony.");
      }
    }
}
