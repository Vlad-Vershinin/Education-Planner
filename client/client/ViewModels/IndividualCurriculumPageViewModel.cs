using client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.ViewModels
{
    public class IndividualCurriculumPageViewModel : ViewModelBase
    {
        public ObservableCollection<Course> Values { get; set; }
        public string SearchProfession { set; get; } = "";


    }
}
