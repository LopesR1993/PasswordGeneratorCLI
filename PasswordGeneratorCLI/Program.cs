using Cocona;
using Microsoft.Extensions.DependencyInjection;
using PasswordGeneratorCLI.Services;
using PasswordGeneratorCLI.Commands;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddSingleton<IPasswordGeneratorService, PasswordGeneratorService>();

var app = builder.Build();

app.AddCommands<PasswordGeneratorCommands>();

app.Run();
