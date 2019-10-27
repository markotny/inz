import {Component, OnInit} from '@angular/core';

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

	constructor() {}

	ngOnInit() {
		this.selectedView = ViewMode.list;
	}
}
