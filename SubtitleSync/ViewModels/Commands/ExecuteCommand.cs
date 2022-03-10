using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SubtitleSync.ViewModels.Commands
{
    public class ExecuteCommand : ICommand 
    {
        public MainWindowVM VM { get; set; }
        public ExecuteCommand(MainWindowVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return VM.ExecuteValidation();
        }

        public async void Execute(object parameter)
        {
           await VM.DoShift();
        }
    }
}
