using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using org.mariuszgromada.math.mxparser;
using OmegaBot.Utils;

namespace OmegaBot.Commands
{
	[Group("Math"), Aliases("=")]
	public class Maths : BaseCommandModule
	{

		public ArgParser ArguParser = new ArgParser {Flag = "arg"};
		public ArgParser FunctParser = new ArgParser {Flag = "func"};
		public ArgParser ParamParser = new ArgParser {Flag = "param"};
		public ArgParser ConstParser = new ArgParser {Flag = "const"};
		
		[Command("eval"), Description("Evaluate Mathematic Expressions.")]
		public async Task MathAsync(CommandContext ctx, [Description("The expression")] string math , [Description(
			"Additional Data\n" +
			"use arg:<argument name>=<argument value> to define an Argument.\n" +
			"use func:<function name>(<params>)=<function body> to define a Function.\n" +
			"Example:\n" +
			"/= eval 2*x+a-f(10) arg:x=2 arg:a=sin(10) func:f(t)=t^2")] params string[] args)
		{
			List<Argument> arguments = new List<Argument>();
			List<Function> functions = new List<Function>();
			foreach (var arg in args)
			{
				if (ArguParser.FlagDetected(arg))
				{
					var ar = new Argument(ArguParser.GetArg(arg));
					arguments.Add(ar);
				} else if (FunctParser.FlagDetected(arg))
				{
					var fun = new Function(FunctParser.GetArg(arg));
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

		//[Command("addconst"), Hidden]
		public async Task AddConstantAsync(CommandContext ctx, string name, params string[] body)
		{
			string buffer = "";
			foreach (var s in body)
			{
				buffer += s;
			}
			UserStorageExists(ctx.User);
			var storage = GetUserStorage(ctx);
			storage.Consts.Add(name, new Constant(name + "=" + buffer).getConstantValue());
			SaveUserStorage(ctx, storage);
			await ctx.RespondAsync("Added Constant " + name);
			
		}
		
		//[Command("removeconst"), Hidden]
		public async Task RemoveConstAsync(CommandContext ctx, string name)
		{
			UserStorageExists(ctx.User);
			var storage = GetUserStorage(ctx);
			var constant = storage.Consts[name];
			
			storage.Consts.Remove(name);
			SaveUserStorage(ctx, storage);
			await ctx.RespondAsync("Removed Constant " + name);
		}
		
		//[Command("addfunct"), Hidden]
		public async Task AddFunctionAsync(CommandContext ctx, string name, params string[] body)
		{
			List<string> param = new List<string>();
			List<string> functs = new List<string>();
			List<string> argu = new List<string>();
			List<string> consts = new List<string>();
			string buffer = "";
			foreach (var s in body)
			{
				if (ParamParser.FlagDetected(s))
				{
					param.Add(ParamParser.GetArg(s));
				}
				else if (ArguParser.FlagDetected(s))
				{
					argu.Add(ArguParser.GetArg(s));
				} 
				else if (FunctParser.FlagDetected(s))
				{
					functs.Add(FunctParser.GetArg(s));
				}
				else if (ConstParser.FlagDetected(s))
				{
					consts.Add(ConstParser.GetArg(s));
				}
				else
				{
					buffer += s;
				}
				
			}
			
			UserStorageExists(ctx.User);
			var storage = GetUserStorage(ctx);
			storage.Functs.Add(name, new FunctionStore {Name = name, Body = buffer, Params = param, RefArgs = argu, RefConsts = consts, RefFuncts = functs});
			SaveUserStorage(ctx, storage);
			await ctx.RespondAsync("Added Function " + name);
			
		}
		
		//[Command("removefunct"), Hidden]
		public async Task RemoveFunctionAsync(CommandContext ctx, string name)
		{
			UserStorageExists(ctx.User);
			var storage = GetUserStorage(ctx);
			var funct = storage.Functs[name];
			
			storage.Functs.Remove(name);
			SaveUserStorage(ctx, storage);
			await ctx.RespondAsync("Removed Function " + name);
		}

		public static void SaveUserStorage(CommandContext ctx, MathStorage storage)
		{
			storage.SaveToFile("MathStorage/" + ctx.User.Id + ".usermath.json");
		}

		public static MathStorage GetUserStorage(CommandContext ctx)
		{
			return MathStorage.LoadFromFile("MathStorage/" + ctx.User.Id + ".usermath.json");
		}


		public void UserStorageExists(DiscordUser user)
		{
			if (!Directory.Exists("MathStorage"))
				Directory.CreateDirectory("MathStorage");
			if (!File.Exists("MathStorage/" + user.Id + ".usermath.json"))
			{
				new MathStorage(user.Id).SaveToFile("MathStorage/" + user.Id + ".usermath.json");
			}
			
		}
	}
}