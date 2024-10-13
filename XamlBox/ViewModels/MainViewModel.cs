using XamlBox.Implementations;

namespace XamlBox.ViewModels
{
    /// <summary>
    /// ViewModel of the Main Window
    /// </summary>
    public class MainViewModel
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

        });

        /// <summary>
        /// A command for selecting the output directory path
        /// </summary>
        public RelayCommand SelectOutputPathCommand => new RelayCommand(() =>
        {

        });

        /// <summary>
        /// Convert button command
        /// </summary>
        public RelayCommand ConvertCommand => new RelayCommand(() =>
        {

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
