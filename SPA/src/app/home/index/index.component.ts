import {Component, OnInit, OnChanges} from '@angular/core';
import {map, tap} from 'rxjs/operators';

@Component({
	selector: 'app-index',
	templateUrl: './index.component.html',
	styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
	item;
	selId = 1;

	constructor() {}

	ngOnInit() {

	}
}
