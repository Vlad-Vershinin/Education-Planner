using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client.ViewModels;

namespace client.Views;

public partial class ProfilePageView : UserControl
{
    public ProfilePageView()
    {
        InitializeComponent();
        DataContext = new ProfilePageViewModel();
        EnrolledCourses_GUI.DoubleTapped += (s,e) => 
        {
            (DataContext as ProfilePageViewModel).ViewTheCourse_Click.Execute();
        };
    }

    
}