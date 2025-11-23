using client.Models;
using client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace client.ViewModels
{
    public class FilterViewModel : ViewModelBase
    {
        private readonly HttpClientService _http;

        public ObservableCollection<SelectedFilterViewModel<Guid>> Skills { get; } = new();
        public ObservableCollection<SelectedFilterViewModel<int>> Professions { get; } = new();

        public bool IsOpen { get; set; }

        public FilterViewModel(HttpClientService http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _ = LoadSkillsAndProfessionsAsync();
        }

        private async Task LoadSkillsAndProfessionsAsync()
        {
            var skills = await _http.HttpClient.GetFromJsonAsync<List<Skill>>("skill");
            Skills.Clear();
            if (skills != null)
            {
                foreach (var skill in skills)
                {
                    Skills.Add(new SelectedFilterViewModel<Guid>
                    {
                        Id = skill.Id,
                        Name = skill.Name,
                        IsSelected = false
                    });
                }
            }

            var professions = await _http.HttpClient.GetFromJsonAsync<List<Profession>>("profession");
            Professions.Clear();
            if (professions != null)
            {
                foreach (var profession in professions)
                {
                    Professions.Add(new SelectedFilterViewModel<int>
                    {
                        Id = profession.Id,
                        Name = profession.Name,
                        IsSelected = false
                    });
                }
            }
        }

        // Возвращает набор выбранных id для навыков и профессий
        public IEnumerable<Guid> SelectedSkillIds() => Skills.Where(s => s.IsSelected).Select(s => s.Id);
        public IEnumerable<int> SelectedProfessionIds() => Professions.Where(p => p.IsSelected).Select(p => p.Id);

        public void Clear()
        {
            foreach (var s in Skills) s.IsSelected = false;
            foreach (var p in Professions) p.IsSelected = false;
            IsOpen = false;
        }
    }
}
