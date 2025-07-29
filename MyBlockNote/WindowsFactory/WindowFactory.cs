using MyBlockNote.Files;
using MyBlockNote.Windows;
using System.Windows;
using System.Windows.Media;

namespace MyBlockNote.WindowsFactory
{
    internal class WindowFactory : IWindowFactory
    {
        public WindowFactory() { }

        public Window CreateMainWindow(EditorFile editorFile, IWindowFactory windowFactory)
        {
            return new MainWindow(editorFile, windowFactory);
        }
        public Window CreateAboutProgramWindow()
        {
            return new AboutProgramWindow();
        }

        public Window CreateFontSettingWindow(EditorFile editorFile)
        {
            return new FontSettingsWindow(editorFile);
        }

        public Window CreateThemeSettingWindow(IList<Brush> brushes)
        {
            return new ThemeSettingsWindow(brushes);
        }
    }
}
