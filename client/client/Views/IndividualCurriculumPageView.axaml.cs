using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client.Services;
using client.ViewModels;

namespace client.Views;

public partial class IndividualCurriculumPageView : UserControl
{
    public IndividualCurriculumPageView(UserService appUserService)
    {
        InitializeComponent();
        DataContext = new IndividualCurriculumPageViewModel(appUserService);
        CourseGrid.DoubleTapped += (s, e) =>
        {
            (DataContext as IndividualCurriculumPageViewModel).ViewTheCourse_Click.Execute();
        };
    }

}