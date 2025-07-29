using MyBlockNote.Files;
using MyBlockNote.ThemeColors;
using MyBlockNote.WindowsFactory;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyBlockNote.Windows
{
    public partial class MainWindow : Window
    {
        public event Action? ThemeChanged;
        public event Action? CaretChanged;

        private EditorFile _editorFile;
        private readonly IWindowFactory _mainWindowsFactory;
        private readonly IThemeColorProvider _themeColorProvider = new ThemeColorProvider();

        private IList<Brush> _brushes = [];
        private readonly IList<Control> _controlsBackground = [];
        private readonly IList<Control> _controlsForeground = [];
        public MainWindow(EditorFile file, IWindowFactory windowFactory)
        {
            InitializeComponent();
            _mainWindowsFactory = windowFactory;
            _editorFile = file;
            this.DataContext = _editorFile;
            MainEditorStatusBar.LinkTextBox(MainTextBox);
            ThemeChanged += UpdateThemeSettings;
            ThemeChanged += MainEditorStatusBar.UpdateThemeColors;
            CaretChanged += MainEditorStatusBar.UpdateCaretIndex;
            ThemeChanged?.Invoke();
        }

        private void NewMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (_editorFile.SaveCheck())
            {
                _editorFile = new TxtFile();
                this.DataContext = _editorFile;
            }
        }

        private void UpdateThemeSettings()
        {
            string brushesJson = _themeColorProvider.GetBrushesJson();
            _brushes = JsonConvert.DeserializeObject<List<Brush>>(brushesJson) ?? [];
            foreach (Control control in _controlsBackground)
            {
                control.Background = _brushes[0];
            }
            foreach (Control control in _controlsForeground)
            {
                control.Foreground = _brushes[1];
            }
            MainTextBox.SelectionBrush = _brushes[2];
        }
        private void ThemeSettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {

            Window _tSMIWindow = _mainWindowsFactory.CreateThemeSettingWindow(_brushes);
            if (_tSMIWindow.ShowDialog() == true)
            {
                ThemeChanged?.Invoke();
            }
        }

        private void ThemeWhiteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            IList<Color> colors = BaseThemeColors.GetBaseColorsList();
            _themeColorProvider.WriteBrushesJson(colors);
            ThemeChanged?.Invoke();
            var memory = 0.0;
            using (Process proc = Process.GetCurrentProcess())
            {
                memory = proc.PrivateMemorySize64 / (1024 * 1024);
            }
            Console.WriteLine(memory);
        }

        private void ThemeBlackMenuItem_Click(object sender, RoutedEventArgs e)
        {
            IList<Color> colors = BaseThemeColors.GetBlackColorsList();
            _themeColorProvider.WriteBrushesJson(colors);
            ThemeChanged?.Invoke();
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            _editorFile.OpenFile();
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            _editorFile.SaveFile(true);
        }

        private void MenuItemSaveAs_Click(object sender, RoutedEventArgs e)
        {
            _editorFile.SaveFile();
        }

        private void MenuItemFontSettings_Click(object sender, RoutedEventArgs e)
        {
            Window fs = _mainWindowsFactory.CreateFontSettingWindow(_editorFile);
            fs.Show();
        }

        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CaretChanged?.Invoke();
        }

        private void MainTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            CaretChanged?.Invoke();
        }
        private void MainTextBox_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            CaretChanged?.Invoke();
        }

        private void MenuItemInfo_Click(object sender, RoutedEventArgs e)
        {
            Window aboutProgramWindow = _mainWindowsFactory.CreateAboutProgramWindow();
            aboutProgramWindow.Show();
        }

        private void Control_Initialized(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                _controlsBackground.Add(control);
                _controlsForeground.Add(control);
            }
        }
    }
}