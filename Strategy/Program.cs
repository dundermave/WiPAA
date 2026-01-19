using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Strategy
{
    internal class Program
    {
        static async Task Main()
        {
            var category = "nature";

            var pexelsKey = Environment.GetEnvironmentVariable("PEXELS_API_KEY") ?? "";
            var pixabayKey = Environment.GetEnvironmentVariable("PIXABAY_API_KEY") ?? "";

            using var http = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(20)
            };

            var client = new PhotoSearchClient(new PexelsSearchStrategy(http, pexelsKey));

            Console.WriteLine($"Szukam w Pexels dla kategorii: {category}");
            var pexelsHits = await client.SearchAsync(category, limit: 3);
            Print(pexelsHits);

            Console.WriteLine();

            client.SetStrategy(new PixabaySearchStrategy(http, pixabayKey));

            Console.WriteLine($"Szukam w Pixabay dla kategorii: {category}");
            var pixabayHits = await client.SearchAsync(category, limit: 3);
            Print(pixabayHits);
        }

        private static void Print(System.Collections.Generic.IReadOnlyList<PhotoHit> hits)
        {
            if (hits.Count == 0)
            {
                Console.WriteLine("Brak wyników.");
                return;
            }

            foreach (var h in hits)
            {
                Console.WriteLine($"[{h.Source}] {h.Title}");
                Console.WriteLine($"  Preview: {h.PreviewUrl}");
                Console.WriteLine($"  Page:    {h.PageUrl}");
            }
        }
    }
}
