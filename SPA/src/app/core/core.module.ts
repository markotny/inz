import {NgModule, Optional, SkipSelf} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AuthCallbackComponent} from './authentication/auth-callback/auth-callback.component';
import {AuthGuard} from './authentication/auth.guard';
import {AuthService} from './authentication/auth.service';

@NgModule({
  imports: [CommonModule],
  providers: [AuthService, AuthGuard],
  declarations: [AuthCallbackComponent],
  exports: [AuthCallbackComponent]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    // Import guard
    if (parentModule) {
      throw new Error(
        `${parentModule} has already been loaded. Import Core module in the AppModule only.`
      );
    }
  }
}
