using Avalonia.Controls;
using client.Services;
using client.ViewModels;

namespace client.Views;

public partial class MainView : UserControl
{
    
    public MainView(UserService userService)
    {
        InitializeComponent();
        DataContext = new MainViewModel(userService);
    }
}