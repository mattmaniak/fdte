using System;

namespace fdte
{
	class Program
	{
		public static void Main(string[] args)
		{
			HandleArgs(args);
			TextProcessorModel.Text = FileHandler.Read("fdte.txt");
			for (;;)
			{
				KeyboardController.Tick();
			}
		}

		private static void HandleArgs(string[] args)
		{
			const int exitCode = 1;
			bool shouldExit = false;

			if ((args.Length > 0) && ((args[0] == "-h") || (args[0] == "--help")))
			{
				Console.WriteLine("Usage: fdte [-h] [--help]");
				shouldExit = true;
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
		}
	}
}
