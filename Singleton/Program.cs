using System;

namespace Singleton
{
    class Program
    {
        static void Main()
        {
            var vault = Vault.Instance;

            Console.WriteLine($"Klucz dostępu: {vault.GetDigitalKey()}");

            try
            {
                Console.WriteLine($"Klucz dostępu: {vault.GetDigitalKey()}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
        }
    }
}
