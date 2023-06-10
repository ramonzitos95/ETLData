using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ETLDados.Models
{
    public class Posts
    {
        
        [JsonPropertyName("userId")]
        public long UserId  {get; set; }

        [Key]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("body")]
        public string? body { get; set; }
 
    }
}