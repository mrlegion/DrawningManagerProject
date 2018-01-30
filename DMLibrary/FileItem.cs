using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLibrary
{
    public class FileItem
    {
        // Поля

        // Свойства

        /// <summary>
        /// Полный путь до файла изображения
        /// </summary>
        public string FullPath { get; private set; }

        /// <summary>
        /// Имя файла с его расширением
        /// </summary>
        public string FileNameWithExtantion { get; private set; }

        /// <summary>
        /// Имя файла без расширения
        /// </summary>
        public string FileNameWithoutExtantion { get; private set; }

        /// <summary>
        /// Расширение файла
        /// </summary>
        public string FileExtantion { get; private set; }

        /// <summary>
        /// Получение общего количества стандарных форматов а4 типа
        /// </summary>
        public int IncludeStandartFormat { get; private set; }

        /// <summary>
        /// Размеры изобранения [ ширина, высота, площадь ]
        /// </summary>
        public int[] Size { get; private set; }

        /// <summary>
        /// Наименование формата, к которому относится файл
        /// </summary>
        public string Format { get; private set; }

        /// <summary>
        /// Наименование папки, в которой находится файл
        /// </summary>
        public string Folder { get; private set; }

        // Конструкторы
        public FileItem(string pathToFile)
        {
            // Проверка на существование файла
            if (!File.Exists(pathToFile))
                throw new FileNotFoundException();

            FullPath = pathToFile;
            FileNameWithExtantion = Path.GetFileName(FullPath);
            FileNameWithoutExtantion = Path.GetFileNameWithoutExtension(FullPath);
            FileExtantion = Path.GetExtension(FullPath);
            Folder = Path.GetDirectoryName(FullPath);
            Size = GetImageSize();
            IncludeStandartFormat = GetNumberIncludesStandartFormats();
        }

        // Методы
         
        // Получение словаря с размерами файла (ширина, высота, площадь)
        private int[] GetImageSize()
        {
            // Получение информации из изображения
            Bitmap image = new Bitmap(FullPath);

            var width = (image.Width / image.HorizontalResolution) * 25.4;
            var height = (image.Height / image.VerticalResolution) * 25.4;
            var area = width * height;

            // Освобождаем память, так как объек image больше не требуется
            image.Dispose();

            // Если истина, то вертикальный
            // Если ложь, то горизонтальный
            bool orientation = width < height;

            // Проверка к какому формату принадлежит данное изображение
            foreach (var format in Helper.Formats)
            {
                // Проверяем есть ли данный формат по площади в данных
                if (area > format.Value[3] && area < format.Value[4])
                {
                    // Проверяем ориентацию изображения и делаем ее вертикальной
                    if (!orientation)
                    {
                        var temp = width;
                        width = height;
                        height = temp;
                    }
                    
                    var widthInRange = (width > (format.Value[0] - Helper.Range)) && (width < (format.Value[0] + Helper.Range));
                    var heightInRange = (height > (format.Value[1] - Helper.Range)) && (height < (format.Value[1] + Helper.Range));
                    
                    // Проверка на дублирующий размер площади у форматов
                    if (widthInRange && heightInRange)
                    {
                        Format = format.Key;
                        return new[] { format.Value[0], format.Value[1], format.Value[2] };
                    }
                }
            }

            width = Math.Floor(width);
            height = Math.Floor(height);
            Format = $"{width}x{height}_{(orientation ? "vertical" : "horizontal")}";

            return new[] { (int)(width), (int)height, (int)(width * height) };
        }

        private int GetNumberIncludesStandartFormats()
        {
            double result = Size[2] / Helper.StandartArea;
            return (int)((result % 1 > 0.1) ? Math.Ceiling(result) : Math.Floor(result));
        }

        public void DEBUG_PrintInformation()
        {
            Console.WriteLine("Information about file:");
            Console.WriteLine($"Full Path: {FullPath}");
            Console.WriteLine($"File Name: {FileNameWithExtantion}");
            Console.WriteLine($"Size info:");
            Console.WriteLine($"\tformat name: {Format}");
            Console.WriteLine($"\twidth:  {Size[0]}");
            Console.WriteLine($"\theight: {Size[1]}");
            Console.WriteLine($"\tarea:   {Size[2]}");
        }
    }
}
