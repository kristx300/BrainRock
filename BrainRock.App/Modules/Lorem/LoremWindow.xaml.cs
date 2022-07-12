using System.Windows;

namespace BrainRock.App.Modules.Lorem
{
    /// <summary>
    ///     Логика взаимодействия для LoremWindow.xaml
    /// </summary>
    public partial class LoremWindow : Window
    {
        public LoremWindow(ILoremViewModel context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}