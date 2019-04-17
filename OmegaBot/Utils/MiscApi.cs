using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OmegaBot.Utils
{
	public static class MiscApi
	{
		public static Regex OptionParse = new Regex(@"(\<.+\>)");
		public static string BuildOptionString(string optionString, params string[] values)
		{
			List<string> rest = new List<string>();
			MatchCollection matches = OptionParse.Matches(optionString);
			for (int i = 0; i < matches.Count; i++)
			{
				var split = optionString.Split(matches[i].Value);
				rest.Add(split[0]);
			}
			
			
			string buffer = "";
			int j = 0;
			foreach (var s in rest)
			{
				buffer += s + values[j];
				j++;
			}

			return buffer;
		}
	}
}