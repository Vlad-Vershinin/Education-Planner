using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client.Services;
using client.ViewModels;

namespace client.Views;

public partial class CurriculumView : UserControl
{
    public CurriculumView(UserService userService)
    {
        InitializeComponent();
        DataContext = new CurriculumViewModel(userService);

    }
}