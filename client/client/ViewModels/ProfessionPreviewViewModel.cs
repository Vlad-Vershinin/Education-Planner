using client.Models;
using client.Services;
using client.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace client.ViewModels
{
    public class ProfessionPreviewViewModel : ViewModelBase
    {



        [Reactive] public Profession Profession { get; set; }
        [Reactive] public bool IsViewingProfession { get; set; } = false;
        [Reactive] public CoursesSuggestions CurriculumPage { get; set; }



        public ReactiveCommand<Unit, Unit> GoToPreviousPage_Click { get; set; }
        public ReactiveCommand<Unit, Unit> ShowSuggestedCourses_Click { get; set; }

        public delegate void BackToThePreviousDelegate();
        private BackToThePreviousDelegate _backToThePrevious;

        UserService AppUserService;
        public ProfessionPreviewViewModel(UserService userService)
        {
            AppUserService = userService;
            GoToPreviousPage_Click = ReactiveCommand.CreateFromTask(GoToPreviousPage);
            ShowSuggestedCourses_Click = ReactiveCommand.CreateFromTask(ShowSuggestedCourses);
        }

        public void SetDelegate(BackToThePreviousDelegate backToThePreviousDelegate)
        {
            _backToThePrevious = backToThePreviousDelegate;
        }
        public async Task GoToPreviousPage()
        {
            if (_backToThePrevious != null)
            {
                _backToThePrevious.Invoke();
            }
        }
        public async Task ShowSuggestedCourses()
        {
            CurriculumPage = new CoursesSuggestions(AppUserService);
            (CurriculumPage.DataContext as CoursesSuggestionsViewModel).SetDelegate(ReturnToThisPage);
            (CurriculumPage.DataContext as CoursesSuggestionsViewModel).SuggestedCourses = new List<Course>{
                new Course{Title = "dddd", Description="descr"},
                new Course{Title = "dddd"},
                new Course{Title = "dddd"},
                new Course{Title = "dddd"},
            };
            IsViewingProfession = true;
        }
        public void ReturnToThisPage()
        {
            CurriculumPage = null;
            IsViewingProfession = false;
        }
    }
}
