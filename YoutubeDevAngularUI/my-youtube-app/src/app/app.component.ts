import { Component } from '@angular/core';
import { VideoDetails } from 'src/youtube-response.model';
import { YoutubeService } from './youtube.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  videos: VideoDetails[] = [];
  prevPageToken: string = '';
  nextPageToken: string = '';

  constructor(private youtubeService: YoutubeService){}

  ngOnInit(){
    this.loadVideos();
  }

  loadVideos(pageToken: string | undefined = '')
  {
    this.youtubeService.getChannelVideos(pageToken, 12).subscribe(response => {
      this.videos = response.video;
      this.prevPageToken = response.prevPageToken;
      this.nextPageToken = response.nextPageToken;
    })
  }
}
