import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {SharedModule} from '@shared/shared.module';
import {FlexLayoutModule} from '@angular/flex-layout';
import {ShellComponent} from './shell.component';
import {HeaderComponent} from './header/header.component';
import {SidenavComponent} from './sidenav/sidenav.component';
import {NavigationBaseComponent} from './navigation-base/navigation-base.component';

@NgModule({
	declarations: [ShellComponent, HeaderComponent, SidenavComponent, NavigationBaseComponent],
	imports: [CommonModule, RouterModule, SharedModule, FlexLayoutModule]
})
export class ShellModule {}
