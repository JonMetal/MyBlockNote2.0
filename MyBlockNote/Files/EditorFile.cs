using System.ComponentModel;

namespace MyBlockNote.Files
{
    public abstract class EditorFile : INotifyPropertyChanged
    {
        private protected string _fileName;
        private protected string _contents;
        private protected bool _saved = true;

        private double _fontSize = 12;
        private string _fontFamily = "Arial";

        public EditorFile()
        {
            _fileName = "Nameless";
            _contents = "";
        }

        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        public string Contents
        {
            get { return _contents; }
            set
            {
                _contents = value;
                this._saved = true;
                OnPropertyChanged("Contents");
            }
        }

        public string FontFamily
        {
            get
            {
                return _fontFamily;
            }
            set
            {
                _fontFamily = value;
                OnPropertyChanged("FontFamily");
            }
        }

        public double FontSize
        {
            get
            {
                return _fontSize;
            }
            set
            {
                _fontSize = value;
                OnPropertyChanged("FontSize");
            }
        }
        public abstract bool SaveFile(bool newFile = false);

        public abstract bool WriteFile();

        public abstract bool SaveCheck();

        public abstract bool OpenFile();

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
