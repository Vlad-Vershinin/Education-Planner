using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client.Services;
using client.ViewModels;

namespace client.Views;

public partial class ProfessionPreviewView : UserControl
{
    public ProfessionPreviewView(UserService userService)
    {
        InitializeComponent();
        DataContext = new ProfessionPreviewViewModel(userService);
    }
}