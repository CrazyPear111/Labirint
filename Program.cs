using System;

namespace Labirint
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("Выбери сложность: (числа от 2 до 9)");
			int compl = Console.Read() - 48;
			compl *= 5;
			Console.Clear();

			Field ob = new Field(compl,compl);

			ob.Build();
			ob.Show();

			Personage nick = new Personage(ob);

			Console.ReadKey();

			nick.Spawn();
			
			Console.Clear();
			ob.Show();


			int key;
			while (!nick.Complete)
			{
				key = Console.Read();
				switch (key)
				{
					case 119:
						nick.Position("up");
						break;
					case 115:
						nick.Position("down");
						break;
					case 97:
						nick.Position("left");
						break;
					case 100:
						nick.Position("right");
						break;
				}
				if(key == 32) break;

			}
			Console.ReadKey();

		}
	}
}
