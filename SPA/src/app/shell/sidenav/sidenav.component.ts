import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {AuthService} from '@core/authentication/auth.service';
import {NavigationBaseComponent} from '@shell/navigation-base/navigation-base.component';

@Component({
	selector: 'app-sidenav',
	templateUrl: './sidenav.component.html',
	styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent extends NavigationBaseComponent implements OnInit {
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
