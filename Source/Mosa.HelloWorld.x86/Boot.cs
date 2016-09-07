// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Kernel.x86;
using Mosa.Kernel.x86.Smbios;
using Mosa.Runtime.x86;
using System;

namespace Mosa.ShiftOS.x86
{
	/// <summary>
	///
	/// </summary>
	public static class Boot
	{
		public static ConsoleSession Console;

	    /// <summary>
	    /// Main
	    /// </summary>
	    public static void Main()
	    {
	        Kernel.x86.Kernel.Setup();

	        Console = ConsoleManager.Controller.Boot;

	        Console.Clear();

	        IDT.SetInterruptHandler(ProcessInterrupt);

	        Console.Color = Colors.White;

	        Console.Goto(0, 0);
            Console.WriteLine("ShiftOS 1.0.0 (Codename Cheezit)");
            Console.WriteLine("(C) 2016 Carver Harrison");
            Console.WriteLine();
	        while (true)
	        {
	            
	        }
        }

	    private static uint counter = 0;

		public static void ProcessInterrupt(uint interrupt, uint errorCode)
		{
			counter++;

			uint c = Console.Column;
			uint r = Console.Row;
			byte col = Console.Color;
			byte back = Console.BackgroundColor;

			Console.Column = 31;
			Console.Row = 0;
			Console.Color = Colors.Cyan;
			Console.BackgroundColor = Colors.Black;

            /*
			Console.Write(counter, 10, 7);
			Console.Write(':');
			Console.Write(interrupt, 16, 2);
			Console.Write(':');
			Console.Write(errorCode, 16, 2);
            */

			if (interrupt == 0x20)
			{
				// Timer Interrupt! Switch Tasks!
			}
			else
			{
                /*
				Console.Write('-');
				Console.Write(counter, 10, 7);
				Console.Write(':');
				Console.Write(interrupt, 16, 2);
                */

				if (interrupt == 0x21)
				{
					byte scancode = Keyboard.ReadScanCode();
					Console.Write('-');
					Console.Write(scancode, 16, 2);
				}
			}

			Console.Column = c;
			Console.Row = r;
			Console.Color = col;
			Console.BackgroundColor = back;
		}
	}
}
