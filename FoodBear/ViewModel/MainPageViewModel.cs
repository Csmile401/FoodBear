using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace FoodBear
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ICommand _takePhotoCommand;
        private ICommand _deleteCommand;
        private ObservableCollection<PhotoItem> _photoItems;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand TakePhotoCommand => _takePhotoCommand ??= new Command(async () => await TakePhotoAsync());
        public ICommand DeleteCommand => _deleteCommand ??= new Command<PhotoItem>(DeletePhotoItem);

        public ObservableCollection<PhotoItem> PhotoItems
        {
            get => _photoItems;
            set
            {
                if (_photoItems != value)
                {
                    _photoItems = value;
                    OnPropertyChanged(nameof(PhotoItems));
                }
            }
        }

        public MainPageViewModel()
        {
            PhotoItems = new ObservableCollection<PhotoItem>();
        }

        private async Task TakePhotoAsync()
        {
            if (MediaPicker.IsCaptureSupported)
            {
                var photo = await MediaPicker.PickPhotoAsync();

                if (photo != null)
                {
                    string localFilePath = FileSystem.CacheDirectory + "/" + photo.FileName;

                    using var sourceStream = await photo.OpenReadAsync();
                    using var localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);

                    var newItem = new PhotoItem
                    {
                        PhotoPath = localFilePath,
                        Name = string.Empty,
                        Introduce = string.Empty,
                        Price = 0.0
                    };

                    PhotoItems.Add(newItem);
                }
            }
        }

        private void DeletePhotoItem(PhotoItem photoItem)
        {
            PhotoItems.Remove(photoItem);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PhotoItem
    {
        public string PhotoPath { get; set; }
        public string Name { get; set; }
        public string Introduce { get; set; }
        public double Price { get; set; }
    }
}
