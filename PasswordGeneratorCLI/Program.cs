using Cocona;
using Microsoft.Extensions.DependencyInjection;
using PasswordGeneratorCLI.Services;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddSingleton<IPasswordGeneratorService, PasswordGeneratorService>();

var app = builder.Build();
app.AddCommand("password", (IPasswordGeneratorService passwordService) =>
{

    Console.WriteLine(passwordService.GeneratePassword());
});

app.Run();
