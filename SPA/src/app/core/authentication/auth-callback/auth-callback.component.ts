import {Component, OnInit} from '@angular/core';
import {Router, ActivatedRoute} from '@angular/router';
import {AuthService} from '../auth.service';

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
		this.route.url.subscribe(async url => {
			if (url[0].path === 'silent-refresh') {
				await this.authService.completeSilentRefresh();
			} else {
				await this.authService.completeAuthentication();
				this.router.navigate(['/home']);
			}
		});
	}
}
