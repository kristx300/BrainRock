using System.Windows;

namespace BrainRock.App.Modules.Image
{
    /// <summary>
    ///     Логика взаимодействия для ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        public ImageWindow(IImageViewModel context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}