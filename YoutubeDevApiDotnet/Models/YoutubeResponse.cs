﻿namespace YoutubeDevApiDotnet.Models
{
    public class YoutubeResponse
    {
        public List<VideoDetails> Video { get; set; } = new List<VideoDetails>();
        public string? NextPageToken { get; set; } 
        public string? PrevPageToken { get; set; } 
    }
}
