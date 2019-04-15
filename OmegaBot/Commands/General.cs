using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
using Microsoft.VisualBasic;
using OmegaBot;
using OmegaBot.Utils;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Data;
using System.Globalization;
using org.mariuszgromada.math.mxparser;

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

		

		
	}
}