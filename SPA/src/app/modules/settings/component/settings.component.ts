import {Component, OnInit} from '@angular/core';
import {Settings, GetSettingsGQL, UpdateSettingsGQL} from '@gql/types.graphql-gen';
import {Observable} from 'rxjs';
import {map, tap} from 'rxjs/operators';
import {SettingsService} from '../settings.service';

@Component({
	selector: 'app-settings',
	templateUrl: './settings.component.html',
	styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {
	settings$: Observable<Settings>;

	themes = [{value: 'light-theme', label: 'light'}, {value: 'dark-theme', label: 'dark'}];
	constructor(
		private settingsService: SettingsService,
		private getSettings: GetSettingsGQL,
		private updateSettings: UpdateSettingsGQL
	) {}

	ngOnInit() {
		this.settings$ = this.getSettings.watch().valueChanges.pipe(
			map(res => res.data.settings),
			tap(settings => this.settingsService.saveToLocalStorage(settings))
		);
	}

	onThemeSelect({value: theme}) {
		this.updateSettings.mutate({settings: {theme}}).subscribe();
	}
	onStickyHeaderToggle({checked: stickyHeader}) {
		this.updateSettings.mutate({settings: {stickyHeader}}).subscribe();
	}
}
