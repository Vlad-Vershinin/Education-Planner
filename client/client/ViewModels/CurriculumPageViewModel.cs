using client.Models;
using client.Models.Enum;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.ViewModels
{
    public class CurriculumPageViewModel : ViewModelBase
    {
        public string BTN_FilterName { get { return "Фильтр"; } }
        public string TXT { get; set; } = "Курсы";
        public string BTN_Search { get; set; } = "Поиск";

        public string SearchText { get; set; } = string.Empty;

        public ObservableCollection<Curriculum> Values { get; set;} 
        public CurriculumPageViewModel() 
        { 
            Values = new ObservableCollection<Curriculum> {

            new Curriculum{Title = "Титле", CurriculumImportance = CurriculumImportance.NECESSARY},
            new Curriculum{Title = "Титле", CurriculumImportance = CurriculumImportance.IMPORTANT},
            new Curriculum{Title = "Титле", CurriculumImportance = CurriculumImportance.CIRCUMSTANTIAL},
            new Curriculum{Title = "Титле", CurriculumImportance = CurriculumImportance.NOT_IMPORTANT}
            };
        }

    }
}
