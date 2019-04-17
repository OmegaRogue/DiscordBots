using OmegaBot.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace OmegaBot.Commands
{
	[Group("owner"), Aliases("o"), RequireOwner]
	internal class Owner : BaseCommandModule
	{
		public CancellationTokenSource Cts { get; }

		public Owner(CancellationTokenSource cts)
		{
			Cts = cts;
		}

		[Command("shutdown")]
		public async Task ShutdownAsync(CommandContext ctx)
		{
			await ctx.RespondAsync("Shutting down!");
			Cts.Cancel();
		}

		[Command("Execute")]
		public async Task ExecuteAsync(CommandContext ctx)
		{
			
		}
	}
}
