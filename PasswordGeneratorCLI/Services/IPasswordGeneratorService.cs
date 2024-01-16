using PasswordGeneratorCLI.Enums;

namespace PasswordGeneratorCLI.Services
{
    public interface IPasswordGeneratorService
    {
        string GeneratePassword(Dictionary<Options,int>? configurations = null);
    }
}
