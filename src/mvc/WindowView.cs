using Microsoft.VisualBasic.CompilerServices;
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
		private const int _cursorSize = 1;
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
			int textAreaHeight = Height - (_barHeight * _barsNumber) - _cursorSize;

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

			if (TextProcessorModel.Text.Count <= textAreaHeight)
			{
				RenderSmallAmountOfText(textAreaHeight);
			}
			else
			{
				ScrollVertically(textAreaHeight);
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

		private static void RenderSmallAmountOfText(int textAreaHeight)
		{
			for (int y = 0; y < textAreaHeight; y++)
			{
				if (y < TextProcessorModel.Text.Count)
				{
					RenderLine(TextProcessorModel.Text[y]);
					if (y == TextProcessorModel.Text.Count - 1)
					{
						Console.WriteLine(_cursor);
					}
				}
				Console.WriteLine();
			}
		}

		private static void ScrollVertically(int textAreaHeight)
		{
			for (int y = TextProcessorModel.Text.Count - textAreaHeight - 1; y < TextProcessorModel.Text.Count; y++)
			{
				RenderLine(TextProcessorModel.Text[y]);
				if (y == TextProcessorModel.Text.Count - 1)
				{
					Console.WriteLine(_cursor);
				}
				else
				{
					Console.WriteLine();
				}
			}
		}

		private static void RenderLine(string line)
		{
			int renderedLineWidth = 0;
			int tabsAmount = 0;

			for (int i = 0; i < line.Length; i++)
			{
				if (line[i] == '\t')
				{
					renderedLineWidth += 8;
					tabsAmount++;
				}
				else
				{
					renderedLineWidth++;
				}
			}
			if ((renderedLineWidth + _cursorSize) > Width) // Scroll horizontally.
			{
				for (int i = line.Length + _cursorSize - Width; i < line.Length; i++)
				{
					Console.Write(line[i]);
				}
			}
			else
			{
				Console.Write(line);
			}
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