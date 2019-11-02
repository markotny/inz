import {Component, OnInit} from '@angular/core';
import {GetAlbumsGQL, GetAlbumsQuery} from '@gql/types.graphql-gen';
import {Observable} from 'rxjs';
import {map, tap} from 'rxjs/operators';

export type Albums = GetAlbumsQuery['albums'];

export enum ViewMode {
	grid,
	list,
	detailed
}

@Component({
	selector: 'app-explore',
	templateUrl: './explore.component.html',
	styleUrls: ['./explore.component.scss']
})
export class ExploreComponent implements OnInit {
	viewMode = ViewMode;
	selectedView: ViewMode;
	albums$: Observable<Albums>;

	constructor(private getAlbums: GetAlbumsGQL) {}

	ngOnInit() {
		this.selectedView = ViewMode.grid;
		this.albums$ = this.getAlbums.watch().valueChanges.pipe(
			map(res => res.data.albums),
			tap(albums => console.log('received albums', albums))
		);
	}
}
