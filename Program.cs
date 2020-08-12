using System;

namespace fdte
{
	class Program
	{
		static void Main(string[] args)
		{
			TextProcessorModel.init();
			for (;;)
			{
				WindowView.Render();
				KeyboardController.waitOnInput();
			}
		}
	}
}
