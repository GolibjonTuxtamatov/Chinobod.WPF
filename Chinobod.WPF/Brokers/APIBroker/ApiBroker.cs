using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Chinobod.WPF.Models.News;

namespace Chinobod.WPF.Brokers.APIBroker
{
    internal class ApiBroker : IApiBroker
    {
        private readonly HttpClient clien;

        public ApiBroker()
        {
            this.clien = new HttpClient();
        }

        public ValueTask<News> InsertNewsAsync(News news)
        {
            throw new NotImplementedException();
        }

        public IQueryable<News> SelectAllNews()
        {
            throw new NotImplementedException();
        }

        public ValueTask<News> SelectNewsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<News> UpdateNewsAsync(News news)
        {
            throw new NotImplementedException();
        }

        public ValueTask<News> DeleteNewsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
