using MyBlockNote.Files;
using System.Windows;
using System.Windows.Media;

namespace MyBlockNote.WindowsFactory
{
    public interface IWindowFactory
    {
        Window CreateMainWindow(EditorFile editorFile, IWindowFactory windowFactory);
        Window CreateFontSettingWindow(EditorFile editorFile);

        Window CreateThemeSettingWindow(IList<Brush> brushes);

        Window CreateAboutProgramWindow();
    }
}
