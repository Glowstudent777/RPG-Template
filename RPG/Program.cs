﻿using System;

namespace RPG
{
	public static class Program
	{
		[STAThread]
		static void Main()
		{
			using (var game = new RPG.Game1()) game.Run();
		}
	}
}