using System;

enum Axis
{
	X,
	Y
}

namespace fdte
{

	public static class Window
	{
		const char _barBorder = '*';

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
			const int barsNumber = 2;

			DrawHorizontalBar();
			for (int y = 0; y < Height - barsNumber; y++)
			{
				Console.Write(_barBorder);
				for (int x = 0; x < Width - barsNumber; x++)
				{
					Console.Write(' ');
				}
				Console.Write(_barBorder);
			}
			DrawHorizontalBar();
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

		private static void DrawHorizontalBar()
		{
			for (int x = 0; x < Width; x++)
			{
				Console.Write(_barBorder);
			}
		}
	}
}