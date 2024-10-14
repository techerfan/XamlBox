using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xaml;
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
                var result = MessageBox.Show("Selecting a namespace is optional. You can leave it blank if you do not need a custom namespace.", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            List<string> tags = new List<string>();
            CheckDirectory(DirectoryPath, tags);


            MessageBox.Show($"{String.Join("\n", tags.ToArray())}");
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
            Namespace = "";
        }

        #endregion

        #region Private Helpers

        private void CheckDirectory(string path, List<string> uniqueTags)
        {
            var filePaths = Directory.GetFiles(path);

            CheckXamlFiles(filePaths, uniqueTags);

            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                CheckDirectory(directory, uniqueTags);
            }
        }

        private void CheckXamlFiles(string[] filePaths, List<string> uniqueTags)
        {
            foreach (var filePath in filePaths)
            {
                if (Path.GetExtension(filePath) != ".xaml")
                {
                    continue;
                }
                var file = File.ReadAllText(filePath);

                var v = (Viewbox)XamlServices.Parse(file);

                CheckChildren((v.Child as Canvas).Children, uniqueTags);
            }
        }

        private void CheckChildren(UIElementCollection colls, List<string> uniqueTags)
        {
            foreach (var child in colls)
            {
                if (child is Canvas c)
                {
                    CheckChildren(c.Children, uniqueTags);
                }

                if (!uniqueTags.Contains(child.GetType().ToString()))
                {
                    uniqueTags.Add(child.GetType().ToString());
                }
            }
        }

        #endregion
    }
}
