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
            string path = @"S:\temp";

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
                foreach (FileItem item in creator.Items)
                {
                    item.DEBUG_PrintInformation();
                }
            }
            
            // Delay
            Console.ReadKey();
        }
    }
}
