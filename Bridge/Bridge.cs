using System;
using System.Collections.Generic;

namespace Bridge
{
    public interface IInterface
    {
        void PressMenuButton();
    }

    public abstract class SystemBase
    {
        protected IInterface Ui;

        protected SystemBase(IInterface ui)
        {
            Ui = ui;
        }

        public void SetInterface(IInterface ui)
        {
            Ui = ui;
        }

        public abstract List<string> DisplayMenu();
    }

    public sealed class WindowsSystem : SystemBase
    {
        public WindowsSystem(IInterface ui) : base(ui) { }

        public override List<string> DisplayMenu()
        {
            var programs = new List<string>
            {
                "Notatnik",
                "Kalkulator",
                "Przeglądarka",
                "Menedżer plików"
            };

            Console.WriteLine("System Windows: Zainstalowane programy:");
            foreach (var p in programs)
                Console.WriteLine($"- {p}");

            return programs;
        }
    }

    public sealed class LinuxSystem : SystemBase
    {
        public LinuxSystem(IInterface ui) : base(ui) { }

        public override List<string> DisplayMenu()
        {
            var programs = new List<string>
            {
                "Terminal",
                "Edytor tekstu",
                "Menadżer pakietów",
                "Przeglądarka"
            };

            Console.WriteLine("System Linux: Zainstalowane programy:");
            foreach (var p in programs)
                Console.WriteLine($"- {p}");

            return programs;
        }
    }

    public sealed class GraphicInterface : IInterface
    {
        private readonly SystemBase _system;

        public GraphicInterface(SystemBase system)
        {
            _system = system;
        }

        public void PressMenuButton()
        {
            Console.WriteLine("[GUI] Kliknięto przycisk MENU.");
            _system.DisplayMenu();
        }
    }

    public sealed class TextInterface : IInterface
    {
        private readonly SystemBase _system;

        public TextInterface(SystemBase system)
        {
            _system = system;
        }

        public void PressMenuButton()
        {
            Console.WriteLine("[CLI] Wywołano komendę MENU.");
            _system.DisplayMenu();
        }
    }
}
