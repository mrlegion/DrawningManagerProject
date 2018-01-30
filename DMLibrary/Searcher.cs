using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DMLibrary
{
    public struct Searcher
    {
        // Поля
        private string _folder;
        private string[] _files;

        // Свойства
        public string Folder
        {
            get { return _folder; }
            set
            {
                if (!Directory.Exists(value))
                    throw new DirectoryNotFoundException();

                _folder = value;
                IsSearchComplite = false;
            }
        }

        public string[] Files
        {
            get => _files ?? new string[0];
        }

        public bool IsSearchComplite { get; private set; }

        public int Count => _files?.Length ?? 0;

        // Конструктор
        public Searcher(string folder)
        {
            if (!Directory.Exists(folder))
                throw new DirectoryNotFoundException();

            _folder = folder;
            IsSearchComplite = false;
            _files = null;
        }

        // TODO: Сделать на будущее проверку и отправку предупреждения пользователю, что поиск уже сделан и если хочет, то повторить его
        public void SearchFiles()
        {
            if (!IsSearchComplite)
            {
                _files = Directory.GetFiles(_folder, "*.TIF", SearchOption.AllDirectories);
                IsSearchComplite = true;
            }
        }

        public void Reset()
        {
            IsSearchComplite = false;
            _files = null;
        }

        public List<string> ToList()
        {
            return _files.ToList(); ;
        }
    }
}
