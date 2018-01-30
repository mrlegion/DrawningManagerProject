using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMLibrary;

namespace DMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"S:\";

            Creator creator = null;

            Searcher searcher = new Searcher(path);

            searcher.SearchFiles();

            if (searcher.IsSearchComplite)
            {
                creator = new Creator(searcher.Files);
                creator.Calculated();
            }

            if (creator != null && creator.IsCreateCollection)
            {
                var sorter = new Sorter(creator.Items);
                var folder = sorter.SotrByFolder();

                foreach (var f in folder)
                {
                    Console.WriteLine($"Folder Name: {f.Key}");
                    Console.WriteLine($"Include file: {f.Value.Count}");
                    Console.WriteLine("List includes files:");
                    foreach (FileItem item in f.Value)
                    {
                        Console.WriteLine("\t" + item.FullPath);
                    }
                }
            }



            // Delay
            Console.ReadKey();
        }
    }
}
