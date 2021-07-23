using System;

namespace FabioChess
{
	public static class Program
	{
		[STAThread]
		static void Main()
		{
			using (var game = new SharedGame())
				game.Run();
		}
	}
}
