using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace FeedzillaReader.Models
{
    [JsonObject]
    public class HttpAnswer
    {
        [JsonProperty("articles")]
        public IEnumerable<Article> Articles { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("syndication_url")]
        public string SyndicationUrl { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        public HttpAnswer() {
            this.Articles = new List<Article>();
        }
    }
}
