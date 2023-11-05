# DotnetAngularYoutube
Dotnet 8 and Angular 16.2.12: A Powerful Duo for YouTube Video Integration

The Mechanism in a Nutshell:
Here’s how it works — Dotnet 8 leverages the YouTube Data API, which provides up to 105 or 106 free requests. By utilizing tokens like ‘prevPageToken’ and ‘nextPageToken,’ you can efficiently paginate through YouTube channel videos.
In Dotnet 8, a simple HTTP GET request to the endpoint GetChannelVideos can fetch a specified number of videos. The API key and the application name are your gateway to the world of YouTube content. The key elements of the code include:
- Creating a YouTubeService instance.
- Creating a request to search for videos.
- Specifying the channel you want to retrieve videos from.
- Setting the order of search results (in this case, by date).
- Defining the maximum number of results to be retrieved.
- Setting the page token to fetch the next page of results (if available).

The results obtained are a treasure trove of video details, including titles, links, thumbnails, and publication dates. These videos can be sorted by date and presented using Angular and Tailwind CSS to offer a seamless and visually pleasing user experience.
