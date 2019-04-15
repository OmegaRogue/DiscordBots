using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;

namespace OmegaBot2.Commands
{
	
	
	[Group("General"), Aliases("g")]
	public class General : BaseCommandModule
	{

		
		[Command("hi")]
		public async Task Hi(CommandContext ctx)
		{
			await ctx.RespondAsync($"👋 Hi, {ctx.User.Mention}!");
		}
	}
}