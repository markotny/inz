import {NgModule} from '@angular/core';
import {Routes, RouterModule, PreloadAllModules} from '@angular/router';
import {AuthCallbackComponent} from '@core/authentication/auth-callback/auth-callback.component';
import {AuthAction} from '@core/authentication/auth-callback/auth-action.enum';

const routes: Routes = [
	{
		path: '',
		redirectTo: 'home',
		pathMatch: 'full'
	},
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
	{
		path: 'home',
		loadChildren: () => import('./home/home.module').then(m => m.HomeModule)
	},
	{
		path: 'settings',
		loadChildren: () => import('./modules/settings/settings.module').then(m => m.SettingsModule)
	},
	{path: '**', redirectTo: 'home', pathMatch: 'full'}
];

@NgModule({
	imports: [
		RouterModule.forRoot(routes, {
			scrollPositionRestoration: 'enabled',
			preloadingStrategy: PreloadAllModules
		})
	],
	exports: [RouterModule]
})
export class AppRoutingModule {}
