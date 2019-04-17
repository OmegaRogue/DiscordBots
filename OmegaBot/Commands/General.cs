using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace OmegaBot.Commands
{
	
	
	[Group("General"), Aliases("g")]
	public class General : BaseCommandModule
	{



		[Command("hi")]
		public async Task Hi(CommandContext ctx)
		{
			await ctx.RespondAsync($"👋 Hi, {ctx.User.Mention}!");
		}

		[Command("startdm"), RequireOwner]
		public async Task StartDmAsync(CommandContext ctx)
		{
			await ctx.Member.SendMessageAsync("Text");
			var member = ctx.Member;
		}

		

		
	}
}