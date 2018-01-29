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
            string path = @"D:\!scan";

            var files = Directory.GetFiles(path, "*.TIF", SearchOption.AllDirectories);

            var result = new List<FileItem>();

            files.AsParallel().ForAll(s => result.Add(new FileItem(s)));

            //foreach (var file in files)
            //{
            //    result.Add(new FileItem(file));
            //}

            foreach (FileItem item in result)
            {
                item.DEBUG_PrintInformation();
                Console.WriteLine(new string('-', 40));
            }

            // Delay
            Console.ReadKey();
        }
    }
}
