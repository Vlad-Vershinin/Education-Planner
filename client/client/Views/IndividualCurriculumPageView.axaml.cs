using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client.ViewModels;

namespace client.Views;

public partial class IndividualCurriculumPageView : UserControl
{
    public IndividualCurriculumPageView()
    {
        InitializeComponent();
        DataContext = new IndividualCurriculumPageViewModel();
        CourseGrid.DoubleTapped += (s, e) =>
        {
            (DataContext as IndividualCurriculumPageViewModel).ViewTheCourse_Click.Execute();
        };
    }

}