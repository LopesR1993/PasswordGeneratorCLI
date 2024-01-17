using Cocona;
using PasswordGeneratorCLI.Services;
using PasswordGeneratorCLI.Enums;
using PasswordGeneratorCLI.Exceptions;
namespace PasswordGeneratorCLI.Commands
{
    public class PasswordGeneratorCommands
    {
        private readonly IPasswordGeneratorService _passwordGeneratorService;
        public PasswordGeneratorCommands(IPasswordGeneratorService passwordGeneratorService)
        {
            _passwordGeneratorService = passwordGeneratorService;
        }
        [Command("generate")]
        public void GeneratePassword(
            [Option('l')] string? length = null,
            [Option('n')] string? number = null,
            [Option('s')] string? special = null,
            [Option('u')] string? uppercase = null)
        {
            try
            {
                if(length is not null || number is not null || special is not null || uppercase is not null)
                {
                    var parameters = new Dictionary<Options, int>();

                    SanitizeInput(ref length, ref number, ref special, ref uppercase);  

                    if (int.TryParse(length, out _))
                    {
                        parameters[Options.Length] = int.Parse(length);
                    }
                    else
                    {
                        throw new InvalidLengthException("length has an invalid value. Must be a number and bigger than zero");
                    }

                    if(int.TryParse(number, out _))
                    {
                        parameters[Options.Numbers] = int.Parse(number);
                    }
                    else
                    {
                        throw new InvalidPromptException("number has an invalid value. Must be a number and bigger than zero");
                    }

                    if (int.TryParse(special, out _))
                    {
                        parameters[Options.SpecialCharacters] = int.Parse(special);
                    }
                    else
                    {
                        throw new InvalidPromptException("special has an invalid value. Must be a number and bigger than zero");
                    }

                    if (int.TryParse(uppercase, out _))
                    {
                        parameters[Options.CapitalLetters] = int.Parse(uppercase);
                    }
                    else
                    {
                        throw new InvalidPromptException("uppercase has an invalid value. Must be a number and bigger than zero");
                    }

                    Console.WriteLine(_passwordGeneratorService.GeneratePassword(parameters));
                }
                else
                {
                    Console.WriteLine(_passwordGeneratorService.GeneratePassword());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void SanitizeInput(ref string? length, ref string? number, ref string? special, ref string? uppercase)
        {
            if(length is null)
            {
                length = "0";
            }
            if(number is null)
            {
                number = "0";
            }
            if(special is null)
            { 
                special = "0";
            }
            if(uppercase is null)
            {
                uppercase = "0";
            }
                
        }
    }
}
