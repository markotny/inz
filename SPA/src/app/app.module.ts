import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {HttpClientModule} from '@angular/common/http';

import {AppRoutingModule} from './app-routing.module';
import {CoreModule} from '@core/core.module';
import {HomeModule} from './home/home.module';
import {AccountModule} from '@account/account.module';
import {ShellModule} from './shell/shell.module';
import {SharedModule} from '@shared/shared.module';
import {AppComponent} from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    CoreModule,
    HomeModule,
    AccountModule,
    AppRoutingModule,
    ShellModule,
    SharedModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
