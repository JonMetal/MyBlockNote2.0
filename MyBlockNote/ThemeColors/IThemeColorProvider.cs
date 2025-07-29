using System.Windows.Media;

namespace MyBlockNote.ThemeColors
{
    internal interface IThemeColorProvider
    {
        string GetBrushesJson();
        void WriteBrushesJson(IEnumerable<Color> brushes);
    }
}