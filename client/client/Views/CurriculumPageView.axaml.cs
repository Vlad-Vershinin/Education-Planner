using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client.Services;
using client.ViewModels;

namespace client.Views;

public partial class CurriculumPageView : UserControl
{
    public CurriculumPageView(UserService appUserService)
    {
        InitializeComponent();
        DataContext = new CurriculumPageViewModel(appUserService);
        CourseGrid.DoubleTapped += (s, e) =>
        {
            (DataContext as CurriculumPageViewModel).ViewTheCourse_Click.Execute();
        };
    }
}