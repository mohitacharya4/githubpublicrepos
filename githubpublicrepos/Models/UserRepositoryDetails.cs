using System.Text.Json.Serialization;

namespace githubpublicrepos.Models
{
    public class UserRepositoryDetails
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string URL { get; set; }
        
        [JsonPropertyName("size")]
        public ulong Size { get; set; }
        
        [JsonPropertyName("language")]
        public string Language { get; set; }
        
        [JsonPropertyName("watchers_count")]
        public uint WatchersCount { get; set; }
        
        [JsonPropertyName("stargazers_count")]
        public uint StarsCount { get; set; }
    }
}