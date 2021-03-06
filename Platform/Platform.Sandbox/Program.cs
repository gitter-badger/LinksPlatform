﻿using System;
using System.Diagnostics;
using System.IO;

namespace Platform.Sandbox
{
    internal unsafe class Program
    {
        private static void Main(string[] args)
        {
            //Sequences.TestSimplify();
            //WrongPointerTest();
            //UDPTest();
            //Links();

            Stopwatch sw = Stopwatch.StartNew();

            //Link.StartMemoryManager(@"data.dat");

            Console.WriteLine("Start time: {0}", sw.Elapsed);
            Console.WriteLine();

            //Console.WriteLine(Net.Letter.ToString());

            //UnusedLinksTest();

            //Net.Recreate();

            //var l = LinkConverter.FromString("latin alphabet");

            //CompressionDifferenceTests();

            //ThreadHelpers.SyncInvokeWithExtendedStack(() =>
            //    {
            //        FileReadWriteTest.Run();
            //    });

            //JitExperiments.RunExperiment();

            //TreeStructureExperiments.RunExperiment();

            //Console.WriteLine(Net.Link.Target.ToIndex());

            //Transactions.Run();

            try
            {
                //TerminalExperiment.Run();

                //OperationsExperiments.RunExperiment();
            }
            catch (Exception ex)
            {
            }


            //NewMemoryManagerExperiments.RunExperiment2();

            //NetParserTest.Run();

            Console.WriteLine();

            //Link.StopMemoryManager();

            Console.WriteLine("Total time: {0}", sw.Elapsed);
            Console.WriteLine();

            Console.WriteLine("All jobs done.");
            Console.ReadKey();
        }

        //static void CompressionDifferenceTests()
        //{
        //    string path = Console.ReadLine();
        //    XmlGenerator.ToFile(path);
        //}

        //static void UnusedLinksTest()
        //{
        //    int unusedLinksCounter = 0;

        //    Link.WalkThroughAllLinks((link) =>
        //    {
        //        if (link.ReferersBySourceCount == 0 && link.ReferersByLinkerCount == 0 && link.ReferersByTargetCount == 0)
        //        {
        //            unusedLinksCounter++;

        //            if (link.Linker == Net.And)
        //            {
        //                Console.WriteLine(link);
        //            }
        //        }
        //    });

        //    Console.WriteLine("Unused links found: {0}.", unusedLinksCounter);
        //}

        private static void WrongPointerTest()
        {
            try
            {
                var array = new byte[256];

                fixed (byte* pointer = array)
                {
                    byte value = *(pointer - 259);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private static void Links()
        {
            string filename = (new Random(2)).Next(1, 99999).ToString();

            //if (File.Exists(filename))
            //    File.Delete(filename);

            //ConceptTest.TestGexf(filename);

            if (File.Exists(filename))
                File.Delete(filename);

            Console.ReadKey();
        }
    }
}