using System;

namespace fdte
{
	public static class KeyboardController
	{
		public static void Tick()
		{
			WindowView.Render();
			WaitOnInput();
		}

		private static void WaitOnInput()
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

				case ConsoleKey.Enter:
					TextProcessorModel.AppendLine();
					break;

				default:
					TextProcessorModel.AppendChar(keyInfo.KeyChar);
					break;
			}
		}
	}
}
