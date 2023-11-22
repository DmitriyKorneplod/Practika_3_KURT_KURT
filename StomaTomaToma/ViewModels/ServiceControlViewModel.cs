using ReactiveUI;
using StomaTomaToma.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StomaTomaToma.ViewModels
{
    public class ServiceControlViewModel : ViewModelBase
    {
        private Service _selectedService;
        public Service SelectedService
        {
            get => _selectedService;
            set => this.RaiseAndSetIfChanged(ref _selectedService, value);
        }

        private HttpClient client = new HttpClient();
        private ObservableCollection<Service> _services;
        public ObservableCollection<Service> Services
        {
            get => _services;
            set => this.RaiseAndSetIfChanged(ref _services, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public ServiceControlViewModel()
        {
            client.BaseAddress = new Uri("http://localhost:5169");
            Update();
        }

        public async Task Update()
        {
            var response = await client.GetAsync("/services");
            if (!response.IsSuccessStatusCode)
            {
                Message = $"Ошибка сервера {response.StatusCode}";
                return;
            }
            var content = await response.Content.ReadAsStringAsync();
            if (content == null)
            {
                Message = "Пустой ответ от сервера";
                return;
            }
            Services = JsonSerializer.Deserialize<ObservableCollection<Service>>(content);
            Message = "";
        }

        public async Task Delete()
        {
            if (SelectedService == null) return;
            var response = await client.DeleteAsync($"/services/{SelectedService.id}");
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка удаления со стороны сервера";
                return;
            }
            Services.Remove(SelectedService);
            SelectedService = null;
            Message = "";
        }

        public async Task Add()
        {
            var cal = new Service();
            var response = await client.PostAsJsonAsync($"/services", cal);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка добавления со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<Service>();
            if (content == null)
            {
                Message = "При добавлении сервер отправил пустой ответ";
                return;
            }
            cal = content;
            Services.Add(cal);
            SelectedService = cal;
        }

        public async Task Edit()
        {
            var response = await client.PutAsJsonAsync($"/services", SelectedService);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка изменения со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<Service>();
            if (content == null)
            {
                Message = "При изменении сервер отправил пустой ответ";
                return;
            }
            SelectedService = content;
        }
    }

}
