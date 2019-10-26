import {Injectable} from '@angular/core';
import {GetSettingsGQL, UpdateSettingsGQL, Settings} from '@gql/types.graphql-gen';
import {of} from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class SettingsService {
	private storageKey = 'APP-SETTINGS';

	constructor(private getSettings: GetSettingsGQL, private updateSettings: UpdateSettingsGQL) {}

	loadFromLocalStorage() {
		const settings = JSON.parse(localStorage.getItem(this.storageKey));
		return this.updateSettings.mutate({settings});
	}

	saveToLocalStorage(settings: Settings) {
		localStorage.setItem(this.storageKey, JSON.stringify(settings));
	}
}
