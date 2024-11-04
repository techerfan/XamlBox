using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Xaml;
using XamlBox.Helper;
using XamlBox.Implementations;

namespace XamlBox.ViewModels
{
    /// <summary>
    /// ViewModel of the Main Window
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Path of the xaml icons directory
        /// </summary>
        public string DirectoryPath { get; set; }

        /// <summary>
        /// Output path of the viewboxes
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// Namespace of the viewbox classes
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Progress bar maximum value
        /// </summary>
        public int ProgressMax { get; set; }

        /// <summary>
        /// Progress bar current value
        /// </summary>
        public int ProgressVal { get; set; }

        /// <summary>
        /// Specifies if the app is currently processing
        /// </summary>
        public bool IsProcessing { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// A command for selecting the input directory path
        /// </summary>
        public RelayCommand SelectDirectoryPathCommand => new RelayCommand(() =>
        {
            var dialog = new OpenFolderDialog();

            if (dialog.ShowDialog() == true)
            {
                DirectoryPath = dialog.FolderName;
            }
        });

        /// <summary>
        /// A command for selecting the output directory path
        /// </summary>
        public RelayCommand SelectOutputPathCommand => new RelayCommand(() =>
        {
            var dialog = new OpenFolderDialog();

            if (dialog.ShowDialog() == true)
            {
                OutputPath = dialog.FolderName;
            }
        });

        /// <summary>
        /// Convert button command
        /// </summary>
        public RelayCommand ConvertCommand => new RelayCommand(() =>
        {
            if (DirectoryPath == null || DirectoryPath.Length == 0)
            {
                MessageBox.Show("You must select a directory path for reading the XAML files.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (OutputPath == null || OutputPath.Length == 0)
            {
                MessageBox.Show("You must select a output path for saving the viewbox classes.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Namespace == null || Namespace.Length == 0)
            {
                var result = MessageBox.Show("You must pick a namespace. It cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Getting the count of files and setting it to the progress bar maximum value
            ProgressMax = Directory.GetFiles(DirectoryPath, "*", SearchOption.AllDirectories).Length;
            // Also progress bar current value must be set to zero since we just started the process
            ProgressVal = 0;
            IsProcessing = true;
            Task.Run(() =>
            {
                CheckDirectory(DirectoryPath);
                IsProcessing = false;
            });
        });

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainViewModel()
        {
            DirectoryPath = "";
            OutputPath = "";
            Namespace = "XamlBox";
        }

        #endregion

        #region Private Helpers

        private void CheckDirectory(string path)
        {
            var filePaths = Directory.GetFiles(path);

            CheckXamlFiles(filePaths);

            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                // Creating the directory in the output path if it does not exist
                var newDirname = directory.Replace(DirectoryPath, OutputPath);
                Directory.CreateDirectory(newDirname);
                CheckDirectory(directory);
            }
        }

        private void CheckXamlFiles(string[] filePaths)
        {
            foreach (var filePath in filePaths)
            {
                ProgressVal++;
                if (Path.GetExtension(filePath) != ".xaml")
                {
                    continue;
                }
                var file = File.ReadAllText(filePath);

                Application.Current.Dispatcher.Invoke(() => {
                    var v = (Viewbox)XamlServices.Parse(file);

                    // New file name must be a valid class name - the MakeValidClassName function makes it valid
                    var newFileName = MakeValidClassName(Path.GetFileNameWithoutExtension(filePath));

                    ViewboxBuilder builder = new ViewboxBuilder(v, newFileName, Namespace);
                    builder.Build();

                    // Source directory must be substituted with the output directory
                    var newFilePath = filePath.Replace(DirectoryPath, OutputPath);
                    newFilePath = newFilePath.Replace(Path.GetFileName(newFilePath), "");

                    using (var f = File.CreateText(Path.Combine(newFilePath, newFileName + ".cs")))
                    {
                        f.Write(builder.ClassString);
                    }
                });

                
            }
        }

        private string MakeValidClassName(string name)
        {
            // Use Regex to remove invalid characters
            string validName = Regex.Replace(name, @"[^a-zA-Z0-9_]", "");

            // Ensure the name starts with a letter or underscore
            if (string.IsNullOrEmpty(validName) || !char.IsLetter(validName[0]) && validName[0] != '_')
            {
                validName = "_" + validName;
            }

            return validName;
        }

        #endregion
    }
}
