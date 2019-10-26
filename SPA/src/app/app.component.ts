import {Component, OnInit} from '@angular/core';
import {MediaObserver} from '@angular/flex-layout';
import {OverlayContainer} from '@angular/cdk/overlay';
import {GetSettingsGQL, Settings} from '@gql/types.graphql-gen';
import {Observable} from 'rxjs';
import {map, tap, share, pluck, filter, max, mergeAll, take} from 'rxjs/operators';
import {SettingsService} from './modules/settings/settings.service';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
	title = 'SPA';

	sizeBreakpoint$: Observable<string>;
	settings$: Observable<Settings>;

	constructor(
		private mediaObserver: MediaObserver,
		private overlayContainer: OverlayContainer,
		private settingsService: SettingsService,
		private getSettings: GetSettingsGQL
	) {}

	ngOnInit() {
		this.settingsService.loadFromLocalStorage().subscribe();

		this.sizeBreakpoint$ = this.mediaObserver.asObservable().pipe(
			mergeAll(),
			take(5),
			filter(size => size.matches),
			max((a, b) => (a.priority > b.priority ? 1 : -1)),
			pluck('mqAlias'),
			share()
		);

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
