export interface YoutubeResponse {
    video: VideoDetails[];
    nextPageToken: string;
    prevPageToken: string;
  }
  
  export interface VideoDetails {
    title: string;
    link: string;
    thumbnail: string;
    publishedAt: Date;
  }
  