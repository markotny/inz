import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Subject, Observable} from 'rxjs';
import {map, tap} from 'rxjs/operators';
import {
	LastFmAlbum,
	LastFmApiMethod,
	LastFmApiQueryResults,
	getAlbumArtistName,
	LastFmAlbumDetailed
} from './last-fm-api.interfaces';

@Injectable({
	providedIn: 'root'
})
export class LastFmClientService {
	constructor(private http: HttpClient) {}
	private readonly apiKey = '429be699091cc3dc5f645fa545b24fdf';
	private readonly baseAddress = 'https://ws.audioscrobbler.com/2.0/';
	private apiParams = new HttpParams({
		fromObject: {
			api_key: this.apiKey,
			format: 'json',
			limit: '30'
		}
	});

	private searchResultsSource = new Subject();
	searchResults$ = this.searchResultsSource.asObservable();

	albumSearch(query: string): Observable<LastFmAlbum[]> {
		return this.http
			.get<LastFmApiQueryResults>(this.baseAddress, {
				params: this.apiParams.set('method', LastFmApiMethod.AlbumSearch).set('album', query)
			})
			.pipe(
				map(res => res.results.albummatches.album),
				tap(album => console.log('received albums', album))
			);
	}

	topByArtistSearch(query: string): Observable<LastFmAlbum[]> {
		return this.http
			.get<LastFmApiQueryResults>(this.baseAddress, {
				params: this.apiParams
					.set('method', LastFmApiMethod.TopByArtist)
					.set('artist', query)
					.set('autocorrect', '1')
			})
			.pipe(
				map(res => res.topalbums.album),
				tap(album => console.log('received albums', album))
			);
	}

	albumInfo(query: LastFmAlbum): Observable<LastFmAlbumDetailed> {
		return this.http
			.get<LastFmApiQueryResults>(this.baseAddress, {
				params: this.apiParams
					.set('method', LastFmApiMethod.AlbumInfo)
					.set('mbid', query.mbid)
					.set('artist', getAlbumArtistName(query))
					.set('album', query.name)
					.set('autocorrect', '1')
			})
			.pipe(
				map(res => res.album),
				tap(album => console.log('received detailed album', album))
			);
	}
}
