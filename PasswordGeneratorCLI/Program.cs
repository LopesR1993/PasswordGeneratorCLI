using Cocona;
using Microsoft.Extensions.DependencyInjection;
using PasswordGeneratorCLI.Services;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddSingleton<IPasswordGeneratorService, PasswordGeneratorService>();

