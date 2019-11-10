import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {LastFmClientService} from 'app/services/last-fm-client.service';
import {
	LastFmAlbum,
	getAlbumArtistName,
	getCoverImage,
	CoverImageSize
} from 'app/services/last-fm-api.interfaces';
import {Observable} from 'rxjs';

@Component({
	selector: 'app-album-search',
	templateUrl: './album-search.component.html',
	styleUrls: ['./album-search.component.scss']
})
export class AlbumSearchComponent implements OnInit {
	@Output() albumSelected = new EventEmitter<LastFmAlbum>();

	getAlbumArtistName = getAlbumArtistName;

	searchResults$: Observable<LastFmAlbum[]>;
	constructor(private lastFmClientService: LastFmClientService) {}

	ngOnInit() {}

	searchByAlbumName(query: string) {
		if (!query) {
			return;
		}
		this.searchResults$ = this.lastFmClientService.albumSearch(query);
	}

	searchByArtistName(query: string) {
		if (!query) {
			return;
		}
		this.searchResults$ = this.lastFmClientService.topByArtistSearch(query);
	}

	selectAlbum(album: LastFmAlbum) {
		this.albumSelected.emit(album);
	}

	getSmallImageSrc(album: LastFmAlbum): string {
		return getCoverImage(album.image, CoverImageSize.Small);
	}
}
