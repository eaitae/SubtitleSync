using SubtitleSync.ViewModels;
using System.Windows;

namespace SubtitleSync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowVM mainWindowVM;
        public MainWindow()
        {
            mainWindowVM = new MainWindowVM();
            DataContext = mainWindowVM;
            InitializeComponent();
        }
    }
}
