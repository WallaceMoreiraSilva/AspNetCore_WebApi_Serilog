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
			//L� as defini��es do arquivo appsettings.json
			var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

			//Usamos uma instancia de LoggerConfiguration e a partir das informa��es obtidas no
			//arquivo appsettings criamos um logger usando os sinks, 
			//os enrichers e as demais defini��es
			Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();

			try
			{
				Log.Information("API Inicializando...");
				CreateHostBuilder(args).Build().Run();
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "A aplica��o falhou ao iniciar.");
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