using SubtitleSync.ViewModels;
using System.Windows;

namespace SubtitleSync.Views
{

    public partial class PreviewWindow : Window
    {
        public PreviewWindow(PreviewWindowVM previewWindowVM)
        {
            DataContext = previewWindowVM;
            InitializeComponent();

            Owner = Application.Current.MainWindow;
        }
    }
}
