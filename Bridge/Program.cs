using System;
using Bridge;

namespace Bridge
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("== Test 1: Windows + GUI ==");
            WindowsSystem windows = new WindowsSystem(ui: null!);
            GraphicInterface winGui = new GraphicInterface(windows);
            windows.SetInterface(winGui);

            winGui.PressMenuButton();

            Console.WriteLine();
            Console.WriteLine("== Test 2: Linux + GUI ==");
            LinuxSystem linux = new LinuxSystem(ui: null!);
            GraphicInterface linuxGui = new GraphicInterface(linux);
            linux.SetInterface(linuxGui);

            linuxGui.PressMenuButton();

            Console.WriteLine();
            Console.WriteLine("== Test 3: Linux + CLI (zmiana interfejsu bez zmiany systemu) ==");
            TextInterface linuxCli = new TextInterface(linux);
            linux.SetInterface(linuxCli);

            linuxCli.PressMenuButton();
        }
    }
}
