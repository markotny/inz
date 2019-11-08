import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, ParamMap} from '@angular/router';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {switchMap, map, tap} from 'rxjs/operators';
import {GetAlbumGQL, GetAlbumQuery} from '@gql/types.graphql-gen';
import {Observable} from 'rxjs';

@Component({
	selector: 'app-album',
	templateUrl: './album.component.html',
	styleUrls: ['./album.component.scss'],
	animations: [
		trigger('reviewExpand', [
			state('collapsed', style({height: '0px', minHeight: '0'})),
			state('expanded', style({height: '*'})),
			transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)'))
		])
	]
})
export class AlbumComponent implements OnInit {
	album$: Observable<GetAlbumQuery['album']>;

	reviewsColumns = ['stars', 'user', 'review'];
	expandedReviewId: string;

	constructor(private route: ActivatedRoute, private getAlbum: GetAlbumGQL) {}

	ngOnInit() {
		this.album$ = this.route.paramMap.pipe(
			switchMap((params: ParamMap) => this.getAlbum.watch({id: params.get('id')}).valueChanges),
			map(res => res.data.album)
		);
	}
}
