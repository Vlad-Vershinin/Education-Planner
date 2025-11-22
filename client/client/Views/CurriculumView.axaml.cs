using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client.ViewModels;

namespace client.Views;

public partial class CurriculumView : UserControl
{
    public CurriculumView()
    {
        InitializeComponent();
        DataContext = new CurriculumViewModel();
    }
}