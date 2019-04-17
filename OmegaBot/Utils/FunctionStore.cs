using System.Collections.Generic;

namespace OmegaBot.Utils
{
	public class FunctionStore
	{
		public string Name { get; set; }
		public string Body { get; set; }
		public List<string> Params { get; set; }
		public List<string> RefArgs { get; set; }
		public List<string> RefFuncts { get; set; }
		public List<string> RefConsts { get; set; }
	}
}