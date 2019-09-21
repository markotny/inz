import {NgModule, Optional, SkipSelf} from '@angular/core';
import {AuthService} from './authentication/auth.service';
import {AuthGuard} from './authentication/auth.guard';
import { AuthCallbackComponent } from './authentication/auth-callback/auth-callback.component';

@NgModule({
  imports: [],
  providers: [AuthService, AuthGuard],
  declarations: [AuthCallbackComponent]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    // Import guard
    if (parentModule) {
      throw new Error(`${parentModule} has already been loaded. Import Core module in the AppModule only.`);
    }
  }
}
