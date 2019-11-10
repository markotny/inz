import {Component, OnInit, Input} from '@angular/core';
import {Album} from '@gql/types.graphql-gen';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';

@Component({
	selector: 'app-album-card-wide',
	templateUrl: './album-card-wide.component.html',
	styleUrls: ['./album-card-wide.component.scss']
})
export class AlbumCardWideComponent implements OnInit {
	@Input() album$: Observable<Album>;

	constructor() {}

	ngOnInit() {
	}
}
