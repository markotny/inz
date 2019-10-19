import {Component, OnInit} from '@angular/core';
import {Router, ActivatedRoute} from '@angular/router';
import {AuthService} from '../auth.service';
import {AuthAction} from './auth-action.enum';

@Component({
	selector: 'app-auth-callback',
	templateUrl: './auth-callback.component.html',
	styleUrls: ['./auth-callback.component.scss']
})
export class AuthCallbackComponent implements OnInit {
	error: boolean; // TODO: check for error in callback?

	constructor(
		private authService: AuthService,
		private router: Router,
		private route: ActivatedRoute
	) {}

	async ngOnInit() {
		this.route.data.subscribe(async data => {
			switch (data.action) {
				case AuthAction.Login:
					await this.authService.completeAuthentication();
					this.router.navigate(['/home']);
					break;
				case AuthAction.Register:
					this.authService.login();
					break;
				case AuthAction.SilentRefresh:
					await this.authService.completeSilentRefresh();
					break;
			}
		});
	}
}
