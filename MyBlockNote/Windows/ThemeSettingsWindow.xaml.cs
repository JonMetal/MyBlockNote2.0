using MyBlockNote.ThemeColors;
using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace MyBlockNote.Windows
{
    /// <summary>
    /// Логика взаимодействия для ThemeSettingsWindow.xaml
    /// </summary>
    public partial class ThemeSettingsWindow : Window
    {
        private IList<Color> _colors = [];
        private IList<ColorPicker> _colorsPickers = [];
        private IThemeColorProvider _themeColorProvider = new ThemeColorProvider();
        public ThemeSettingsWindow(IList<Brush> brushes)
        {
            foreach (Brush brush in brushes)
            {
                _colors.Add(((SolidColorBrush)brush).Color);
            }
            InitializeComponent();
            InitializeColorPickers();
        }

        private void InitializeColorPickers()
        {
            if (_colorsPickers.Count != _colors.Count)
            {
                throw new Exception("Несовпадение количества ColorPickers и кистей");
            }
            for (int i = 0; i < _colors.Count; i++)
            {
                _colorsPickers[i].SelectedColor = _colors[i];
            }

        }
        private void InitializeColorPickerAdd(object sender, EventArgs e)
        {
            _colorsPickers.Add((ColorPicker)sender);
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            _themeColorProvider.WriteBrushesJson(_colors);
            this.DialogResult = true;
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            _colors = BaseThemeColors.GetBaseColorsList();
            InitializeColorPickers();
        }

        private void ColorPickerBackground_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (ColorPickerBackground.SelectedColor is Color color)
            {
                _colors[0] = color;
            }
        }

        private void ColorPickerFont_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (ColorPickerFont.SelectedColor is Color color)
            {
                _colors[1] = color;
            }
        }

        private void ColorPickerSelector_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (ColorPickerSelector.SelectedColor is Color color)
            {
                _colors[2] = color;
            }
        }
    }
}
