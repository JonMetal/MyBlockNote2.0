using Newtonsoft.Json;
using System.IO;
using System.Windows.Media;

namespace MyBlockNote.ThemeColors
{
    internal class ThemeColorProvider : IThemeColorProvider
    {
        private readonly string _brushesPath = @"brushes.json";
        public void WriteBrushesJson(IEnumerable<Color> brushes)
        {
            string brushesJson = JsonConvert.SerializeObject(brushes);
            File.WriteAllText(_brushesPath, brushesJson);
        }

        public string GetBrushesJson()
        {
            if (!File.Exists(_brushesPath)) { WriteBrushesJson(BaseThemeColors.GetBaseColorsList()); }
            return File.ReadAllText(_brushesPath);
        }
    }
}
