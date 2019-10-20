import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

import {RouterModule} from '@angular/router';
import {HomeRoutingModule} from './home-routing.module';
import {IndexComponent} from './index/index.component';

@NgModule({
	declarations: [IndexComponent],
	imports: [CommonModule, RouterModule, FormsModule, HomeRoutingModule],
	exports: [IndexComponent]
})
export class HomeModule {}
