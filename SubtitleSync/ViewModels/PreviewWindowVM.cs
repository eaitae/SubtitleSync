namespace SubtitleSync.ViewModels
{
    public class PreviewWindowVM : BaseVM
    {
        private string preview;
        public string Preview
        {
            get => preview;
            set
            {
                preview = value;
                OnPropertyChanged("Preview");
            }
        }
    }
}
