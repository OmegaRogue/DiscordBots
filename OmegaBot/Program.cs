using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using OmegaBot.Commands;
using OmegaBot.Entities;

namespace OmegaBot
{
	class Program
	{
		
		public static DiscordClient discord;

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
				.AddSingleton(new Random()).AddSingleton(CancelSource)
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
			

			discord.MessageCreated += async e =>
			{
				if (e.Channel.Topic.Contains("OmegaBot Poll"))
				{
					await e.Message.CreateReactionAsync(DiscordEmoji.FromName(e.Client,":thumbsup:"));
					await e.Message.CreateReactionAsync(DiscordEmoji.FromName(e.Client,":thumbsdown:"));
				}
			}; 
			
			

			
			
			commands.RegisterCommands<General>();
			commands.RegisterCommands<Maths>();
			commands.RegisterCommands<Interactivity>();
			commands.RegisterCommands<Owner>();

			await (await (await discord.GetChannelAsync(539979481969065984)).GetMessageAsync(567713416915976214))
				.CreateReactionAsync(DiscordEmoji.FromName(discord,":thumbsup:"));
			
			await discord.ConnectAsync();
			await Task.Delay(-1, Cancel);

		}
		
		private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
		{
			
			ExitAsync().ConfigureAwait(false).GetAwaiter().GetResult();
			CancelSource.Cancel();
			
		}

		static async Task ExitAsync()
		{
			await discord.UpdateStatusAsync(userStatus: UserStatus.Offline);
		}
	}
}