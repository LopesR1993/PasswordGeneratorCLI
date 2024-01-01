using PasswordGeneratorCLI.Enums;

namespace PasswordGeneratorCLI.Services
{
    public interface IPasswordGeneratorService
    {
        Task<string> GeneratePassword(Dictionary<Options,int> configurations);
    }
}
