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

            if(configurations is not null && OnlyLengthProvided(configurations))
            {
                ValidateConfigurations(configurations);
                charCollection = PopulateCharacters(configurations[Options.Length]);
            }
            else if (configurations is not null)
            {
                ValidateConfigurations(configurations);
                charCollection = new char[configurations[Options.Length]];

                for (int i = 0; i < configurations[Options.CapitalLetters]; i++)
                {
                    charCollection[counter] = GenerateCapitalCharacter();
                    counter++;
                }

                for (int i = 0; i < configurations[Options.Numbers]; i++)
                {
                    charCollection[counter] = GenerateNumber();
                    counter++;
                }

                for (int i = 0; i < configurations[Options.SpecialCharacters]; i++)
                {
                    charCollection[counter] = GenerateSpecialCharacter();
                    counter++;
                }

                while (counter < configurations[Options.Length])
                {
                    charCollection[counter] = (GenerateLowercaseCharacter());
                    counter++;
                }

                Random.Shared.Shuffle(charCollection);
            }
            else
            {
                charCollection = PopulateCharacters(16);
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

        private bool OnlyLengthProvided(Dictionary<Options, int> configurations) 
        {
            return configurations[Options.Length] > 0 &&
                configurations[Options.Numbers] == 0 &&
                configurations[Options.CapitalLetters] == 0 &&
                configurations[Options.SpecialCharacters] == 0;
        }
        private char[] PopulateCharacters(int length)
        {
            var charCollection = new char[length];
            for (int i = 0; i < charCollection.Length; i++)
            {
                charCollection[i] = (GenerateCharacter());
            }
            return charCollection;
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