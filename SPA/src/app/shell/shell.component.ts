import {Component, OnInit} from '@angular/core';
import {GetSettingsGQL} from '@gql/types.graphql-gen';
import {Observable} from 'rxjs';
import {map, tap} from 'rxjs/operators';
import {OverlayContainer} from '@angular/cdk/overlay';

@Component({
	selector: 'app-shell',
	templateUrl: './shell.component.html',
	styleUrls: ['./shell.component.scss']
})
export class ShellComponent implements OnInit {
	theme$: Observable<string>;

	constructor(private overlayContainer: OverlayContainer, private getSettings: GetSettingsGQL) {}

	ngOnInit() {
		this.theme$ = this.getSettings.watch().valueChanges.pipe(
			map(res => res.data.settings.theme),
			tap(theme => this.setOverlayContainerTheme(theme))
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
