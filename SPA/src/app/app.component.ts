import {Component, OnInit} from '@angular/core';
import {GetSettingsGQL, Settings} from '@gql/types.graphql-gen';
import {Observable} from 'rxjs';
import {map, tap, share, pluck} from 'rxjs/operators';
import {OverlayContainer} from '@angular/cdk/overlay';
import {SettingsService} from './modules/settings/settings.service';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
	title = 'SPA';

	settings$: Observable<Settings>;

	constructor(
		private overlayContainer: OverlayContainer,
		private settingsService: SettingsService,
		private getSettings: GetSettingsGQL
	) {}

	ngOnInit() {
		this.settingsService.loadFromLocalStorage().subscribe();

		this.settings$ = this.getSettings.watch().valueChanges.pipe(
			map(res => res.data.settings),
			tap(settings => this.setOverlayContainerTheme(settings.theme)),
			share()
		);
	}

	private setOverlayContainerTheme(newTheme: string) {
		const classList = this.overlayContainer.getContainerElement().classList;
		const themeClassesToRemove = Array.from(classList).filter((item: string) =>
			item.includes('-theme')
		);
		if (themeClassesToRemove.length) {
			classList.remove(...themeClassesToRemove);
		}
		classList.add(newTheme);
	}
}
