using System.Windows.Media;

namespace MyBlockNote.ThemeColors
{
    public static class BaseThemeColors
    {
        public static Color GetBaseBackground()
        {
            return Color.FromRgb(255, 255, 255);
        }

        public static Color GetBaseForeground()
        {
            return Color.FromRgb(0, 0, 0);
        }

        public static Color GetBaseSelectionBrush()
        {
            return Color.FromRgb(0, 120, 215);
        }

        public static IList<Color> GetBaseColorsList()
        {
            return [GetBaseBackground(), GetBaseForeground(), GetBaseSelectionBrush()];
        }
        public static IList<Color> GetBlackColorsList()
        {
            return [Color.FromRgb(26, 26, 26), Color.FromRgb(255, 255, 255), GetBaseSelectionBrush()];
        }
    }
}
