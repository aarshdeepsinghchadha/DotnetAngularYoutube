using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using YoutubeDevApiDotnet.Models;

namespace YoutubeDevApiDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        private readonly IOptions<YoutubeApiSettings> _appSettings;

        public YoutubeController(IOptions<YoutubeApiSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        [HttpGet]
        public async Task<IActionResult> GetChannelVideos(string? pageToken = null, int maxResults = 50)
        {
            // Create a YouTubeService instance with API key and application name
            var youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = _appSettings.Value.ApiKey,
                ApplicationName = "MyYoutubeAPI"
            });

            // Create a request to search for videos based on the "snippet" type
            var searchRequest = youtubeService.Search.List("snippet");

            // Set the channel ID you want to retrieve videos from
            searchRequest.ChannelId =_appSettings.Value.ChannelId;

            // Specify the order of the search results (in this case, by date)
            searchRequest.Order = SearchResource.ListRequest.OrderEnum.Date;

            // Set the maximum number of results to be retrieved (default is 50)
            searchRequest.MaxResults = maxResults;

            // Set the page token to fetch the next page of results (if available)
            searchRequest.PageToken = pageToken;

            // Execute the search request and await the response
            var searchResponse = await searchRequest.ExecuteAsync();

            // Extract video details from the search response
            var videoList = searchResponse.Items.Select(item => new VideoDetails
            {
                Title = item.Snippet.Title,
                Link = $"https://www.youtube.com/watch?v={item.Id.VideoId}",
                Thumbnail = item.Snippet.Thumbnails.Medium.Url,
                PublishedAt = item.Snippet.PublishedAtDateTimeOffset
            })
            .OrderByDescending(video => video.PublishedAt)
            .ToList();

            // Create a response object to return the video details along with page tokens
            var response = new YoutubeResponse
            {
                Video = videoList,
                NextPageToken = searchResponse.NextPageToken,
                PrevPageToken = searchResponse.PrevPageToken,
            };

            // Return an HTTP OK response with the serialized response object
            return Ok(response);
        }
    }

}
