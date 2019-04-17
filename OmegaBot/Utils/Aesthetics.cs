using System.Collections.Generic;

namespace OmegaBot.Utils
{
	public static class Aesthetics
	{

		//▲►▼◄═║╔╗╚╝╠╣╦╩╬─│┌┐└┘├┤┬┴┼╒╓╕╖╘╙╛╜╞╟╡╢╤╥╧╨╪╫░█

		
	
		private static Dictionary<string,string> Lines = new Dictionary<string,string>
		{
			{ "TB",  "╔════════════════════╗" },
			{ "T0",  "╔╤═══════════════════╗" },
			{ "T1",  "╔═╤══════════════════╗" },
			{ "T2",  "╔══╤═════════════════╗" },
			{ "T3",  "╔═══╤════════════════╗" },
			{ "T4",  "╔════╤═══════════════╗" },
			{ "T5",  "╔═════╤══════════════╗" },
			{ "T6",  "╔══════╤═════════════╗" },
			{ "T7",  "╔═══════╤════════════╗" },
			{ "T8",  "╔════════╤═══════════╗" },
			{ "T9",  "╔═════════╤══════════╗" },
			{ "T10", "╔══════════╤═════════╗" },
			{ "T11", "╔═══════════╤════════╗" },
			{ "T12", "╔════════════╤═══════╗" },
			{ "T13", "╔═════════════╤══════╗" },
			{ "T14", "╔══════════════╤═════╗" },
			{ "T15", "╔═══════════════╤════╗" },
			{ "T16", "╔════════════════╤═══╗" },
			{ "T17", "╔═════════════════╤══╗" },
			{ "T18", "╔══════════════════╤═╗" },
			{ "T19", "╔═══════════════════╤╗" },
			{ "EB",  "║                    ║" },
			{ "E0",  "║│                   ║" },
			{ "E1",  "║ │                  ║" },
			{ "E2",  "║  │                 ║" },
			{ "E3",  "║   │                ║" },
			{ "E4",  "║    │               ║" },
			{ "E5",  "║     │              ║" },
			{ "E6",  "║      │             ║" },
			{ "E7",  "║       │            ║" },
			{ "E8",  "║        │           ║" },
			{ "E9",  "║         │          ║" },
			{ "E10", "║          │         ║" },
			{ "E11", "║           │        ║" },
			{ "E12", "║            │       ║" },
			{ "E13", "║             │      ║" },
			{ "E14", "║              │     ║" },
			{ "E15", "║               │    ║" },
			{ "E16", "║                │   ║" },
			{ "E17", "║                 │  ║" },
			{ "E18", "║                  │ ║" },
			{ "E19", "║                   │║" },
			{ "L0",  "╟┼───────────────────╢" },
			{ "L1",  "╟─┼──────────────────╢" },
			{ "L2",  "╟──┼─────────────────╢" },
			{ "L3",  "╟───┼────────────────╢" },
			{ "L4",  "╟────┼───────────────╢" },
			{ "L5",  "╟─────┼──────────────╢" },
			{ "L6",  "╟──────┼─────────────╢" },
			{ "L7",  "╟───────┼────────────╢" },
			{ "L8",  "╟────────┼───────────╢" },
			{ "L9",  "╟─────────┼──────────╢" },
			{ "L10", "╟──────────┼─────────╢" },
			{ "L11", "╟───────────┼────────╢" },
			{ "L12", "╟────────────┼───────╢" },
			{ "L13", "╟─────────────┼──────╢" },
			{ "L14", "╟──────────────┼─────╢" },
			{ "L15", "╟───────────────┼────╢" },
			{ "L16", "╟────────────────┼───╢" },
			{ "L17", "╟─────────────────┼──╢" },
			{ "L18", "╟──────────────────┼─╢" },
			{ "L19", "╟───────────────────┼╢" },
			{ "BB",  "╚════════════════════╝" },
			{ "B0",  "╚╧═══════════════════╝" },
			{ "B1",  "╚═╧══════════════════╝" },
			{ "B2",  "╚══╧═════════════════╝" },
			{ "B3",  "╚═══╧════════════════╝" },
			{ "B4",  "╚════╧═══════════════╝" },
			{ "B5",  "╚═════╧══════════════╝" },
			{ "B6",  "╚══════╧═════════════╝" },
			{ "B7",  "╚═══════╧════════════╝" },
			{ "B8",  "╚════════╧═══════════╝" },
			{ "B9",  "╚═════════╧══════════╝" },
			{ "B10", "╚══════════╧═════════╝" },
			{ "B11", "╚═══════════╧════════╝" },
			{ "B12", "╚════════════╧═══════╝" },
			{ "B13", "╚═════════════╧══════╝" },
			{ "B14", "╚══════════════╧═════╝" },
			{ "B15", "╚═══════════════╧════╝" },
			{ "B16", "╚════════════════╧═══╝" },
			{ "B17", "╚═════════════════╧══╝" },
			{ "B18", "╚══════════════════╧═╝" },
			{ "B19", "╚═══════════════════╧╝" }
		};
		//░█
		public static Dictionary<char, string> Alphabet = new Dictionary<char, string>
		{
			{' ',
				"░░░\n" +
				"░░░\n" +
				"░░░\n" +
				"░░░\n" +
				"░░░\n"},
			{'A',
				"░███░\n" +
				"█░░░█\n" +
				"█████\n" +
				"█░░░█\n" +
				"█░░░█\n"},
			{'B',
				"████░\n" +
				"█░░░█\n" +
				"████░\n" +
				"█░░░█\n" +
				"████░\n"},
			{'C',
				"█████\n" +
				"█░░░░\n" +
				"█░░░░\n" +
				"█░░░░\n" +
				"█████\n"},
			{'D',
				"████░\n" +
				"█░░░█\n" +
				"█░░░█\n" +
				"█░░░█\n" +
				"████░\n"},
			{'E',
				"█████\n" +
				"█░░░░\n" +
				"████░\n" +
				"█░░░░\n" +
				"█████\n"},
			{'F',
				"█████\n" +
				"█░░░░\n" +
				"████░\n" +
				"█░░░░\n" +
				"█░░░░\n"},
			{'G',
				"█████\n" +
				"█░░░░\n" +
				"█░░██\n" +
				"█░░░█\n" +
				"█████\n"},
			{'H',
				"█░░░█\n" +
				"█░░░█\n" +
				"█████\n" +
				"█░░░█\n" +
				"█░░░█\n"},
			{'I',
				"░░█░░\n" +
				"░░█░░\n" +
				"░░█░░\n" +
				"░░█░░\n" +
				"░░█░░\n"},
			{'J',
				"░░░░█\n" +
				"░░░░█\n" +
				"░░░░█\n" +
				"█░░░█\n" +
				"░███░\n"},
			{'K',
				"█░░░█\n" +
				"█░░█░\n" +
				"███░░\n" +
				"█░░█░\n" +
				"█░░░█\n"},
			{'L',
				"█░░░░\n" +
				"█░░░░\n" +
				"█░░░░\n" +
				"█░░░░\n" +
				"█████\n"},
			{'M',
				"█░░░█\n" +
				"██░██\n" +
				"█░█░█\n" +
				"█░░░█\n" +
				"█░░░█\n"},
			{'N',
				"█░░░█\n" +
				"██░░█\n" +
				"█░█░█\n" +
				"█░░██\n" +
				"█░░░█\n"},
			{'O',
				"█████\n" +
				"█░░░█\n" +
				"█░░░█\n" +
				"█░░░█\n" +
				"█████\n"},
			{'P',
				"███░░\n" +
				"█░░█░\n" +
				"███░░\n" +
				"█░░░░\n" +
				"█░░░░\n"},
			{'Q',
				"░███░\n" +
				"█░░░█\n" +
				"█░░░█\n" +
				"█░░██\n" +
				"░████\n"},
			{'R',
				"███░░\n" +
				"█░░█░\n" +
				"███░░\n" +
				"█░░█░\n" +
				"█░░░█\n"},
			{'S',
				"░████\n" +
				"█░░░░\n" +
				"█████\n" +
				"░░░░█\n" +
				"████░\n"},
			{'T',
				"█████\n" +
				"░░█░░\n" +
				"░░█░░\n" +
				"░░█░░\n" +
				"░░█░░\n"},
			{'U',
				"█░░░█\n" +
				"█░░░█\n" +
				"█░░░█\n" +
				"█░░░█\n" +
				"█████\n"},
			{'V',
				"█░░░█\n" +
				"█░░░█\n" +
				"█░░░█\n" +
				"░█░█░\n" +
				"░░█░░\n"},
			{'W',
				"█░░░█\n" +
				"█░░░█\n" +
				"█░█░█\n" +
				"██░██\n" +
				"█░░░█\n"},
			{'X',
				"█░░░█\n" +
				"░█░█░\n" +
				"░░█░░\n" +
				"░█░█░\n" +
				"█░░░█\n"},
			{'Y',
				"█░░░█\n" +
				"░█░█░\n" +
				"░░█░░\n" +
				"░░█░░\n" +
				"░░█░░\n"},
			{'Z',
				"█████\n" +
				"░░░█░\n" +
				"░░█░░\n" +
				"░█░░░\n" +
				"█████\n"},
			{'.',
				"░░░░░\n" +
				"░░░░░\n" +
				"░░░░░\n" +
				"░░░░░\n" +
				"░░█░░\n"},
			{'!',
				"░░█░░\n" +
				"░░█░░\n" +
				"░░█░░\n" +
				"░░░░░\n" +
				"░░█░░\n"},
			{'?',
				"░██░░\n" +
				"░░░█░\n" +
				"░░█░░\n" +
				"░░░░░\n" +
				"░░█░░\n"},
			{':',
				"░░░░░\n" +
				"░░█░░\n" +
				"░░░░░\n" +
				"░░█░░\n" +
				"░░░░░\n"},
			{';',
				"░░░░░\n" +
				"░░█░░\n" +
				"░░░░░\n" +
				"░░█░░\n" +
				"░█░░░\n"},
			{'-',
				"░░░░░\n" +
				"░░░░░\n" +
				"░███░\n" +
				"░░░░░\n" +
				"░░░░░\n"},
			{'_',
				"░░░░░\n" +
				"░░░░░\n" +
				"░░░░░\n" +
				"░░░░░\n" +
				"█████\n"},
			{',',
				"░░░░░\n" +
				"░░░░░\n" +
				"░░░░░\n" +
				"░░█░░\n" +
				"░█░░░\n"},
			{'+',
				"░░░░░\n" +
				"░░█░░\n" +
				"░███░\n" +
				"░░█░░\n" +
				"░░░░░\n"},
			{'/',
				"░░░░█\n" +
				"░░░█░\n" +
				"░░█░░\n" +
				"░█░░░\n" +
				"█░░░░\n"},
			{'#',
				"░█░█░\n" +
				"█████\n" +
				"░█░█░\n" +
				"█████\n" +
				"░█░█░\n"},
			{'(',
				"░░█░░\n" +
				"░█░░░\n" +
				"░█░░░\n" +
				"░█░░░\n" +
				"░░█░░\n"},
			{')',
				"░░█░░\n" +
				"░░░█░\n" +
				"░░░█░\n" +
				"░░░█░\n" +
				"░░█░░\n"},
			{'[',
				"░██░░\n" +
				"░█░░░\n" +
				"░█░░░\n" +
				"░█░░░\n" +
				"░██░░\n"},
			{']',
				"░░██░\n" +
				"░░░█░\n" +
				"░░░█░\n" +
				"░░░█░\n" +
				"░░██░\n"},
			{'0',
				"░███░\n" +
				"█░░░█\n" +
				"█░█░█\n" +
				"█░░░█\n" +
				"░███░\n"},
			{'1',
				"░░█░░\n" +
				"░██░░\n" +
				"░░█░░\n" +
				"░░█░░\n" +
				"░███░\n"},
			{'2',
				"░███░\n" +
				"█░░░█\n" +
				"░░██░\n" +
				"░█░░░\n" +
				"█████\n"},
			{'3',
				"░███░\n" +
				"█░░░█\n" +
				"░░░█░\n" +
				"█░░░█\n" +
				"░███░\n"},
			{'4',
				"░░██░\n" +
				"░█░█░\n" +
				"░████\n" +
				"░░░█░\n" +
				"░░███\n"},
			{'5',
				"█████\n" +
				"█░░░░\n" +
				"████░\n" +
				"░░░░█\n" +
				"░███░\n"},
			{'6',
				"░███░\n" +
				"█░░░░\n" +
				"████░\n" +
				"█░░░█\n" +
				"░███░\n"},
			{'7',
				"█████\n" +
				"░░░░█\n" +
				"░░░█░\n" +
				"░░█░░\n" +
				"░█░░░\n"},
			{'8',
				"░███░\n" +
				"█░░░█\n" +
				"░███░\n" +
				"█░░░█\n" +
				"░███░\n"},
			{'9',
				"░███░\n" +
				"█░░░█\n" +
				"░████\n" +
				"░░░░█\n" +
				"░███░\n"},
			{'"',
				"░█░█░\n" +
				"░█░█░\n" +
				"░░░░░\n" +
				"░░░░░\n" +
				"░░░░░\n"},
			{'<',
				"░░░█░\n" +
				"░░█░░\n" +
				"░█░░░\n" +
				"░░█░░\n" +
				"░░░█░\n"},
			{'>',
				"░█░░░\n" +
				"░░█░░\n" +
				"░░░█░\n" +
				"░░█░░\n" +
				"░█░░░\n"},
			{'{',
				"░░██░\n" +
				"░░█░░\n" +
				"░█░░░\n" +
				"░░█░░\n" +
				"░░██░\n"},
			{'}',
				"░██░░\n" +
				"░░█░░\n" +
				"░░░█░\n" +
				"░░█░░\n" +
				"░██░░\n"},
			{'*',
				"░█░█░\n" +
				"░░█░░\n" +
				"░█░█░\n" +
				"░░░░░\n" +
				"░░░░░\n"},
			{'\\',
				"█░░░░\n" +
				"░█░░░\n" +
				"░░█░░\n" +
				"░░░█░\n" +
				"░░░░█\n"},
			{'|',
				"░░░░░\n" +
				"░░░░░\n" +
				"░░░░░\n" +
				"░░░░░\n" +
				"░░░░░\n"},
			
			
		};
		
		
		
		public static string ContructLine(int x, int y)
		{
			if (x >= 0 && x < 20 && y >= 0 && y < 10)
			{
				string buffer = Lines["T" + x] + '\n';

				for (int i = 0; i < 10; i++)
				{
					if (i == y)
					{
						buffer += Lines["L" + x] + '\n';
					}
					else
					{
						buffer += Lines["E" + x] + '\n';
					}
					
				}

				return  buffer + Lines["B" + x];
			}
			else
			{
				string buffer = Lines["TB"] + '\n';

				for (int i = 0; i < 10; i++)
				{
					buffer += Lines["EB"] + '\n';
				}

				return  buffer + Lines["BB"];
			}
			
		}

		public static string FormatCode(this string input, string style = "")
		{
			return "```" + style + '\n' + input + '\n' + "```";
		}
		
		public static string ToBlockText(this string input)
		{
			string buffer = input.ToUpper();
			var buffer2 = buffer.ToCharArray();
			string buffer3 = "";
			string lineBuffer1 = "";
			string lineBuffer2 = "";
			string lineBuffer3 = "";
			string lineBuffer4 = "";
			string lineBuffer5 = "";
			string[] buffer4 = {"","","","",""};
			
			foreach (var buff in buffer2)
			{
				buffer4 = Alphabet[buff].Split('\n');
				lineBuffer1 += buffer4[0] + "░";
				lineBuffer2 += buffer4[1] + "░";
				lineBuffer3 += buffer4[2] + "░";
				lineBuffer4 += buffer4[3] + "░";
				lineBuffer5 += buffer4[4] + "░";	
			}

			buffer3 = string.Join('\n', lineBuffer1, lineBuffer2, lineBuffer3, lineBuffer4, lineBuffer5);

			return buffer3;
		}

		
	}
}