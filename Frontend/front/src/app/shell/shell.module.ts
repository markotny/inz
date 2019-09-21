import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {ShellComponent} from './shell.component';
import {HeaderComponent} from './header/header.component';

@NgModule({
  declarations: [ShellComponent, HeaderComponent],
  imports: [CommonModule, RouterModule]
})
export class ShellModule {}
