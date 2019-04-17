using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using org.mariuszgromada.math.mxparser;

namespace OmegaBot.Utils
{
	public class MathStorage
	{
		
		[JsonProperty("UserID")]
		public ulong UserId { get; set; }

		[JsonProperty("Constants")]
		public Dictionary<string, double> Consts = new Dictionary<string, double>();
		
		[JsonProperty("Functions")]
		public Dictionary<string, FunctionStore> Functs = new Dictionary<string, FunctionStore>();
		
		[JsonProperty("Arguments")]
		public Dictionary<string, double> Args = new Dictionary<string, double>();
		
		
		
		/// <summary>
		/// Loads config from a JSON file.
		/// </summary>
		/// <param name="path">Path to your config file.</param>
		/// <returns></returns>
		public static MathStorage LoadFromFile(string path)
		{
			using (var sr = new StreamReader(path))
			{
				return JsonConvert.DeserializeObject<MathStorage>(sr.ReadToEnd());
			}
		}

		/// <summary>
		/// Saves config to a JSON file.
		/// </summary>
		/// <param name="path"></param>
		public void SaveToFile(string path)
		{
			using (var sw = new StreamWriter(path))
			{
				sw.Write(JsonConvert.SerializeObject(this));
			}
		}

		public MathStorage(ulong userId)
		{
			UserId = userId;
		}

		public Function GetFunction(string name)
		{
			var funct = Functs[name];
			string param = "";
			
			
			for (int i = 0; i < funct.Params.Count-1; i++)
			{
				param += funct.Params[i] + ",";
			}

			param += funct.Params[funct.Params.Count - 1];
			
			
			
			return new Function(funct.Name + "(" + param + ") = " + funct.Body);
		}
	}
}