using DeviceTest.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows.Input;


namespace DeviceTest.ViewModels
{
    public class ItemsViewModel
    {

        private readonly MainViewModel _main;
        private int _page = 1;
        private const int PageSize = 10;

        public ObservableCollection<Item> Items { get; } = new();

        public ICommand NextPageCommand { get; }
        public ICommand PrevPageCommand { get; }

        public ItemsViewModel(MainViewModel main)
        {
            _main = main;

            NextPageCommand = new RelayCommand<string>(async _ =>
            {
                _page++;
                await LoadPage();
            });

            PrevPageCommand = new RelayCommand<string>(async _ =>
            {
                if (_page > 1)
                {
                    _page--;
                    await LoadPage();
                }
            });

            LoadPage();
        }

        private async Task LoadPage()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", JwtStore.Token);

            var data = await client.GetFromJsonAsync<List<Item>>(
                $"https://api.example.com/items?page={_page}&size={PageSize}");

            Items.Clear();
            foreach (var item in data)
                Items.Add(item);
        }
    }
}
