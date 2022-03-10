using Microsoft.Win32;
using SubtitleSync.ViewModels.Commands;
using SubtitleSync.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace SubtitleSync.ViewModels
{
    public class MainWindowVM : BaseVM
    {
        private string originPath = "File origin path";
        public string OriginPath
        {
            get => originPath;
            set
            {
                originPath = value;
                OnPropertyChanged(nameof(OriginPath));
            }
        }

        private string destinationPath = "File destination path";
        public string DestinationPath
        {
            get => destinationPath;
            set
            {
                destinationPath = value;
                OnPropertyChanged(nameof(DestinationPath));
            }
        }

        private TimeSpan timeSpan;
        public TimeSpan TimeSpan
        {
            get => timeSpan;
            set
            {
                timeSpan = value;
                OnPropertyChanged(nameof(TimeSpan));
            }
        }

        private KeyValuePair<Encoding, string> selectedEncoding = new KeyValuePair<Encoding, string>(Encoding.UTF8, "UTF8");
        public KeyValuePair<Encoding, string> SelectedEncoding
        {
            get => selectedEncoding;
            set
            {
                selectedEncoding = value;
                OnPropertyChanged(nameof(Encoding));
            }
        }

        public SelectOriginCommand SelectOriginCommand { get; set; }
        public SelectDestinationCommand SelectDestinationCommand { get; set; }
        public OpenPreviewWindowCommand OpenPreviewWindowCommand { get; set; }
        public ExecuteCommand ExecuteCommand { get; set; }

        public static readonly KeyValuePair<Encoding, string>[] comboBoxValues = {
            new KeyValuePair<Encoding, string>(Encoding.UTF8, "UTF8"),
            new KeyValuePair<Encoding, string>(Encoding.ASCII, "ASCII"),
            new KeyValuePair<Encoding, string>(Encoding.Unicode, "Unicode")};

        public KeyValuePair<Encoding, string>[] ComboBoxValues { get; set; }

        public MainWindowVM()
        {
            SelectOriginCommand = new SelectOriginCommand(this);
            SelectDestinationCommand = new SelectDestinationCommand(this);
            OpenPreviewWindowCommand = new OpenPreviewWindowCommand(this);
            ExecuteCommand = new ExecuteCommand(this);
            ComboBoxValues = comboBoxValues;
        }

        public void SelectOriginPath()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Subtitle files (*.srt)|*.srt;";
            if (dialog.ShowDialog() == true)
            {
                OriginPath = dialog.FileName;
            }
        }

        public void SelectDestinationPath()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Subtitle files (*.srt)|*.srt;";
            if (dialog.ShowDialog() == true)
            {
                DestinationPath = dialog.FileName;
            }
        }

        public bool ExecuteValidation()
        {
            if (originPath != "File origin path" && destinationPath != "File destination path")
            {
                return true;
            }
            return false;
        }

        public bool PreviewValidation()
        {
            if (originPath == "File origin path")
            {
                return false;
            }
            return true;
        }

        public async Task CreatePreview()
        {
            var outputPath = Path.GetFullPath(Path.GetTempPath() + @"\temp.srt");
            using (var inputStream = new FileStream(OriginPath, FileMode.Open, FileAccess.Read))
            using (var outputStream = new FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                await Shift(inputStream, outputStream, TimeSpan, SelectedEncoding.Key);
            }

            var previewWindowVM = new PreviewWindowVM()
            {
                Preview = File.ReadAllText(outputPath)
            };

            PreviewWindow previewWindow = new PreviewWindow(previewWindowVM);
            previewWindow.Show();

            File.Delete(outputPath);
        }

        public async Task DoShift()
        {
            try
            {
                using (var inputStream = new FileStream(OriginPath, FileMode.Open, FileAccess.Read))
                using (var outputStream = new FileStream(DestinationPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    await Shift(inputStream, outputStream, TimeSpan, SelectedEncoding.Key);
                    var result = MessageBox.Show("It's done. Do you want to open the file?", "Hey!", MessageBoxButton.YesNo,
                        MessageBoxImage.Question, MessageBoxResult.Yes);

                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            Process.Start(DestinationPath);
                            break;
                        case MessageBoxResult.No:
                            // User pressed No
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static async Task Shift(Stream input, Stream output, TimeSpan timeSpan, Encoding encoding, int bufferSize = 1024, bool leaveOpen = false)
        {
            try
            {
                using (StreamReader sr = new StreamReader(input))
                {
                    using (StreamWriter sw = new StreamWriter(output, encoding, bufferSize, leaveOpen))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string pattern = @"^\s*(\d\d:\d\d:\d{1,2},\d\d\d)\s*-->\s*(\d\d:\d\d:\d{1,2},\d\d\d)\s*$";
                            Match match = Regex.Match(line, pattern);

                            if (match.Success)
                            {
                                string timeSpan1 = TimeSpan.Parse(match.Groups[1].Value).Add(timeSpan).ToString(@"hh\:mm\:ss\.fff");
                                string timeSpan2 = TimeSpan.Parse(match.Groups[2].Value).Add(timeSpan).ToString(@"hh\:mm\:ss\.fff");
                                line = timeSpan1 + " --> " + timeSpan2;
                            }
                            await sw.WriteLineAsync(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
