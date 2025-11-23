using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client.ViewModels;

namespace client.Views;

public partial class ProfessionPreviewView : UserControl
{
    public ProfessionPreviewView()
    {
        InitializeComponent();
        DataContext = new ProfessionPreviewViewModel();
    }
}