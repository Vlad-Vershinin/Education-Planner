using client.DTOs;
using client.Models;
using client.Services;
using client.Services.Interfaces;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace client.ViewModels
{
    public class ProfessionViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly HttpClientService _httpClientService;

        public ProfessionViewModel(INavigationService navigationService, HttpClientService httpClientService)
        {
            _navigationService = navigationService;
            _httpClientService = httpClientService;
        }


        [Reactive] public Guid Id { get; set; }
        [Reactive] public string Name { get; set; }
        [Reactive] public string Description { get; set; }
        [Reactive] public double Relevance { get; set; }
        [Reactive] public List<Skill> Skills { get; set; }
        [Reactive] public List<ProfessionDTO> Professions { get; set; }
        [Reactive] public List<CourseDTO> Courses { get; set; }


        private async Task GetProfessions()
        {
            var response = await _httpClientService.HttpClient.GetAsync($"Profession");
            if (response.IsSuccessStatusCode)
            {
                var professionList = await response.Content.ReadFromJsonAsync<List<ProfessionDTO>>();
                Professions = professionList ?? new List<ProfessionDTO>();
            }
            else
            {
                Professions = new List<ProfessionDTO>();
            }
        }


        private async Task GetProfession()
        {
            var response = await _httpClientService.HttpClient.GetAsync($"Profession/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var profession = await response.Content.ReadFromJsonAsync<ProfessionDTO>();
                if (profession != null)
                {
                    Name = profession.Name;
                    Description = profession.Description;
                    Relevance = profession.Relevance;
                }
            }
        }


        private async Task GetCourses()
        {
            var response = await _httpClientService.HttpClient.GetAsync($"{Id}/courses");
            if (response.IsSuccessStatusCode)
            {
                var coursesList = await response.Content.ReadFromJsonAsync<List<CourseDTO>>();
                Courses = coursesList ?? new List<CourseDTO>();
            }
            else
            {
                Professions = new List<ProfessionDTO>();
            }
        }


        private async Task GetSkills()
        {
            var response = await _httpClientService.HttpClient.GetAsync($"{Id}/skills");
            if (response.IsSuccessStatusCode)
            {
                var skillsList = await response.Content.ReadFromJsonAsync<List<Skill>>();
                Skills = skillsList ?? new List<Skill>();
            }
            else
            {
                Skills = new List<Skill>();
            }
        }
    }
}
