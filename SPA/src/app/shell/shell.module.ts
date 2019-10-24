import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {FlexLayoutModule} from '@angular/flex-layout';
import {
	MatMenuModule,
	MatToolbarModule,
	MatSidenavModule,
	MatListModule,
	MatDividerModule,
	MatExpansionModule,
	MatButtonModule,
	MatIconModule
} from '@angular/material';
import {ShellComponent} from './shell.component';
import {HeaderComponent} from './header/header.component';
import {SidenavComponent} from './sidenav/sidenav.component';
import {NavigationBaseComponent} from './navigation-base/navigation-base.component';

@NgModule({
	declarations: [ShellComponent, HeaderComponent, SidenavComponent, NavigationBaseComponent],
	imports: [
		CommonModule,
		RouterModule,
		FlexLayoutModule,
		MatMenuModule,
		MatToolbarModule,
		MatSidenavModule,
		MatListModule,
		MatDividerModule,
		MatExpansionModule,
		MatButtonModule,
		MatIconModule
	]
})
export class ShellModule {}
