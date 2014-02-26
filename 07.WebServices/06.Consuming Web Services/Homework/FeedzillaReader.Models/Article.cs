namespace FeedzillaReader.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    [JsonObject]
    public class Article
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("publish_date")]
        public DateTime PublishDate { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

    }
}
