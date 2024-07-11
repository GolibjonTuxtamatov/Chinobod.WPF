using System.Text.Json;
using Newtonsoft.Json;

namespace Chinobod.WPF.Models.News
{
    public class News
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("tile")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("shouldDelete")]
        public bool ShouldDelete { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
