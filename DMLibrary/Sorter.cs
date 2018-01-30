using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLibrary
{
    public enum SortOption
    {
        Folder,
        Formats,
        IncludesStandartFormats
    }

    public class Sorter
    {
        // Поля

        private List<FileItem> _items;

        // Свойства

        public bool IsEmpty => _items.Count == 0;

        public List<FileItem> Items
        {
            get => _items;
            set => _items = value;
        }

        public int Count => _items.Count;

        // Конструктор

        public Sorter()
        {
            _items = new List<FileItem>();
        }

        public Sorter(List<FileItem> items)
        {
            if (items.Count == 0)
                throw new ArgumentException("Collection is Empty!");

            _items = items;
        }

        // Методы

        public Dictionary<string, List<FileItem>> SortBy(SortOption option)
        {
            var result = new Dictionary<string, List<FileItem>>();

            foreach (FileItem item in _items)
            {
                string key = "";

                switch (option)
                {
                    case SortOption.Folder:
                        key = item.Folder;
                        break;
                    case SortOption.Formats:
                        key = item.Format;
                        break;
                    case SortOption.IncludesStandartFormats:
                        key = item.IncludeStandartFormat.ToString();
                        break;
                }

                if (result.ContainsKey(key))
                    result[key].Add(item);
                else
                    result.Add(key, new List<FileItem>() {item});
            }

            return result;
        }

        /* TODO: Удалить данный код позже за не надобностью и лишним повторением
        public Dictionary<string, List<FileItem>> SotrByFolder()
        {
            var result = new Dictionary<string, List<FileItem>>();
            foreach (FileItem item in _items)
            {
                var folder = item.Folder;
                if (result.ContainsKey(folder))
                {
                    result[folder].Add(item);
                }
                else
                {
                    result.Add(folder, new List<FileItem>() { item });
                }
            }
            return result;
        }

        public Dictionary<string, List<FileItem>> SortByFormat()
        {
            var result = new Dictionary<string, List<FileItem>>();

            foreach (FileItem item in _items)
            {
                var folder = item.IncludeStandartFormat.ToString();
                if (result.ContainsKey(folder))
                {
                    result[folder].Add(item);
                }
                else
                {
                    result.Add(folder, new List<FileItem>() { item });
                }
            }

            return result;
        }
        */
    }
}
