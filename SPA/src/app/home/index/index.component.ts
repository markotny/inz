import {Component, OnInit, OnChanges} from '@angular/core';
import {SelectedToDoItemGQL, ToDoItem} from '@gql/types.graphql-gen';
import {map, tap} from 'rxjs/operators';

@Component({
	selector: 'app-index',
	templateUrl: './index.component.html',
	styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
	item;
	selId = 1;

	constructor(private getToDo: SelectedToDoItemGQL) {}

	ngOnInit() {
		this.item = this.getToDo.watch({id: this.selId}).valueChanges.pipe(
			tap(res => console.log(res)),
			map(res => res.data.toDoItem)
		);
	}
}
