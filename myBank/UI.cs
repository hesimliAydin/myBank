partial class Program
{
	public static void MySetColor(ConsoleColor forground, ConsoleColor background)
	{
		Console.ForegroundColor = forground;
		Console.BackgroundColor = background;
	}

	public static bool Keyboard(ref int selected, int count)
	{
		ConsoleKey keyboard = Console.ReadKey().Key;

		switch (keyboard)
		{
			case ConsoleKey.UpArrow:
			case ConsoleKey.LeftArrow:
			case ConsoleKey.W:
			case ConsoleKey.A:
				if (selected == 0)
					selected = count;
				selected--;
				return true;
			case ConsoleKey.DownArrow:
			case ConsoleKey.RightArrow:
			case ConsoleKey.S:
			case ConsoleKey.D:
				selected++;
				selected %= count;
				return true;
			case ConsoleKey.Enter:
				return false;
			default:
				return true;
		}
	}

	public static int GetSelected(string header, string[] choices)
	{
		int select = default;
		int selectionsCount = Convert.ToInt32(choices.Length);

		bool isStart = true;
		while (isStart)
		{
			Console.Clear();
			Console.WriteLine(header);
			for (int i = 0; i < selectionsCount; i++)
			{
				char prefix = ' ';
				if (i == select)
				{
					MySetColor(ConsoleColor.DarkGreen, ConsoleColor.Cyan);
					prefix = '~';
				}
				Console.WriteLine($"{prefix} {choices[i]}");
				Console.ResetColor();
			}

			isStart = Keyboard(ref select, selectionsCount);

		}
		return select;
	}

}