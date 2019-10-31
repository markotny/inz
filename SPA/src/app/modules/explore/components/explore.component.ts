import {Component, OnInit} from '@angular/core';
import { Album } from '@gql/types.graphql-gen';

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
	albums: Album[];

	constructor() {}

	ngOnInit() {
		this.selectedView = ViewMode.grid;
	}
}
