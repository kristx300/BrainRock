using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using BrainRock.App.Properties;
using BrainRock.Lib.Source;
using Microsoft.Toolkit.Mvvm.Input;

namespace BrainRock.App.Modules.Lorem
{
    public interface ILoremViewModel : IViewModel
    {
    }

    public class LoremViewModel : ILoremViewModel
    {
        private readonly ILoremService _loremService;
        private readonly IReadOnlyCollection<ISource> _sources;

        public LoremViewModel(ILoremService apiService)
        {
            _loremService = apiService;
            ExecuteCommand = new AsyncRelayCommand(Execute);
            CopyCommand = new RelayCommand(Copy);

            _sources = _loremService.GetAllSources();
            foreach (var source in _sources) ApiNames.Add(source.ToString());
        }

        public ObservableCollection<string> ApiNames { get; set; } = new ObservableCollection<string>();
        public string SelectedApi { get; set; }
        public string Response { get; set; }
        public IAsyncRelayCommand ExecuteCommand { get; }
        public IRelayCommand CopyCommand { get; }
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
                Response = executeResult;
                OnPropertyChanged(nameof(Response));
            }
        }

        public void Copy()
        {
            Clipboard.SetText(Response);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}