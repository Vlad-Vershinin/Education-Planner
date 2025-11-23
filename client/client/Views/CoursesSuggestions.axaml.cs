using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client.Services;
using client.ViewModels;

namespace client.Views;

public partial class CoursesSuggestions : UserControl
{
    public CoursesSuggestions(UserService userService)
    {
        InitializeComponent();
        DataContext = new CoursesSuggestionsViewModel(userService);
        SuggestionGrid.DoubleTapped += (s, e) =>
        {
            (DataContext as CoursesSuggestionsViewModel).ViewTheCourse_Click.Execute();
        };
    }
}