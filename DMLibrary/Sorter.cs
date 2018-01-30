using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLibrary
{
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
    }
}
