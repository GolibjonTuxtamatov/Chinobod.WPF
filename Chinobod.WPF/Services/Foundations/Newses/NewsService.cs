using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinobod.WPF.Brokers.APIBroker;
using Chinobod.WPF.Models.News;

namespace Chinobod.WPF.Services.Foundations.Newses
{
    public class NewsService : INewsService
    {
        private readonly IApiBroker apiBroker;

        public NewsService(IApiBroker apiBroker) =>
            this.apiBroker = apiBroker;

        public async ValueTask<News> AddNewsAsync(News news) =>
            await this.apiBroker.InsertNewsAsync(news);

        public IQueryable<News> RetrieveAllNewses() =>
            this.apiBroker.SelectAllNews();

        public async ValueTask<News> RetrieveNewsByIdAsync(Guid id) =>
            await this.apiBroker.SelectNewsByIdAsync(id);

        public async ValueTask<News> ModifyNewsAsync(News news) =>
            await this.apiBroker.UpdateNewsAsync(news);

        public async ValueTask<News> RemoveNewsAsync(Guid id) =>
            await this.apiBroker.DeleteNewsAsync(id);

        public async ValueTask RemoveNotNeedNewsesAsync() =>
            await this.apiBroker.DeleteNotNeedNewsesAsync();
    }
}
