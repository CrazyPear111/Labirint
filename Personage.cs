using System;

namespace Labirint
{
	class Personage
	{
		private Field field;
		private int x, y;
		public bool Complete { get; private set; }
		Random rnd = new Random();

		public Personage(Field ob)
		{
			field = new Field(ob);
		}
		public void Spawn()
		{
			int dot;
			do
			{
				dot = rnd.Next(field.Cols - 2) + 1;
				if (field[field.Rows - 1, dot] == 0) field[field.Rows - 1, dot] = 5;
			} while (field[field.Rows - 1, dot] == 1);

			x = dot;
			y = field.Rows - 1;
		}

		public void Moove(string direction)
		{
			switch (direction)
			{
				case "up":
					if ( y != 0 && field[y - 1, x] == 0) y--;
					break;

				case "down":
					if ((y + 1 != field.Rows)  &&  field[y + 1, x] == 0) y++;
						break;

				case "left":
					if (x != 0  &&  field[y, x - 1] == 0) x--;
					break;

				case "right":
					if ((x+1 != field.Cols)  &&  field[y, x + 1] == 0) x++;
					break;
			}
		}
		public void Position(string dir)
		{
			Console.Clear();
			field[y, x] = 0;
			Moove(dir);
			field[y, x] = 5;
			field.Show();
			Finish();
		}

		public void Finish()
		{
			for (int j = 0; j<field.Rows; j++)
			{
				if (field[0, j] == 5)
				{
					Complete = true;
					Console.Clear();
					Console.WriteLine("\n\n\n\t\t\tУРОВЕНЬ ПРОЙДЕН!!!");
				}
			}
		}
	}
}
