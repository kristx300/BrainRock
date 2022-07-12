using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using BrainRock.App.Properties;
using BrainRock.Lib.Source;
using Microsoft.Toolkit.Mvvm.Input;

namespace BrainRock.App.Modules.Image
{
    public interface IImageViewModel : IViewModel
    {
    }

    public class ImageViewModel : IImageViewModel
    {
        private readonly IImageService _imageService;
        private readonly IReadOnlyCollection<ISource> _sources;

        public ImageViewModel(IImageService apiService)
        {
            _imageService = apiService;
            ExecuteCommand = new AsyncRelayCommand(Execute);

            _sources = _imageService.GetAllSources();
            foreach (var source in _sources) ApiNames.Add(source.ToString());
            ResponseImage.CacheOption = BitmapCacheOption.OnLoad;
        }

        public ObservableCollection<string> ApiNames { get; set; } = new ObservableCollection<string>();
        public string SelectedApi { get; set; }
        public string Response { get; set; }
        public BitmapImage ResponseImage { get; set; } = new BitmapImage();
        public IAsyncRelayCommand ExecuteCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void Dispose()
        {
        }

        public async Task Execute()
        {
            var source = _sources.FirstOrDefault(f =>
                f.ToString().Equals(SelectedApi, StringComparison.CurrentCultureIgnoreCase));
            if (source != null)
            {
                var executeResult = await source.Execute();
                var binaryData = Convert.FromBase64String(executeResult);

                ResponseImage = new BitmapImage();
                ResponseImage.BeginInit();
                ResponseImage.StreamSource = new MemoryStream(binaryData);
                ResponseImage.EndInit();

                Response = executeResult;
                OnPropertyChanged(nameof(Response));
                OnPropertyChanged(nameof(ResponseImage));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}