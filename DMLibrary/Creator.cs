using System;
using System.Collections.Generic;
using System.Linq;

namespace DMLibrary
{
    public class Creator
    {
        // Поля

        private List<FileItem> _items = new List<FileItem>();
        private string[] _source;

        // Своства
        
        public List<FileItem> Items => _items;

        public bool IsCreateCollection { get; private set; } = false;

        public string[] Source
        {
            get => _source ?? new string[0];
            set
            {
                _source = value ?? throw new ArgumentNullException(nameof(value), "New value can not be Null!");
                IsCreateCollection = false;
            }
        }

        // Конструкторы

        public Creator(string[] list)
        {
            if (list.Length == 0)
            {
                throw new ArgumentException("Array is Empty!");
            }

            _source = list;
        }

        public Creator(ICollection<string> list)
        {
            if (list is List<string> items)
            {
                _source = items.ToArray();
            }
            else
            {
                throw new ArgumentException("This collection is not support! Please check input data!");
            }
        }

        // Методы

        public void Clear()
        {
            IsCreateCollection = false;
            _items = new List<FileItem>();
            _source = null;
        }

        public void Calculated()
        {
            _source.AsParallel().ForAll(s => _items.Add(new FileItem(s)));
            IsCreateCollection = true;
        }
    }
}
