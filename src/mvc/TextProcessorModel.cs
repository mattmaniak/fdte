using System;
using System.Collections.Generic;

namespace fdte
{
	public static class TextProcessorModel
	{
		public static List<string> Text = new List<string>() { "" };

		public static void AppendChar(char character)
		{
			try
			{
				Text[Text.Count - 1] += character;
			}
			catch (System.ArgumentOutOfRangeException e)
			{
				Console.Error.WriteLine(e.Message);
				System.Environment.Exit(0);
			}
		}

		public static void PopChar()
		{
			int lineIndex = Text.Count - 1;

			if (Text[lineIndex].Length > 0)
			{
				Text[lineIndex] = Text[lineIndex].Remove(Text[lineIndex].Length - 1);
			}
			else if (lineIndex > 0)
			{
				Text.RemoveAt(lineIndex);
				lineIndex--;
			}
		}

		public static void AppendLine()
		{
//			Text[Text.Count - 1] += "\r\n";
			Text.Add("");
		}
	}
}
