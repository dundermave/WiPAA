using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Strategy
{
    public sealed record PhotoHit(
        string Source,     
        string Title,      
        string PreviewUrl, 
        string PageUrl     
    );

    public interface IPhotoSearchStrategy
    {
        Task<IReadOnlyList<PhotoHit>> SearchByCategoryAsync(
            string categoryName,
            int limit,
            CancellationToken cancellationToken = default
        );
    }

    public sealed class PhotoSearchClient
    {
        private IPhotoSearchStrategy _strategy;

        public PhotoSearchClient(IPhotoSearchStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IPhotoSearchStrategy strategy)
        {
            _strategy = strategy;
        }

        public Task<IReadOnlyList<PhotoHit>> SearchAsync(
            string categoryName,
            int limit = 5,
            CancellationToken cancellationToken = default
        )
        {
            return _strategy.SearchByCategoryAsync(categoryName, limit, cancellationToken);
        }
    }


    public sealed class PexelsSearchStrategy : IPhotoSearchStrategy
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public PexelsSearchStrategy(HttpClient httpClient, string apiKey)
        {
            _http = httpClient;
            _apiKey = apiKey;
        }

        public async Task<IReadOnlyList<PhotoHit>> SearchByCategoryAsync(
            string categoryName,
            int limit,
            CancellationToken cancellationToken = default
        )
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                throw new InvalidOperationException("Brak PEXELS_API_KEY w zmiennych środowiskowych.");

            var url =
                $"https://api.pexels.com/v1/search?query={Uri.EscapeDataString(categoryName)}&per_page={Math.Clamp(limit, 1, 80)}";

            using var req = new HttpRequestMessage(HttpMethod.Get, url);
            req.Headers.Authorization = new AuthenticationHeaderValue("Authorization", _apiKey);
            req.Headers.Remove("Authorization");
            req.Headers.Add("Authorization", _apiKey);

            using var resp = await _http.SendAsync(req, cancellationToken);
            var json = await resp.Content.ReadAsStringAsync(cancellationToken);

            if (!resp.IsSuccessStatusCode)
                throw new HttpRequestException($"Pexels API error: {(int)resp.StatusCode} {resp.ReasonPhrase}\n{json}");

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            var results = new List<PhotoHit>();
            if (root.TryGetProperty("photos", out var photos) && photos.ValueKind == JsonValueKind.Array)
            {
                foreach (var p in photos.EnumerateArray())
                {
                    var id = p.TryGetProperty("id", out var idEl) ? idEl.ToString() : "n/a";
                    var photographer = p.TryGetProperty("photographer", out var phEl) ? phEl.GetString() : null;
                    var pageUrl = p.TryGetProperty("url", out var urlEl) ? urlEl.GetString() : null;

                    string? preview = null;
                    if (p.TryGetProperty("src", out var srcEl) && srcEl.ValueKind == JsonValueKind.Object)
                    {
                        if (srcEl.TryGetProperty("medium", out var medEl)) preview = medEl.GetString();
                        else if (srcEl.TryGetProperty("small", out var smEl)) preview = smEl.GetString();
                    }

                    results.Add(new PhotoHit(
                        Source: "Pexels",
                        Title: $"{categoryName} | {photographer ?? "autor n/a"} | #{id}",
                        PreviewUrl: preview ?? "(brak)",
                        PageUrl: pageUrl ?? "(brak)"
                    ));

                    if (results.Count >= limit) break;
                }
            }

            return results;
        }
    }

    public sealed class PixabaySearchStrategy : IPhotoSearchStrategy
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public PixabaySearchStrategy(HttpClient httpClient, string apiKey)
        {
            _http = httpClient;
            _apiKey = apiKey;
        }

        public async Task<IReadOnlyList<PhotoHit>> SearchByCategoryAsync(
            string categoryName,
            int limit,
            CancellationToken cancellationToken = default
        )
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                throw new InvalidOperationException("Brak PIXABAY_API_KEY w zmiennych środowiskowych.");

            var url =
                $"https://pixabay.com/api/?key={Uri.EscapeDataString(_apiKey)}&q={Uri.EscapeDataString(categoryName)}&per_page={Math.Clamp(limit, 3, 200)}&safesearch=true";

            using var resp = await _http.GetAsync(url, cancellationToken);
            var json = await resp.Content.ReadAsStringAsync(cancellationToken);

            if (!resp.IsSuccessStatusCode)
                throw new HttpRequestException($"Pixabay API error: {(int)resp.StatusCode} {resp.ReasonPhrase}\n{json}");

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            var results = new List<PhotoHit>();
            if (root.TryGetProperty("hits", out var hits) && hits.ValueKind == JsonValueKind.Array)
            {
                foreach (var h in hits.EnumerateArray())
                {
                    var id = h.TryGetProperty("id", out var idEl) ? idEl.ToString() : "n/a";
                    var tags = h.TryGetProperty("tags", out var tagsEl) ? tagsEl.GetString() : null;
                    var pageUrl = h.TryGetProperty("pageURL", out var pageEl) ? pageEl.GetString() : null;

                    var preview = h.TryGetProperty("previewURL", out var prevEl) ? prevEl.GetString() : null;

                    results.Add(new PhotoHit(
                        Source: "Pixabay",
                        Title: $"{categoryName} | {tags ?? "tagi n/a"} | #{id}",
                        PreviewUrl: preview ?? "(brak)",
                        PageUrl: pageUrl ?? "(brak)"
                    ));

                    if (results.Count >= limit) break;
                }
            }

            return results;
        }
    }
}
