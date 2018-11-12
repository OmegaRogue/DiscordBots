using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.VoiceNext;

namespace OmegaBot
{
    class Program
    {   
        private static DiscordClient discord;
        static CommandsNextModule commands;
        static InteractivityModule interactivity;
        static VoiceNextClient voice;
        static LavaLink
        
        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        static async Task MainAsync(string[] args)
        {
            #if DEBUG
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "Mzc4ODY2MTIwNDAyNDAzMzI5.DsnGag.z3ZRSXMJClYTXrFNBL2deTVC-mM",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });
            #else
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });
            #endif
            
            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("ping"))
                    await e.Message.RespondAsync("pong!");
            };
            
            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = ";;",
                EnableDms = false
            });
            
            commands.RegisterCommands<MyCommands>();
            
            interactivity = discord.UseInteractivity(new InteractivityConfiguration());
            
            voice = discord.UseVoiceNext(new VoiceNextConfiguration
            {
                EnableIncoming = true
            });


            
            await discord.ConnectAsync();
            await Task.Delay(-1);

        }

            
    }
}