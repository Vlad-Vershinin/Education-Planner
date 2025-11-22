using System;
using System.Collections.Generic;
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
    }
}
