using System;

namespace labs
{
	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
			if (args.Length != 2)
			{
				Console.WriteLine("Usage: labs width figure");
				Console.ReadLine();
				return;
			}

			int width;

			try
			{
				width = int.Parse(args[0]);
			}
			catch (FormatException)
			{
				Console.WriteLine("Usage: labs width figure");
				Console.ReadLine();
				return;
			}

			if (args[1] != "-p" && args[1] != "-c")
			{
				Console.WriteLine("Usage: labs width figure(-c/-p)");
				Console.ReadLine();
				return;
			}

			using (Program prog = new Program(width, args[1]))
			{
				prog.Run(30.0, 0.0);
			}
		}
	}
}
