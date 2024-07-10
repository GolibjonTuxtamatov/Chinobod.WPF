using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinobod.WPF.Models.News;

namespace Chinobod.WPF.Brokers.APIBroker
{
    internal interface IApiBroker
    {
        ValueTask<News> InsertNewsAsync(News news);
        IQueryable<News> SelectAllNews();
        ValueTask<News> SelectNewsByIdAsync(Guid id);
        ValueTask<News> UpdateNewsAsync(News news);
        ValueTask<News> DeleteNewsAsync(Guid id);
    }
}
