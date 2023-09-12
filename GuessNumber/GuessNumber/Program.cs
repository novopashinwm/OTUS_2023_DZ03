using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using GuessNumber.Interfaces;
using GuessNumber.Config;
using GuessNumber.Verify;
using GuessNumber.Logic;
using GuessNumber.Logic.Players;

public class Program 
{
    static ServiceProvider? serviceProvider;
    static ILogger<Program>? _logger;
    public static AppConfig? AppConfiguration { get; set; }
    static void Main(string[] args)
    {
        var config = GetConfigurationFromJson();

        AppConfiguration = config.Get<AppConfig>();
        SettingDI();

        _logger!.LogInformation("Запуск приложения");

        var game = serviceProvider!.GetService<IGame>();
        game!.Start();
        game!.Stop();
        serviceProvider?.Dispose();
    }

    private static void SettingDI() 
    {
        // Установка DI контейнера - отражение принципа Dependancy Inversion (Инверсии зависимости)
        serviceProvider = new ServiceCollection()
            .AddSingleton(AppConfiguration!)
            .AddLogging(c => c.AddConsole(opt => opt.LogToStandardErrorThreshold = LogLevel.Debug))
            //В этом месте можем менять игрока - либо человек, либо искусственный интеллект
            .AddScoped<IPlayer, AIMachine>()
            //AddScoped<IPlayer, Human>()
            .AddScoped<ICheck, CheckNumber>()
            .AddSingleton<IGame, GuessNumberGame>()
            .BuildServiceProvider();

        _logger = serviceProvider
            .GetService<ILoggerFactory>()!
            .CreateLogger<Program>()!;
    }

    private static IConfiguration GetConfigurationFromJson()
    {
       
        var configBuilder = new ConfigurationBuilder()
                        .AddJsonFile("setting.json");

        return configBuilder.Build();
    }
}