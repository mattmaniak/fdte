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
			try
			{
				Text[0] = Text[0].Remove(Text[0].Length - 1);
			}
			catch (System.ArgumentOutOfRangeException e)
			{
				Console.Error.WriteLine(e.Message);
				System.Environment.Exit(0);
			}
		}
	}
}
