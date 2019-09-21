import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {AccountRoutingModule} from './account.routing-module';
import {SharedModule} from '@shared/shared.module';
import {RegisterComponent} from './register/register.component';
import {LoginComponent} from './login/login.component';
import {AuthService} from '@core/authentication/auth.service';

@NgModule({
  declarations: [RegisterComponent, LoginComponent],
  providers: [AuthService],
  imports: [CommonModule, FormsModule, AccountRoutingModule, SharedModule]
})
export class AccountModule {}
