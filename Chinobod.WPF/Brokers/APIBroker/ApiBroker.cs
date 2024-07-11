using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Chinobod.WPF.Models.API;
using Chinobod.WPF.Models.News;
using Newtonsoft.Json;

namespace Chinobod.WPF.Brokers.APIBroker
{
    internal class ApiBroker : IApiBroker
    {
        private HttpClient client;

        public ApiBroker()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(API.BASEURL);
        }

        public async ValueTask<News> InsertNewsAsync(News news)
        {
            string newsJson = JsonConvert.SerializeObject(news);

            var content =
                new StringContent(newsJson, Encoding.UTF8, "application/json");

            var responce =
                await this.client.PostAsync("News",content);

            var responceContent = await responce.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<News>(responceContent);
        }

        public IQueryable<News> SelectAllNews()
        {
            string responce =
                this.client.GetStringAsync("News").Result;

            return JsonConvert.DeserializeObject<List<News>>(responce).AsQueryable();
        }

        public async ValueTask<News> SelectNewsByIdAsync(Guid id)
        {
            var responce =
                await this.client.GetStringAsync($"News/{id}");

            return JsonConvert.DeserializeObject<News>(responce);
        }

        public async ValueTask<News> UpdateNewsAsync(News news)
        {
            string newsJson = JsonConvert.SerializeObject(news);

            var content =
                new StringContent(newsJson, Encoding.UTF8, "application/json");

            var responce =
                await this.client.PutAsync("News", content);

            var responceContent = await responce.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<News>(responceContent);
        }

        public async ValueTask<News> DeleteNewsAsync(Guid id)
        {
            var responce =
                await this.client.DeleteAsync($"News/{id}");

            var responceContent = await responce.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<News>(responceContent);
        }
    }
}
