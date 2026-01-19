using System;

namespace Proxy
{
    public interface IFileResource
    {
        void Download();
    }

    public sealed class PublicFile : IFileResource
    {
        private readonly string _fileName;

        public PublicFile(string fileName)
        {
            _fileName = fileName;
        }

        public void Download()
        {
            Console.WriteLine($"[PUBLIC] Pobieranie pliku: {_fileName}");
            Console.WriteLine("[PUBLIC] Pobieranie zakończone.");
        }
    }

    public sealed class ProtectedFile : IFileResource
    {
        private readonly string _fileName;

        public ProtectedFile(string fileName)
        {
            _fileName = fileName;
        }

        public void Download()
        {
            Console.WriteLine($"[PROTECTED] Pobieranie pliku: {_fileName}");
            Console.WriteLine("[PROTECTED] Pobieranie zakończone.");
        }
    }

    public sealed class ProtectedFileProxy : IFileResource
    {
        private readonly ProtectedFile _realFile;
        private readonly string _expectedPassword;

        public ProtectedFileProxy(string fileName, string expectedPassword)
        {
            _realFile = new ProtectedFile(fileName);
            _expectedPassword = expectedPassword;
        }

        public bool VerifyPassword(string providedPassword)
        {
            return string.Equals(providedPassword, _expectedPassword, StringComparison.Ordinal);
        }

        public void Download()
        {
            Console.WriteLine("[PROXY] Brak autoryzacji. Najpierw zweryfikuj hasło w interfejsie użytkownika.");
        }

        public void DownloadAuthorized()
        {
            _realFile.Download();
        }
    }
}
