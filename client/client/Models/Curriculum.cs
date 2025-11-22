using client.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Models
{
    public class Curriculum
    {
        public delegate void OpenTheCurriculumDelegate(int Id);
        private OpenTheCurriculumDelegate _openTheCurriculum { get; set; }

        public int Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CurriculumImportance CurriculumImportance { get; set; }
        public float CompletionPercentage { get; set; }

        public void SetOpenTheCurriculumDelegate(OpenTheCurriculumDelegate openTheCurriculumDelegate) { _openTheCurriculum = openTheCurriculumDelegate; }
        public Task InvokeOpenTheCurriculumDelegate() { _openTheCurriculum.Invoke(Id); return null; }

    }
}
