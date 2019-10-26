import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {Shell} from '@shell/shell.service';
import { SettingsComponent } from './settings.component';

const routes: Routes = [
  Shell.childRoutes([
		{path: '', redirectTo: '/settings', pathMatch: 'full'},
    {path: 'settings', component: SettingsComponent}
  ])
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class SettingsRoutingModule {}
