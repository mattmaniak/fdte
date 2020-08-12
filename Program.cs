using System;

namespace fdte
{
	class Program
	{
		static void Main(string[] args)
		{
			Window.Render();
			Console.Read(); // Prevent from writing additional console info.
		}
	}
}
