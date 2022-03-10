using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SubtitleSync.ViewModels.Commands
{
    public class OpenPreviewWindowCommand : ICommand
    {
        public MainWindowVM VM { get; set; }
        public OpenPreviewWindowCommand(MainWindowVM vm)
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
            return VM.PreviewValidation();
        }

        public async void Execute(object parameter)
        {
            await VM.CreatePreview();
        }
    }
}

