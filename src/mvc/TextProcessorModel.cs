using System;
using System.Collections.Generic;

public static class TextProcessorModel
{
	public static List<string> Text = new List<string>();

	public static void Init()
	{
		if (Text.Count == 0)
		{
			Text.Add("");
		}
	}

	public static void AppendChar(char character)
	{
		try
		{
			Text[Text.Count - 1] += character;
		}
		catch (System.ArgumentOutOfRangeException e)
		{
			Console.WriteLine(e.Message);
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
			Console.WriteLine(e.Message);
		}
	}
}
