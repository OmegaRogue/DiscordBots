using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using DSharpPlus.Entities;
using Newtonsoft.Json;

namespace OmegaBot2.Entities
{
	public class Config
	{
		/// <summary>
		/// Your bot's token.
		/// </summary>
		[JsonProperty("token")]
		internal string Token = "Your token..";

		/// <summary>
		/// Your bot's prefixes
		/// </summary>
		[JsonProperty("prefixes")]
		public ImmutableArray<string> DefaultPrefixes { get; private set; } = new[] { "cc!", "//", "??" }.ToImmutableArray();

		/// <summary>
		/// Whether or not the bot accepts DM's.
		/// </summary>
		[JsonProperty("dms")] 
		internal bool Dms = true;
		
		/// <summary>
		/// Whether or not the bot's commands are Case Sensitive.
		/// </summary>
		[JsonProperty("Case Sensitivity")] 
		internal bool Case = false;
		
		/// <summary>
		/// Whether or not the bot sends help through DM's.
		/// </summary>
		[JsonProperty("DM Help")] 
		internal bool DmHelp = true;

		/// <summary>
		/// Your favourite color.
		/// </summary>
		[JsonProperty("color")]
		private string _color = "#7289DA";

		/// <summary>
		/// Your favourite color exposed as a DiscordColor object.
		/// </summary>
		internal DiscordColor Color => new DiscordColor(_color);

		/// <summary>
		/// Loads config from a JSON file.
		/// </summary>
		/// <param name="path">Path to your config file.</param>
		/// <returns></returns>
		public static Config LoadFromFile(string path)
		{
			using (var sr = new StreamReader(path))
			{
				return JsonConvert.DeserializeObject<Config>(sr.ReadToEnd());
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
	}
}