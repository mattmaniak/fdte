using System;

namespace fdte
{
	class Program
	{
		static void Main(string[] args)
		{
			TextProcessorModel.Init();
			for (;;)
			{
				WindowView.Render();
				KeyboardController.WaitOnInput();
			}
		}
	}
}
