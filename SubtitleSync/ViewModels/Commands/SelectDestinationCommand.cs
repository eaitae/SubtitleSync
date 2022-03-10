using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SubtitleSync.ViewModels.Commands
{
    public class SelectDestinationCommand : ICommand
    {
        public MainWindowVM VM { get; set; }
        public SelectDestinationCommand(MainWindowVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.SelectDestinationPath();
        }
    }
}
