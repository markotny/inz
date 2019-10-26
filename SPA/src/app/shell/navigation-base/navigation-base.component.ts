import {Component, OnInit, OnDestroy} from '@angular/core';
import {AuthService} from '@core/authentication/auth.service';
import {Subscription} from 'rxjs';

@Component({
	selector: 'app-navigation-base',
	template: '',
	styles: []
})
export class NavigationBaseComponent implements OnInit, OnDestroy {
	exploreLinks = [
		{name: 'New', route: '/home'},
		{name: 'Top', route: '/home'},
		{name: 'Weekly', route: '/home'}
	];

	accountLinks = [{name: 'Profile', route: '/home'}, {name: 'Settings', route: '/settings'}];

	userName: string;
	isAuthenticated: boolean;
	subscription: Subscription;

	constructor(protected authService: AuthService) {}

	ngOnInit() {
		this.subscription = this.authService.authNavStatus$.subscribe(status => {
			this.isAuthenticated = status;
			this.userName = this.authService.name;
		});
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
