using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using client.ViewModels;

namespace client.Views;

public partial class CoursesSuggestions : UserControl
{
    public CoursesSuggestions()
    {
        InitializeComponent();
        DataContext = new CoursesSuggestionsViewModel();
        SuggestionGrid.DoubleTapped += (s, e) =>
        {
            (DataContext as CoursesSuggestionsViewModel).ViewTheCourse_Click.Execute();
        };
    }
}