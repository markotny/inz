import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {HttpClientModule} from '@angular/common/http';

import {AppRoutingModule} from './app-routing.module';
import {CoreModule} from '@core/core.module';
import {HomeModule} from './home/home.module';
import {ShellModule} from './shell/shell.module';
import {SharedModule} from '@shared/shared.module';
import {AppComponent} from './app.component';
import {GraphQLModule} from './graphql.module';

@NgModule({
	declarations: [AppComponent],
	imports: [
		BrowserModule,
		HttpClientModule,
		CoreModule,
		HomeModule,
		AppRoutingModule,
		ShellModule,
		SharedModule,
		GraphQLModule
	],
	bootstrap: [AppComponent]
})
export class AppModule {}
