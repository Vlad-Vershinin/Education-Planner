using Avalonia.Controls;
using client.ViewModels;

namespace client.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}