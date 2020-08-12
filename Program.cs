using System;

namespace fdte
{
	class Program
	{
		static void Main(string[] args)
		{
			for (;;)
			{
				WindowView.Render();
				KeyboardController.WaitOnInput();
			}
		}
	}
}
