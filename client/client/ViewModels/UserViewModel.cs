using client.DTOs;
using client.Services;
using client.Services.Interfaces;
using client.Views;
using ReactiveUI.Fody;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace client.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly HttpClientService _httpClientService;

        public UserViewModel(INavigationService navigationService, HttpClientService httpClientService)
        {
            _navigationService = navigationService;
            _httpClientService = httpClientService;
        }

        [Reactive] public string Login { get; set; } = string.Empty;
        [Reactive] public string Password { get; set; } = string.Empty;
        [Reactive] public Guid UserId { get; set; }
        [Reactive] public Guid ProfessionId { get; set; }
        [Reactive] public List<CourseExtendedDTO> CoursesTaken { get; set; }
        [Reactive] public ProfessionDTO? ProfessionChosen { get; set; }
        [Reactive] public List<LeveledSkillDTO> SkillsHave { get; set; }
        [Reactive] HttpContent httpContent { get; set; }
        [Reactive] public Guid CourseId { get; set; }


        private async Task TryLogin()
        {
            var response = await _httpClientService.HttpClient.GetAsync($"auth/{Login}/{Password}");
            var fileNamesList = await response.Content.ReadFromJsonAsync<List<string>>();
            if (fileNamesList != null && response.IsSuccessStatusCode)
            {
                _navigationService.NavigateTo<CurriculumPageView>();
            }
        }


        private async Task GetUserId()
        {
            if (UserId == Guid.Empty) return;

            var response = await _httpClientService.HttpClient.GetAsync($"user/{UserId}");
            if (!response.IsSuccessStatusCode) return;

            var userDto = await response.Content.ReadFromJsonAsync<UserDTO?>();
            if (userDto != null)
            {
                UserId = userDto.Id;
            }
        }


        private async Task GetUserCourses()
        {
            var response = await _httpClientService.HttpClient.GetAsync($"{UserId}/courses");
            if (!response.IsSuccessStatusCode) return;
            var userDto = await response.Content.ReadFromJsonAsync<UserDTO?>();
            if (userDto != null)
            {
                CoursesTaken = userDto.CoursesTaken;
            }
        }


        private async Task GetUserProfession()
        {
            var response = await _httpClientService.HttpClient.GetAsync($"{UserId}/profession");
            if (!response.IsSuccessStatusCode) return;
            var userDto = await response.Content.ReadFromJsonAsync<UserDTO?>();
            if (userDto != null)
            {
                ProfessionChosen = userDto.ProfessionChosen;
            }
        }


        private async Task GetUser()
        {
            var response = await _httpClientService.HttpClient.GetAsync($"{UserId}");
            if (!response.IsSuccessStatusCode) return;
            var userDto = await response.Content.ReadFromJsonAsync<UserDTO?>();
            if (userDto != null)
            {
                UserId = userDto.Id;
                Login = userDto.Login;
                CoursesTaken = userDto.CoursesTaken;
                ProfessionChosen = userDto.ProfessionChosen;
                SkillsHave = userDto.SkillsHave;
            }
        }

        private async Task UpdateUserSkills()
        {
            var response = await _httpClientService.HttpClient.PostAsync($"{UserId}/skills", httpContent);
            if (!response.IsSuccessStatusCode) return;
            var userDto = await response.Content.ReadFromJsonAsync<UserDTO?>();
            if (userDto != null)
            {
                SkillsHave = userDto.SkillsHave;
            }
        }


        private async Task UpdateUserCourseProgress()
        {
            var response = await _httpClientService.HttpClient.PostAsync($"{UserId}/courses/{CourseId}", httpContent);
            if (!response.IsSuccessStatusCode) return;
            var userDto = await response.Content.ReadFromJsonAsync<UserDTO?>();
            if (userDto != null)
            {
                SkillsHave = userDto.SkillsHave;
            }
        }


        private async Task UpdateUserProfession()
        {
            var response = await _httpClientService.HttpClient.PostAsync($"{UserId}/profession", httpContent);
            if (!response.IsSuccessStatusCode) return;
            var userDto = await response.Content.ReadFromJsonAsync<UserDTO?>();
            if (userDto != null)
            {
                ProfessionChosen = userDto.ProfessionChosen;
            }
        }
    }
}
