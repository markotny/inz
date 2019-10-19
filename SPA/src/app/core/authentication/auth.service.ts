import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '@env/environment';
import {UserManager, UserManagerSettings, User} from 'oidc-client';
import {BaseService} from '@shared/base.service';
import {BehaviorSubject} from 'rxjs';
import {catchError} from 'rxjs/operators';

@Injectable({
	providedIn: 'root'
})
export class AuthService extends BaseService {
	private authApiUri: string;
	// Observable navItem source
	private authNavStatusSource = new BehaviorSubject<boolean>(false);
	// Observable navItem stream
	authNavStatus$ = this.authNavStatusSource.asObservable();

	private manager = new UserManager(getClientSettings());
	private user: User | null;

	constructor(private http: HttpClient) {
		super();

		this.authApiUri = `${environment.authServerUri}/api/account`;
		this.manager.getUser().then(user => {
			this.user = user;
			this.authNavStatusSource.next(this.isAuthenticated());
		});

		this.manager.events.addSilentRenewError(err => console.log('silent renew error', err));
	}

	login() {
		return this.manager.signinRedirect();
	}

	async completeAuthentication() {
		this.user = await this.manager.signinRedirectCallback();
		this.authNavStatusSource.next(this.isAuthenticated());
	}

	async completeSilentRefresh() {
		await this.manager.signinSilentCallback();
	}

	register(userRegistration: any) {
		return this.http.post(this.authApiUri, userRegistration).pipe(catchError(this.handleError));
	}

	isAuthenticated(): boolean {
		return this.user != null && !this.user.expired;
	}

	get authorizationHeaderValue(): string {
		return `${this.user.token_type} ${this.user.access_token}`;
	}

	get name(): string {
		return this.user != null ? this.user.profile.name : '';
	}

	signout() {
		this.manager.signoutRedirect();
	}
}

export function getClientSettings(): UserManagerSettings {
	return {
		authority: environment.authServerUri,
		client_id: 'angular_spa',
		response_type: 'code',
		scope: 'openid profile email api.read',
		filterProtocolClaims: true,
		loadUserInfo: true,
		automaticSilentRenew: true,
		redirect_uri: `${environment.thisUri}/login-callback`,
		post_logout_redirect_uri: `${environment.thisUri}/`,
		silent_redirect_uri: `${environment.thisUri}/silent-refresh`
	};
}
