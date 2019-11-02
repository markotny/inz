import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {AppRoutingModule} from './app-routing.module';
import {CoreModule} from '@core/core.module';
import {GraphQLModule} from './graphql.module';
import {SharedModule} from '@shared/shared.module';

import {AppComponent} from './app.component';
import {HeaderComponent} from '@shell/header/header.component';
import {SidenavComponent} from '@shell/sidenav/sidenav.component';

@NgModule({
	declarations: [AppComponent, HeaderComponent, SidenavComponent],
	imports: [
		BrowserModule,
		CommonModule,
		HttpClientModule,
		BrowserAnimationsModule,
		CoreModule,
		AppRoutingModule,
		SharedModule,
		GraphQLModule
	],
	bootstrap: [AppComponent]
})
export class AppModule {}
