// none


using url_shortener.Database;

namespace url_shortener.Services
{
    public class ShortCodeGenerator(IUrlRepository repository) : IShortCodeGenerator
    {
        private readonly IUrlRepository _urlRepository = repository;
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const int CodeLength = 6;
        public async Task<string> GenerateUniqueCodeAsync()
        {
            string code;
            do
            {
                code = GenerateRandomeCode();
            } while (await _urlRepository.ShortCodeExistsAsync(code));

            return code;
        }

        private static string GenerateRandomeCode()
        {
            var random = new Random();
            return new string([.. Enumerable.Repeat(Characters, CodeLength).Select(s => s[random.Next(s.Length)])]);
        }
    }
}
