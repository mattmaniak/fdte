using System;

namespace fdte
{
	public static class KeyboardController
	{
		public static void Tick()
		{
			WindowView.Render();
			WaitOnInput();
			Console.Clear();
		}

		private static void WaitOnInput()
		{
			ConsoleKeyInfo keyInfo;

			try
			{
				switch ((keyInfo = Console.ReadKey(true)).Key)
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
			catch (InvalidOperationException) { }
		}
	}
}
