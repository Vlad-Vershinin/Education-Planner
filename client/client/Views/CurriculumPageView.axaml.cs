using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client.ViewModels;

namespace client.Views;

public partial class CurriculumPageView : UserControl
{
    public CurriculumPageView()
    {
        InitializeComponent();
        DataContext = new CurriculumPageViewModel();
    }
}