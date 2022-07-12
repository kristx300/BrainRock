using System.ComponentModel;
using System.Runtime.CompilerServices;
using BrainRock.App.Modules.Api;
using BrainRock.App.Modules.Image;
using BrainRock.App.Modules.Lorem;
using BrainRock.App.Properties;
using Microsoft.Toolkit.Mvvm.Input;

namespace BrainRock.App.Modules.Main
{
    public class MainViewModel : IMainViewModel
    {
        public MainViewModel()
        {
            ShowApiCommand = new RelayCommand(ShowApi);
            ShowImagesCommand = new RelayCommand(ShowImages);
            ShowLoremCommand = new RelayCommand(ShowLorem);
        }

        public IRelayCommand ShowApiCommand { get; }
        public IRelayCommand ShowImagesCommand { get; }
        public IRelayCommand ShowLoremCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Dispose()
        {
        }

        private void ShowApi()
        {
            var window = BootStrap.Resolve<ApiWindow>();
            window.Owner = BootStrap.RootWindow;
            window.Show();
        }

        private void ShowImages()
        {
            var window = BootStrap.Resolve<ImageWindow>();
            window.Owner = BootStrap.RootWindow;
            window.Show();
        }

        private void ShowLorem()
        {
            var window = BootStrap.Resolve<LoremWindow>();
            window.Owner = BootStrap.RootWindow;
            window.Show();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}