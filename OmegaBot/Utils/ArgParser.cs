namespace OmegaBot.Utils
{
	public class ArgParser
	{
		public string Flag { get; set; }

		public bool FlagDetected(string arg)
		{
			return arg.StartsWith(Flag + ":");
		}

		public string GetArg(string arg)
		{
			return FlagDetected(arg) ? arg.Substring(Flag.Length + 1) : null;
		}
	}
}