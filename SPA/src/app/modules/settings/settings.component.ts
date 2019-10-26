import {Component, OnInit} from '@angular/core';
import {Settings, GetSettingsGQL, SetThemeGQL} from '@gql/types.graphql-gen';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';

@Component({
	selector: 'app-settings',
	templateUrl: './settings.component.html',
	styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {
	settings$: Observable<Settings>;

	themes = [{value: 'light-theme', label: 'light'}, {value: 'dark-theme', label: 'dark'}];
	constructor(private getSettings: GetSettingsGQL, private setTheme: SetThemeGQL) {}

	ngOnInit() {
		this.settings$ = this.getSettings.watch().valueChanges.pipe(
			map(res => res.data.settings)
		);
	}

	onThemeSelect({value: theme}) {
		this.setTheme.mutate({theme}).subscribe();
	}
}
