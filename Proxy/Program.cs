using System;
using Proxy;

namespace Proxy
{
    internal class Program
    {
        static void Main()
        {
            IFileResource publicFile = new PublicFile("regulamin.pdf");

            var protectedProxy = new ProtectedFileProxy(
                fileName: "raport_finansowy.xlsx",
                expectedPassword: "1234"
            );

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== MENU POBIERANIA ===");
                Console.WriteLine("1) Pobierz plik publiczny (bez hasła)");
                Console.WriteLine("2) Pobierz plik zastrzeżony (wymaga hasła)");
                Console.WriteLine("0) Wyjście");
                Console.Write("Wybór: ");

                string? choice = Console.ReadLine();

                if (choice == "0")
                    break;

                if (choice == "1")
                {
                    Console.WriteLine();
                    publicFile.Download();
                    continue;
                }

                if (choice == "2")
                {
                    Console.WriteLine();
                    Console.Write("Podaj hasło dostępu: ");
                    string provided = Console.ReadLine() ?? "";

                    if (protectedProxy.VerifyPassword(provided))
                    {
                        Console.WriteLine("[PROXY] Hasło poprawne. Dostęp przyznany.");
                        protectedProxy.DownloadAuthorized();
                    }
                    else
                    {
                        Console.WriteLine("[PROXY] Hasło niepoprawne. Odmowa dostępu.");
                    }

                    continue;
                }

                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            }

            Console.WriteLine("Koniec programu.");
        }
    }
}
