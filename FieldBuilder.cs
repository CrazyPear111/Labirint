using System;

namespace Labirint
{
	class FieldBuilder
	{
		public int Rows { get; protected set; }
		public int Cols { get; protected set; }
		protected int[,] Arr;
		

		protected Random rnd = new Random();

		public FieldBuilder(int rows, int cols)
		{
			this.Rows = rows;
			this.Cols = cols;
			Arr = new int[rows, cols];
		}

		public FieldBuilder(Field ob)
		{

		}


		
		private void FieldRand()
		{
			// Забить первую строку рандомом
			for (int j = 0; j < Cols; j++)
			{
				Arr[0, j] = rnd.Next(2);
			}
			// Забить остальные строки рандомом с соединенными нулями
			for (int i = 1; i < Rows; i++)
			{

				for (int j = 0; j < Cols-1; j++)
				{
					if (Arr[(i - 1), j] == 1)
					{
						Arr[i, j] = rnd.Next(2);
					}
					else if (Arr[(i - 1), ((j + 1) == Cols-1 ? j : j+1)] == 0)
					{
						Arr[i, j] = rnd.Next(2);
					}
					else Arr[i, j] = 0;

				}
			}
		}

		private void FieldRange()
		{
			// Забить первую и последнюю строки единицами
			for (int j = 0; j < Cols; j++)
			{
				Arr[0, j] = 1;
				Arr[Rows - 1, j] = 1;
			}
			// Забить первый и последний столбцы единицами
			for (int i = 1; i < Rows - 1; i++)
			{
				Arr[i, 0] = 1;          
				Arr[i, (Cols - 1)] = 1; 
			}
		}

		private void FieldHole()
		{
			// Сделать дирку внизу
			int holeLow;
			do
			{
				holeLow = rnd.Next(Cols - 2) + 1;
				if (Arr[Rows - 2, holeLow] == 0) Arr[Rows - 1, holeLow] = 0;
			} while (Arr[Rows - 2, holeLow] == 1);

			// Сделать дирку вверху
			int holeHigh;
			do
			{
				holeHigh = rnd.Next(Cols - 2) + 1;
				if (Arr[1, holeHigh] == 0) Arr[0, holeHigh] = 0;
			} while (Arr[0, holeHigh] == 1);
		}

		public void Build()
		{
			FieldRand();
			FieldRange();
			FieldHole();
		}
	}
}
