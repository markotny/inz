import {Component, OnInit, Input} from '@angular/core';
import {Observable} from 'rxjs';
import {Album} from '@gql/types.graphql-gen';

@Component({
	selector: 'app-album-list',
	templateUrl: './album-list.component.html',
	styleUrls: ['./album-list.component.scss']
})
export class AlbumListComponent implements OnInit {
	@Input() albums: Observable<Partial<Album>[]>;

	constructor() {}

	ngOnInit() {}
}
