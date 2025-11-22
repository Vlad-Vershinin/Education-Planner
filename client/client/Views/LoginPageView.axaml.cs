using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client.ViewModels;

namespace client.Views;

public partial class LoginPageView : UserControl
{
    public LoginPageView()
    {
        InitializeComponent();
        DataContext = new LoginPageViewModel();
    }
}