import {OnInit} from '@angular/core';
import {AuthService} from '@core/authentication/auth.service';
import {Observable} from 'rxjs';
import {tap, share} from 'rxjs/operators';

export class NavigationBase implements OnInit {
	exploreLinks = [
		{name: 'New', route: '/home'},
		{name: 'Top', route: '/explore'},
		{name: 'Genres', route: '/home'}
	];

	accountLinks = [{name: 'Profile', route: '/home'}, {name: 'Settings', route: '/settings'}];

	userName: string;
	isAuthenticated$: Observable<boolean>;

	constructor(protected authService: AuthService) {}

	ngOnInit() {
		this.isAuthenticated$ = this.authService.authNavStatus$.pipe(
			tap(status => {
				if (status) {
					this.userName = this.authService.name;
				} else {
					this.userName = 'anonymous';
				}
			}),
			share()
		);
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
}
