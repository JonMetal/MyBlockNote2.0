using MyBlockNote.Files;
using MyBlockNote.WindowsFactory;
using System.Windows;

namespace MyBlockNote
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private EditorFile _file = new TxtFile();
        private IWindowFactory _windowsFactory = new WindowFactory();
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            Window mw = _windowsFactory.CreateMainWindow(_file, _windowsFactory);
            mw.Show();
        }

        private void ApplicationExit(object sender, EventArgs e) { }
    }

}
