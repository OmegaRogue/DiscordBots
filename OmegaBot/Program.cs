using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using Microsoft.Extensions.DependencyInjection;
using OmegaBot.Commands;
using OmegaBot.Entities;
using TenorSharp;

namespace OmegaBot
{
	internal class Program
	{
		private static DiscordClient _client;

		private static InteractivityExtension _interactivity;
		private static CommandsNextExtension _commands;


		private static Config _config;

		private static readonly CancellationTokenSource CancelSource = new CancellationTokenSource();
		private static readonly CancellationToken Cancel = CancelSource.Token;

		private static readonly TenorClient _tenorClient = new TenorClient("IK6PR38UM45S");


		private static readonly DiscordActivity _poweredByTenor = new DiscordActivity
		{
			Name = "Powered By Tenor",
			StreamUrl = "https://tenor.com/",
			ActivityType = ActivityType.Streaming
		};


		private static void Main(string[] args)
		{
			if (!File.Exists("config.json"))
			{
				if (!File.Exists("config.example.json"))
					new Config().SaveToFile("config.example.json");
				File.Copy("config.example.json", "config.json");
			}

			AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
			MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
		}

		private static async Task MainAsync(string[] args)
		{
			_config = Config.LoadFromFile("config.json");
			if (_config.Token.Equals("Your token.."))
				_client = new DiscordClient(new DiscordConfiguration
				{
					Token = args[0],
					TokenType = TokenType.Bot,
					UseInternalLogHandler = true,
					LogLevel = LogLevel.Debug
				});
			else
				_client = new DiscordClient(new DiscordConfiguration
				{
					Token = _config.Token,
					TokenType = TokenType.Bot,
					UseInternalLogHandler = true,
					LogLevel = LogLevel.Debug
				});


			_interactivity = _client.UseInteractivity(new InteractivityConfiguration
				{PollBehaviour = PollBehaviour.DeleteEmojis});

			var deps = new ServiceCollection()
				.AddSingleton(new Random()).AddSingleton(CancelSource).AddSingleton(_interactivity)
				.AddSingleton(_tenorClient)
				.BuildServiceProvider();


			_commands = _client.UseCommandsNext(new CommandsNextConfiguration
			{
				StringPrefixes = _config.DefaultPrefixes,
				DmHelp = _config.DmHelp,
				CaseSensitive = _config.Case,
				EnableDms = _config.Dms,
				EnableDefaultHelp = true,
				Services = deps
			});


			_client.MessageCreated += async e =>
			{
				if (e.Channel.Topic.Contains("OmegaBot Poll"))
				{
					await e.Message.CreateReactionAsync(DiscordEmoji.FromName(e.Client, ":thumbsup:"));
					await e.Message.CreateReactionAsync(DiscordEmoji.FromName(e.Client, ":thumbsdown:"));
				}
			};


			_client.Ready += async e => { await e.Client.UpdateStatusAsync(_poweredByTenor); };


			_commands.RegisterCommands<General>();
			_commands.RegisterCommands<Maths>();
			_commands.RegisterCommands<Interactivity>();
			_commands.RegisterCommands<Owner>();


			await _client.ConnectAsync();
//			await _client.UpdateStatusAsync(new DiscordActivity
//				{Name = "Powered by Tenor", ActivityType = ActivityType.Playing});

			await Task.Delay(-1, Cancel);
		}

		private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
		{
			ExitAsync().ConfigureAwait(false).GetAwaiter().GetResult();
			CancelSource.Cancel();
		}

		private static async Task ExitAsync()
		{
			await _client.UpdateStatusAsync(userStatus: UserStatus.Offline);
		}
	}
}