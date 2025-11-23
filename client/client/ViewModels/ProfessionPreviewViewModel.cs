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
    public class ProfessionPreviewViewModel : ViewModelBase
    {

        [Reactive] public CurriculumView Curriculum { get; set; }


        [Reactive] public Profession Profession { get; set; }
        [Reactive] public bool IsViewingProfession { get; set; } = false;


        public ReactiveCommand<Unit, Unit> GoToPreviousPage_Click { get; set; }

        public delegate void BackToThePreviousDelegate();
        private BackToThePreviousDelegate _backToThePrevious;


        public ProfessionPreviewViewModel()
        {
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
