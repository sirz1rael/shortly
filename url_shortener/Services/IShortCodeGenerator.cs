// none

namespace url_shortener.Services
{
    public interface IShortCodeGenerator
    {
        Task<string> GenerateUniqueCodeAsync();
    }
}
