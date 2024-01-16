using PasswordGeneratorCLI.Enums;
using PasswordGeneratorCLI.Exceptions;

namespace PasswordGeneratorCLI.Services
{
    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        private readonly Random random = new Random();
        public string GeneratePassword(Dictionary<Options, int>? configurations = null)
        {
            char[] charCollection;
            int counter = 0;
            if (configurations is not null)
            {
                ValidateConfigurations(configurations);
                charCollection = new char[configurations[Options.Length]];
                
                while (counter < configurations[Options.Length])
                {
                    charCollection[counter] = (GenerateCharacter());
                    counter++;
                }
            }
            else
            {
                charCollection = new char[16];
                for (int i = 0; i < charCollection.Length; i++)
                {
                    charCollection[i] = (GenerateCharacter());
                }
            }

            if (!charCollection.Any())
            {
                throw new Exception("There was an error generating the password");
            }

            var output = new string(charCollection);

            if (output is null)
            {
                throw new Exception("There was an error parsing the generated data.");
            }
            return output;
        }

        private static void ValidateConfigurations(Dictionary<Options, int> configurations)
        {
            if (configurations[Options.Length] < 1)
            {
                throw new InvalidLengthException("Length can't be less than 1.");
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

        private char GenerateCharacter()
        {
            var charType = random.Next(0, 4);
            char output = ' ';
            switch (charType)
            {
                case 0:
                    output = GenerateNumber();
                    break;
                case 1:
                    output = GenerateSpecialCharacter();
                    break;
                case 2:
                    output = GenerateCapitalCharacter();
                    break;
                case 3:
                    output = GenerateLowercaseCharacter();
                    break;

            }
            return output;
        }
        private char GenerateNumber()
        {
            //ASCII 0 to 9
            return Convert.ToChar(random.Next(48, 58));
        }

        private char GenerateSpecialCharacter()
        {
            //ASCII ! to / except '
            int randomNumber = 0;
            char output = ' ';
            do
            {
                randomNumber = random.Next(33, 48);
                output = Convert.ToChar(randomNumber);
            }
            while (randomNumber == 39);

            return output;
        }
        private char GenerateCapitalCharacter()
        {
            //ASCII A to Z
            return Convert.ToChar(random.Next(65, 91));
        }
        private char GenerateLowercaseCharacter()
        {
            //ASCII a to z
            return Convert.ToChar(random.Next(97, 123));
        }
    }
}