

using PasswordGeneratorCLI.Enums;
using PasswordGeneratorCLI.Exceptions;

namespace PasswordGeneratorCLI.Services
{
    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        private readonly Random random = new Random();
        public async Task<string> GeneratePassword(Dictionary<Options, int> configurations)
        {
            ValidateConfigurations(configurations);

            List<char> output = new();

            if (configurations[Options.Length] > 0)
            {
                int counter = 0;
                while (counter < configurations[Options.Length])
                {
                    
                    
                }
            }

            return "";
        }

        private static void ValidateConfigurations(Dictionary<Options, int> configurations)
        {
            if (configurations[Options.Length] < 0)
            {
                throw new InvalidLengthException("Length can't be less than 0.");
            }

            if (configurations[Options.CapitalLetters] < 0)
            {
                throw new InvalidPromptException("Capital Letters can't be less than 0.");
            }

            if (configurations[Options.SpecialCharacters] < 0)
            {
                throw new InvalidPromptException("Special characters can't be less than 0.");
            }

            if (configurations[Options.Numbers] < 0)
            {
                throw new InvalidPromptException("Numbers can't be less than 0.");
            }
        }
    }
}
