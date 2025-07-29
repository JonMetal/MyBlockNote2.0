using System.ComponentModel;
using System.Windows.Controls;
namespace MyBlockNote.Caret
{
    public class ProxyTextBoxCaret : INotifyPropertyChanged
    {
        private int _caretIndexRow = 0;
        private int _caretIndexColumn = 0;
        private int _caretIndex = 0;

        private TextBox? _textBox;
        public ProxyTextBoxCaret() { }

        public int CaretIndexRow
        {
            get { return _caretIndexRow; }
            private set
            {
                _caretIndexRow = value;
                OnPropertyChanged("CaretTextIndexRow");
                OnPropertyChanged("CaretIndexRow");
            }
        }

        public int CaretIndexColumn
        {
            get { return _caretIndexColumn; }
            private set
            {
                _caretIndexColumn = value;
                OnPropertyChanged("CaretTextIndexColumn");
                OnPropertyChanged("CaretIndexColumn");
            }
        }

        public int CaretIndex
        {
            get { return _caretIndex; }
            set
            {
                if (_textBox != null)
                {
                    _caretIndex = value;
                    CaretIndexRow = _textBox.GetLineIndexFromCharacterIndex(CaretIndex);
                    CaretIndexColumn = _caretIndex - _textBox.GetCharacterIndexFromLineIndex(CaretIndexRow);
                }
            }
        }

        public string CaretTextIndexColumn
        {
            get { return $"Столбец {CaretIndexColumn + 1} |"; }
        }

        public string CaretTextIndexRow
        {
            get { return $"Строка {CaretIndexRow + 1} |"; }
        }

        public void LinkTextBox(TextBox textBox)
        {
            _textBox = textBox;
        }

        public void UpdateCaretIndex()
        {
            if (_textBox != null)
            {
                CaretIndex = _textBox.CaretIndex;
            }
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
