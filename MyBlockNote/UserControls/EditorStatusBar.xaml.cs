using MyBlockNote.Caret;
using MyBlockNote.ThemeColors;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyBlockNote.UserControls
{
    /// <summary>
    /// Логика взаимодействия для EditorStatusBar.xaml
    /// </summary>
    public partial class EditorStatusBar : UserControl
    {
        private ProxyTextBoxCaret _caret;
        private IList<Control> _controlsBackground = [];
        private IList<Control> _controlsForeground = [];
        private readonly IThemeColorProvider _themeColorProvider = new ThemeColorProvider();
        public EditorStatusBar()
        {
            InitializeComponent();
            _caret = new ProxyTextBoxCaret();
            this.DataContext = _caret;
        }

        public void LinkTextBox(TextBox textBox)
        {
            _caret.LinkTextBox(textBox);
        }

        public void UpdateCaretIndex()
        {
            _caret.UpdateCaretIndex();
        }

        private void Label_Initialized(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                _controlsForeground.Add(control);
            }
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                _controlsBackground.Add(control);
            }
        }

        public void UpdateThemeColors()
        {
            string brushesJson = _themeColorProvider.GetBrushesJson();
            List<Brush> brushes = JsonConvert.DeserializeObject<List<Brush>>(brushesJson) ?? [];
            ArgumentNullException.ThrowIfNull(brushes);
            foreach (Control control in _controlsBackground)
            {
                control.Background = brushes[0];
            }
            foreach (Control control in _controlsForeground)
            {
                control.Foreground = brushes[1];
            }
        }
    }
}
