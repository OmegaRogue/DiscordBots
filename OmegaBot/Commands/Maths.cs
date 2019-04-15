using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using org.mariuszgromada.math.mxparser;

namespace OmegaBot.Commands
{
	public class Maths : BaseCommandModule
	{
		[Command("=")]
		public async Task MathAsync(CommandContext ctx, string math, params string[] args)
		{
			List<Argument> arguments = new List<Argument>();
			List<Function> functions = new List<Function>();
			foreach (var arg in args)
			{
				if (arg.StartsWith("arg:"))
				{
					var ar = new Argument(arg.Substring(4));
					arguments.Add(ar);
				} else if (arg.StartsWith("func:"))
				{
					var fun = new Function(arg.Substring(5));
					functions.Add(fun);
				}
				
			}

			Argument[] arrgs = arguments.ToArray();
			Function[] functs = functions.ToArray();

			List<PrimitiveElement> stuff = new List<PrimitiveElement>();
			stuff.AddRange(arrgs);
			stuff.AddRange(functs);
			PrimitiveElement[] stuffs = stuff.ToArray();

			Argument x = new Argument("x = 2");
			
			Expression e = new Expression(math, stuffs);
			double v = e.calculate();
			await ctx.RespondAsync(v.ToString());
		}
	}
}