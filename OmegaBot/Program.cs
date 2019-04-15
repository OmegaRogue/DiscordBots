using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;
using OmegaBot2.Commands;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;
using OmegaBot2.Entities;

namespace OmegaBot
{
	class Program
	{
		
		static DiscordClient discord;

		private static InteractivityExtension _interactivity;
		static CommandsNextExtension commands;

		private static Config _config;
		
		private static readonly CancellationTokenSource CancelSource = new CancellationTokenSource();
		private static readonly CancellationToken Cancel = CancelSource.Token;
		
		static void Main(string[] args)
		{
			if (!File.Exists("config.json"))
			{
				if(!File.Exists("config.example.json"))
					new Config().SaveToFile("config.example.json");
				File.Copy("config.example.json","config.json");
			}

			AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
			MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
		}
		
		static async Task MainAsync(string[] args)
		{
			_config = Config.LoadFromFile("config.json");
			
			discord = new DiscordClient(new DiscordConfiguration
			{
				Token = _config.Token,
				TokenType = TokenType.Bot,
				UseInternalLogHandler = true,
				LogLevel = LogLevel.Debug

			});
			
			var deps = new ServiceCollection()
				.AddSingleton(new Random())
				.BuildServiceProvider();
			
			
			
			commands = discord.UseCommandsNext(new CommandsNextConfiguration
			{
				StringPrefixes = _config.DefaultPrefixes,
				DmHelp = _config.DmHelp,
				CaseSensitive = _config.Case,
				EnableDms = _config.Dms,
				EnableDefaultHelp = true,
				Services = deps
				
			});
			
			
			
			
			commands.RegisterCommands<General>();
			
			
			await discord.ConnectAsync();
			await Task.Delay(-1, Cancel);

		}
		
		private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
		{
			discord.DisconnectAsync().ConfigureAwait(false).GetAwaiter().GetResult();
			CancelSource.Cancel();
			
		}
	}
}