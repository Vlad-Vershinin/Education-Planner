using client.Models;
using client.Services;
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
    public class CurriculumViewModel : ViewModelBase
    {
        [Reactive] public Course CourseSelected {  get; set; } = new Course();



        public ReactiveCommand<Unit, Unit> GoToPreviousPage_Click { get; set; }

        public delegate void BackToThePreviousDelegate();
        private BackToThePreviousDelegate _backToThePrevious;



        UserService AppUserService;
        public CurriculumViewModel(UserService userService) 
        {
            AppUserService = userService;
            GoToPreviousPage_Click = ReactiveCommand.CreateFromTask(GoToPreviousPage);
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
