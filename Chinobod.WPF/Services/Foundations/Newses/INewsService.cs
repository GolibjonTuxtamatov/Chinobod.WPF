using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinobod.WPF.Models.News;

namespace Chinobod.WPF.Services.Foundations.Newses
{
    public interface INewsService
    {
        ValueTask<News> AddNewsAsync(News news);
        IQueryable<News> RetrieveAllNewses();
        ValueTask<News> RetrieveNewsByIdAsync(Guid id);
        ValueTask<News> ModifyNewsAsync(News news);
        ValueTask<News> RemoveNewsAsync(Guid id);
        ValueTask RemoveNotNeedNewsesAsync();
    }
}
