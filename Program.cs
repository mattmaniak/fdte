using System;

namespace fdte
{
	class Program
	{
		public static void Main(string[] args)
		{
			if (IsArgFilename(args))
			{
				TextProcessorModel.Text = FileHandler.Read(args[0]);
			}
			for (;;)
			{
				KeyboardController.Tick();
			}
		}

		private static bool IsArgFilename(string[] args)
		{
			const int exitCode = 1;
			bool shouldExit = false;

			if (args.Length == 1)
			{
				if ((args[0] == "-h") || (args[0] == "--help"))
				{
					Console.WriteLine("Usage: fdte [-h] [--help] [BASENAME/FILENAME]");
					shouldExit = true;
				}
				else if (args[0][0] != '-')
				{
					return true;
				}
			}
			else if (args.Length > 1)
			{
				Console.Error.WriteLine("Too many args. Only one can be handled. Try: --help or -h");
				shouldExit = true;
			}
			if (shouldExit)
			{
				Environment.Exit(exitCode);
			}
			return false;
		}
	}
}
