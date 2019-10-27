import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {AuthService} from '@core/authentication/auth.service';
import {NavigationBase} from '@shell/navigation-base/navigation-base';

@Component({
	selector: 'app-sidenav',
	templateUrl: './sidenav.component.html',
	styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent extends NavigationBase implements OnInit {
	@Output() sidenavClose = new EventEmitter();

	constructor(protected authService: AuthService) {
		super(authService);
	}

	ngOnInit() {
		super.ngOnInit();
	}

	onSidenavClose() {
		this.sidenavClose.emit();
	}
}
