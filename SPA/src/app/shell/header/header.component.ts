import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {AuthService} from '@core/authentication/auth.service';
import {environment} from '@env/environment';
import {NavigationBase} from '@shell/navigation-base/navigation-base';

@Component({
	selector: 'app-header',
	templateUrl: './header.component.html',
	styleUrls: ['./header.component.scss']
})
export class HeaderComponent extends NavigationBase implements OnInit {
	@Output() sidenavToggle = new EventEmitter();

	appName: string;

	constructor(protected authService: AuthService) {
		super(authService);
	}

	ngOnInit() {
		super.ngOnInit();
		this.appName = environment.appName;
	}

	onToggleSidenav() {
		this.sidenavToggle.emit();
	}
}
