import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { YoutubeResponse } from 'src/youtube-response.model';

@Injectable({
  providedIn: 'root'
})
export class YoutubeService {
  private apiUrl = "https://localhost:44377/api/Youtube";

  constructor(private http: HttpClient) { }

  getChannelVideos(pageToken: string, maxResults: number): Observable<YoutubeResponse> {
    const url = `${this.apiUrl}?pageToken=${pageToken}&maxResults=${maxResults}`;
    return this.http.get<YoutubeResponse>(url);
  }
}
