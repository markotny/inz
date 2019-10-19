import {Component, OnInit, OnDestroy} from '@angular/core';
import {AuthService} from '@core/authentication/auth.service';
import {Subscription} from 'rxjs';

@Component({
	selector: 'app-header',
	templateUrl: './header.component.html',
	styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy {
	name: string;
	isAuthenticated: boolean;
	subscription: Subscription;

	constructor(private authService: AuthService) {}

	ngOnInit() {
		this.subscription = this.authService.authNavStatus$.subscribe(
			status => (this.isAuthenticated = status)
		);
		this.name = this.authService.name;
	}

	register() {
		this.authService.register();
	}

	login() {
		this.authService.login();
	}

	signout() {
		this.authService.signout();
	}

	ngOnDestroy() {
		this.subscription.unsubscribe();
	}
}
