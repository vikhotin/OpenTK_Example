using System;

namespace labs
{
	class MainClass
	{
		[STAThread]
		public static void Main()
		{
			using (Program prog = new Program())
			{
				prog.Run(30.0, 0.0);
			}
		}
	}
}
