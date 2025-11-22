using client.Services;
using client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

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

        private async Task Login()
        {
            var response = await _httpClientService.HttpClient.GetAsync($"id/{Login}/{Password}");
            var fileNamesList = await response.Content.ReadFromJsonAsync<List<string>>();
            if (fileNamesList != null && response.IsSuccessStatusCode)
            {
                _navigationService.NavigateTo<CurriculumPageViewModel>();
            }
        }
    }
}
