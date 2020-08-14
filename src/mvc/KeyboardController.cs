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
			ConsoleKeyInfo keyInfo;

			try
			{
				switch ((keyInfo = Console.ReadKey(true)).Key)
				{
					case ConsoleKey.Escape:
						Environment.Exit(0);
						break;

					case ConsoleKey.Backspace:
						TextProcessorModel.PopChar();
						break;

					case ConsoleKey.Enter:
						TextProcessorModel.AppendLine();
						break;

					default:
						if (IsShortcutParsed(keyInfo.KeyChar - '0'))
						{
							break;
						}
						TextProcessorModel.AppendChar(keyInfo.KeyChar);
						break;
				}
			}
			catch (InvalidOperationException) { }
		}

		private static bool IsShortcutParsed(int code)
		{
			switch (code)
			{
				case -29: // CTRL+S
					FileHandler.Save("fdte.txt", TextProcessorModel.Text);
					return true;

				case -31: // CTRL+Q
					Environment.Exit(0);
					return true;

				// DEBUG
				default:
					Console.WriteLine(code);
					break;
			}
			return false;
		}
	}
}
