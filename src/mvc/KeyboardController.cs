using System;

public static class KeyboardController
{
	public static void WaitOnInput()
	{
		ConsoleKeyInfo keyInfo = Console.ReadKey(true);
		switch (keyInfo.Key)
		{
			case ConsoleKey.Escape:
				System.Environment.Exit(0);
				break;

			case ConsoleKey.Backspace:
				TextProcessorModel.PopChar();
				break;

			default:
				TextProcessorModel.AppendChar(keyInfo.KeyChar);
				break;
		}
	}
}
