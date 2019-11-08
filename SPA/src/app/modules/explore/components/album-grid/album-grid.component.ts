import {Component, OnInit, Input} from '@angular/core';
import {map} from 'rxjs/operators';
import {Observable} from 'rxjs';
import {Albums} from '../explore.component';

export interface AlbumTile {
	cols: number;
	rows: number;
	id: string;
	title: string;
	artist: string;
	averageRating?: number;
	coverSrc?: string;
}

@Component({
	selector: 'app-album-grid',
	templateUrl: './album-grid.component.html',
	styleUrls: ['./album-grid.component.scss']
})
export class AlbumGridComponent implements OnInit {
	@Input() albums$: Observable<Albums>;
	tiles$: Observable<AlbumTile[]>;

	constructor() {}

	ngOnInit() {
		this.tiles$ = this.albums$.pipe(
			map(albums =>
				albums.map((album, index) => {
					return {
						cols: index === 0 ? 2 : 1,
						rows: index === 0 ? 2 : 1,
						artist: album.albumArtist.name,
						...album
					};
				})
			)
		);
	}
}
