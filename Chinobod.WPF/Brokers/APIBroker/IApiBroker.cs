using Chinobod.WPF.Models.News;

namespace Chinobod.WPF.Brokers.APIBroker
{
    public interface IApiBroker
    {
        ValueTask<News> InsertNewsAsync(News news);
        IQueryable<News> SelectAllNews();
        ValueTask<News> SelectNewsByIdAsync(Guid id);
        ValueTask<News> UpdateNewsAsync(News news);
        ValueTask<News> DeleteNewsAsync(Guid id);
    }
}
