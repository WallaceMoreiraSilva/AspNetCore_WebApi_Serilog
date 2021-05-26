using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace AspNetCore_WebApi_Serilog
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//Lê as definições do arquivo appsettings.json
			var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

			//Usamos uma instancia de LoggerConfiguration e a partir das informações obtidas no
			//arquivo appsettings criamos um logger usando os sinks, 
			//os enrichers e as demais definições
			Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();

			try
			{
				Log.Information("API Inicializando...");
				CreateHostBuilder(args).Build().Run();
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "A aplicação falhou ao iniciar.");
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseSerilog() //define o Serilog como provedor de Log
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}