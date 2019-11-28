using System;

namespace Labirint
{
	class Field : FieldBuilder
	{
		public Field(int rows, int cols) : base(rows, cols)
		{
		}
		public Field(Field ob) : base(ob)
		{
			Rows = ob.Rows;
			Cols = ob.Cols;
			Arr = ob.Arr;
		}

		public int this[int indexRows, int indexCols]
		{
			get { return Arr[indexRows, indexCols]; }
			set { Arr[indexRows, indexCols] = value; }
		}
		public void Show()
		{
			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Cols; j++)
				{
					Console.Write(Textures( Arr[i,j]) + " ");
				}

				Console.WriteLine(" ");
			}
		}
		private char Textures(int num)
		{
			switch (num)
			{
				case 0:
					return ' ';
				case 1:
					return '■';
				case 5:
					return '╬';
				default: return '?';
			}

		}

	}
}
