using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinobod.WPF.Models.News
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool ShouldDelete { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
