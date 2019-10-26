import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

import {NgxSpinnerModule} from 'ngx-spinner';

import {
	MatMenuModule,
	MatToolbarModule,
	MatSidenavModule,
  MatGridListModule,
	MatListModule,
  MatCardModule,
	MatDividerModule,
	MatExpansionModule,
	MatButtonModule,
  MatIconModule,
  MatSelectModule
} from '@angular/material';

import {AutoFocusDirective} from './directives/auto-focus.directive';

@NgModule({
	imports: [
		CommonModule,
		NgxSpinnerModule,
		FormsModule,
    MatMenuModule,
    MatToolbarModule,
    MatSidenavModule,
    MatGridListModule,
    MatListModule,
    MatCardModule,
    MatDividerModule,
    MatExpansionModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule
	],
	declarations: [AutoFocusDirective],
	exports: [
		CommonModule,
		NgxSpinnerModule,
		FormsModule,
    MatMenuModule,
    MatToolbarModule,
    MatSidenavModule,
    MatGridListModule,
    MatListModule,
    MatCardModule,
    MatDividerModule,
    MatExpansionModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
		AutoFocusDirective
	]
})
export class SharedModule {}
