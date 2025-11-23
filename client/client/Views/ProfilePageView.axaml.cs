using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client.Services;
using client.ViewModels;

namespace client.Views;

public partial class ProfilePageView : UserControl
{
    public ProfilePageView(UserService AppUserService)
    {
        InitializeComponent();
        DataContext = new ProfilePageViewModel(AppUserService);
        EnrolledCourses_GUI.DoubleTapped += (s,e) => 
        {
            (DataContext as ProfilePageViewModel).ViewTheCourse_Click.Execute();
        };
    }

    
}