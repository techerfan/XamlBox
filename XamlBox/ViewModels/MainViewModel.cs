using Microsoft.Win32;
using System.Windows;
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
        });

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainViewModel()
        {

        }

        #endregion
    }
}
