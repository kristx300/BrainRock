using System.Windows;

namespace BrainRock.App.Modules.Api
{
    /// <summary>
    ///     Логика взаимодействия для ApiWindow.xaml
    /// </summary>
    public partial class ApiWindow : Window
    {
        public ApiWindow(IApiViewModel context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}