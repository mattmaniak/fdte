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
		private static readonly int _minHeight = (_barHeight * _barsNumber) + _textMinRenderedLines;

		private const int _barHeight = 1;
		private const int _barsNumber = 2;
		private const int _textMinRenderedLines = 1;

		private static bool _firstFrame = true;

		private static int Width
		{
			get { return TryToRetreiveWindowAxisSize(Axis.X); }
		}

		private static int Height
		{
			get { return TryToRetreiveWindowAxisSize(Axis.Y); }
		}

		public static void Render()
		{
			if (!IsConsoleWindowBigEnough())
			{
				return;
			}
			if (_firstFrame)
			{
				_firstFrame = false;
			}
			else
			{
				Console.Clear();
			}
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

		private static int TryToRetreiveWindowAxisSize(Axis axis)
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

		private static bool IsConsoleWindowBigEnough()
		{
			if ((Width < _minWidth) || (Height < _minHeight))
			{
				Console.Clear();
				Console.WriteLine("FDTE: too small window.");

				return false;
			}
			return true;
		}
	}
}