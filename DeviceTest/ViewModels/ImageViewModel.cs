using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace DeviceTest.ViewModels
{
    public class ImageViewModel : ViewmodelBase
    {
        private readonly MainViewModel _mainViewModel;
        private string _currentFolder;
        private string _selectedImage;
        private ObservableCollection<string> _images;

        public string CurrentFolder
        {
            get => _currentFolder;
            set => SetProperty(ref _currentFolder, value);
        }

        public string SelectedImage
        {
            get => _selectedImage;
            set => SetProperty(ref _selectedImage, value);
        }

        public ObservableCollection<string> Images
        {
            get => _images;
            set => SetProperty(ref _images, value);
        }

        public ICommand SelectFolderCommand { get; }
        public ICommand BackCommand { get; }

        public ImageViewModel(MainViewModel main)
        {
            _mainViewModel = main;
            Images = new ObservableCollection<string>();
            SelectFolderCommand = new RelayCommand<object>(_ => SelectFolder());
            BackCommand = new RelayCommand<object>(_ => _mainViewModel.NavigateToHome());
        }

        private void SelectFolder()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Select an image to open folder",
                Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All files|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                CurrentFolder = Path.GetDirectoryName(dialog.FileName);
                if (!string.IsNullOrEmpty(CurrentFolder))
                    LoadImages(CurrentFolder);
            }
        }

        private void LoadImages(string path)
        {
            Images.Clear();
            var extensions = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
            var files = Directory.GetFiles(path)
                                 .Where(f => extensions.Contains(Path.GetExtension(f).ToLower()));

            foreach (var file in files)
            {
                Images.Add(file);
            }
        }
    }
}