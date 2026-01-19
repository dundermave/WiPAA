using System;
using System.Threading;

namespace Singleton
{
    public sealed class Vault
    {
        private static readonly Lazy<Vault> _instance =
            new Lazy<Vault>(() => new Vault(), isThreadSafe: true);

        public static Vault Instance => _instance.Value;

        private readonly string _digitalKey;
        private int _accessed;

        private Vault()
        {
            _digitalKey = Guid.NewGuid().ToString();
        }

        public string GetDigitalKey()
        {
            if (Interlocked.Exchange(ref _accessed, 1) == 1)
                throw new InvalidOperationException("Klucz dostępu został już użyty.");

            return _digitalKey;
        }
    }
}
