using client.Services;
using client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI.Fody;
using ReactiveUI.Fody.Helpers;
using client.Views;

namespace client.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly HttpClientService _httpClientService;

        public LoginViewModel(INavigationService navigationService, HttpClientService httpClientService)
        {
            _navigationService = navigationService;
            _httpClientService = httpClientService;
        }

        [Reactive] public string Login { get; set; } = string.Empty;
        [Reactive] public string Password { get; set; } = string.Empty;
        [Reactive] public Guid Id { get; set; }

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
            var response = await _httpClientService.HttpClient.GetAsync($"user/{Id}");
            var fileNamesList = await response.Content.ReadFromJsonAsync<List<Guid>>();
        }
    }
}
