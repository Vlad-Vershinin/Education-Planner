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
        CourseGrid.DoubleTapped += (s, e) =>
        {
            (DataContext as CurriculumPageViewModel).ViewTheCourse_Click.Execute();
        };
    }
}