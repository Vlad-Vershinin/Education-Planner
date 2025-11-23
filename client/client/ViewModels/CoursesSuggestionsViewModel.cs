using client.Models;
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
    public class CoursesSuggestionsViewModel : ViewModelBase
    {
        [Reactive] public List<Course> SuggestedCourses { get; set; }
        [Reactive] public CurriculumView Curriculum { get; set; }
        [Reactive] public bool IsViewingCourse { get; set; }

        [Reactive] public int SelectedCourseID { get; set; }



        public ReactiveCommand<Unit, Unit> ViewTheCourse_Click { get; set; }


        public ReactiveCommand<Unit, Unit> GoToPreviousPage_Click { get; set; }

        public delegate void BackToThePreviousDelegate();
        private BackToThePreviousDelegate _backToThePrevious;


        public CoursesSuggestionsViewModel()
        {
            GoToPreviousPage_Click = ReactiveCommand.CreateFromTask(GoToPreviousPage);
            SuggestedCourses = new List<Course> { 
                new Course{Title = "dddd", Description="descr"},
            };
            ViewTheCourse_Click = ReactiveCommand.CreateFromTask(ViewTheCourse);

        }
        public async Task ViewTheCourse()
        {
            Curriculum = new CurriculumView();
            (Curriculum.DataContext as CurriculumViewModel).CourseSelected = SuggestedCourses[SelectedCourseID];
            (Curriculum.DataContext as CurriculumViewModel).SetDelegate(BackToSuggestions);
            IsViewingCourse = true;
        }
        public void BackToSuggestions()
        {
            IsViewingCourse = false;
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

    }
}
