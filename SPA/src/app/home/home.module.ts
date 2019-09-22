import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {HomeRoutingModule} from './home-routing.module';
import {IndexComponent} from './index/index.component';

@NgModule({
  declarations: [IndexComponent],
  imports: [CommonModule, RouterModule, HomeRoutingModule],
  exports: [IndexComponent]
})
export class HomeModule {}
