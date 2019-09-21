import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {AuthCallbackComponent} from '@core/authentication/auth-callback/auth-callback.component';

const routes: Routes = [
  {path: 'auth-callback', component: AuthCallbackComponent},
  // Fallback when no prior route is matched
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {enableTracing: true})],
  exports: [RouterModule]
})
export class AppRoutingModule {}
