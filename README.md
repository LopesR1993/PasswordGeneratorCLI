# Random Password Generator CLI

## Description
This is a command-line interface (CLI) tool written in C# that generates random passwords. It's designed to create strong and secure passwords for your needs.

## Features
- Generate random secure passwords of 16 characters by default.
- Generate random secure passwords with dynamic composition and length.

## Dependencies
1. .NET 8 Runtime
   
## Project Install
1. Clone the repository: `git clone https://github.com/LopesR1993/PasswordGeneratorCLI.git`
2. Navigate to the project directory: `cd PasswordGeneratorCLI`
3. Build the project: `dotnet build`

## Usage
Run the tool with the following command: `dotnet run -- generate`
- `-l` : defines the length of the password
- `-s` : defines the number of special characters needed
- `-n` : defines the amount of number characthers needed
- `-u` : defines the the number of uppercase letters needed

The project can also be installed as a tool:
`dotnet tool install --global PasswordGeneratorCLI --version 1.0.0`

And then run : `securepw generate`

## Contributing
Pull requests are welcome.

## Release 0.3
Added support to only provide `-l` argument and generate the rest of the characthers randomly

## Future Upgrades
- Generating multiple passwords at once.

## License
MIT
