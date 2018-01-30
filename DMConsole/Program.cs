using System;
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
                var folder = sorter.SortBy(SortOption.Formats);

                /* Sort by folder
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
                */

                foreach (var f in folder)
                {
                    Console.WriteLine($"Format name: {f.Key}");
                    Console.WriteLine($"Include file: {f.Value.Count}");
                    Console.WriteLine("List includes files:");
                    
                    Sorter folderSorter = new Sorter(f.Value);

                    foreach (var f1 in folderSorter.SortBy(SortOption.Folder))
                    {
                        Console.WriteLine($"\tFolder Name: {f1.Key}");
                        Console.WriteLine($"\tInclude file: {f1.Value.Count}");
                        Console.WriteLine("\tList includes files:");
                        foreach (FileItem item in f1.Value)
                        {
                            Console.WriteLine("\t\t" + item.FullPath);
                        }
                    }
                }
            }



            // Delay
            Console.ReadKey();
        }
    }
}
