﻿using System;
using NetLibrary;

namespace ConsoleTester
{
	static public class TerminalExperiment
	{
		static public bool IsRunning { get; set; }

		static public void Run()
		{
			Link.CreatedEvent += LinkCreated;

			Link x = Net.CreateThing();

			Link number = NumberHelpers.FromNumber(4637694687);


			return;

			do
			{
				Console.Write("-> ");
				string readMessage = Console.ReadLine();

				if (string.Compare("exit", readMessage, ignoreCase: true) == 0)
					break;

				Console.Write("<- ");
				Console.WriteLine(readMessage);
			}
			while (true);
		}

		static public void LinkCreated(LinkDefinition createdLink)
		{
			Console.WriteLine("Link created: {0} {1} {2}", createdLink.Source.ToIndex(), createdLink.Linker.ToIndex(), createdLink.Target.ToIndex());
		}
	}
}
