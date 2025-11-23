using client.DTOs;
using client.Models;
using client.Services;
using client.Services.Interfaces;
using client.Views;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace client.ViewModels
{
    public class SkillViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly HttpClientService _httpClientService;
        private List<Profession>? skillData;

        public SkillViewModel(INavigationService navigationService, HttpClientService httpClientService)
        {
            _navigationService = navigationService;
            _httpClientService = httpClientService;
        }

        [Reactive] public Guid Id { get; set; }
        [Reactive] public string Name { get; set; }
        [Reactive] public string Description { get; set; }

        [Reactive] public List<SkillDTO> Skills { get; set; }

        private async Task<List<SkillDTO>> GetAllSkills()
        {
            var response = await _httpClientService.HttpClient.GetAsync($"skill");
            if (response.IsSuccessStatusCode)
            {
                var skillsList = await response.Content.ReadFromJsonAsync<List<SkillDTO>>();
                return skillsList ?? new List<SkillDTO>();
            }
            return new List<SkillDTO>();
        }


        private async Task GetSkill()
        {
            var response = await _httpClientService.HttpClient.GetAsync($"{Id}");
            var fileNamesList = await response.Content.ReadFromJsonAsync<SkillDTO>();
            if (fileNamesList != null && response.IsSuccessStatusCode)
            {
                Name = fileNamesList.Name;
                Description = fileNamesList.Description;
            }
        }


        private async Task GetSkillCourses()
        {
            var response = await _httpClientService.HttpClient.GetAsync($"{Id}/courses");
            var fileNamesList = await response.Content.ReadFromJsonAsync<SkillDTO>();
            if (fileNamesList != null && response.IsSuccessStatusCode)
            {
                Skills = new List<SkillDTO>();
            }
        }


        private async Task<List<Profession>> GetSkillProfessions()
        {
            var response = await _httpClientService.HttpClient.GetAsync($"{Id}/professions");
            var fileNamesList = await response.Content.ReadFromJsonAsync<SkillDTO>();
            if (fileNamesList != null && response.IsSuccessStatusCode)
            {
                return fileNamesList.Professions ?? new List<Profession>();
            }
            return new List<Profession>();
        }
    }
}
