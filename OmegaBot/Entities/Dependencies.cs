using System.Threading;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;

namespace OmegaBot.Entities
{
	internal class Dependencies
	{
		internal DiscordClient Client { get; set; }
		internal InteractivityModule Interactivity { get; set; }
		internal StartTimes StartTimes { get; set; }
		internal CancellationTokenSource Cts { get; set; }
	}
}