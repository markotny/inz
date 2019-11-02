import {Component, OnInit, Input} from '@angular/core';
import {Observable} from 'rxjs';
import {Album} from '@gql/types.graphql-gen';

@Component({
	selector: 'app-album-detailed',
	templateUrl: './album-detailed.component.html',
	styleUrls: ['./album-detailed.component.scss']
})
export class AlbumDetailedComponent implements OnInit {
	@Input() albums: Observable<Partial<Album>[]>;

	constructor() {}

	ngOnInit() {}
}
