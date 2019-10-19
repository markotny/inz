import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {AuthCallbackComponent} from '@core/authentication/auth-callback/auth-callback.component';
import {AuthAction} from '@core/authentication/auth-callback/auth-action.enum';

const routes: Routes = [
	{path: 'login-callback', component: AuthCallbackComponent, data: {action: AuthAction.Login}},
	{
		path: 'register-callback',
		component: AuthCallbackComponent,
		data: {action: AuthAction.Register}
	},
	{
		path: 'silent-refresh',
		component: AuthCallbackComponent,
		data: {action: AuthAction.SilentRefresh}
	},
	// Fallback when no prior route is matched
	{path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule {}
