using System;

enum Axis
{
	X,
	Y
}

namespace fdte
{
	public static class WindowView
	{
		private const char _cursor = '|';
		private const char _lowerBarBorder = '_';
		private const string _upperBarTitle = "Five Day Text Editor";
		private static readonly int _minWidth = _upperBarTitle.Length;

		private const int _barHeight = 1;
		private const int _barsNumber = 2;

		private static int Width
		{
			get { return TryToRetreiveWindowAxis(Axis.X); }
		}

		private static int Height
		{
			get { return TryToRetreiveWindowAxis(Axis.Y); }
		}

		public static void Render()
		{
			DrawUpperBar();
			for (int y = 0; y < Height - (_barHeight * _barsNumber) - TextProcessorModel.Text.Count; y++)
			{
				if (y < TextProcessorModel.Text.Count)
				{
					Console.Write(TextProcessorModel.Text[y]);
					if (y == TextProcessorModel.Text.Count - 1)
					{
						Console.WriteLine(_cursor);
					}
				}
				Console.WriteLine();
			}
			DrawLowerBar();
		}

		private static int TryToRetreiveWindowAxis(Axis axis)
		{
			int axisValue = 0;

			try
			{
				switch (axis)
				{
					case Axis.X:
						axisValue = Console.WindowWidth;
						break;

					case Axis.Y:
						axisValue = Console.WindowHeight;
						break;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				axisValue = 0;
			}
			return axisValue;
		}

		private static void DrawLowerBar()
		{
			for (int x = 0; x < Width; x++)
			{
				Console.Write(_lowerBarBorder);
			}
		}

		private static void DrawUpperBar()
		{
			Console.WriteLine(_upperBarTitle);
		}
	}
}