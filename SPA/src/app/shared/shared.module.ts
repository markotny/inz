import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

import {NgxSpinnerModule} from 'ngx-spinner';
import {FlexLayoutModule} from '@angular/flex-layout';

import {
	MatMenuModule,
	MatToolbarModule,
	MatSidenavModule,
	MatStepperModule,
  MatGridListModule,
	MatListModule,
	MatTableModule,
  MatCardModule,
	MatDividerModule,
	MatExpansionModule,
	MatButtonModule,
  MatIconModule,
	MatSelectModule,
	MatSlideToggleModule,
	MatInputModule
} from '@angular/material';
import {RatingModule} from 'ng-starrating';

import {AutoFocusDirective} from './directives/auto-focus.directive';

@NgModule({
	imports: [
		CommonModule,
		NgxSpinnerModule,
		FlexLayoutModule,
		FormsModule,
		MatMenuModule,
    MatToolbarModule,
    MatSidenavModule,
		MatStepperModule,
    MatGridListModule,
    MatListModule,
		MatTableModule,
    MatCardModule,
    MatDividerModule,
    MatExpansionModule,
    MatButtonModule,
    MatIconModule,
		MatSelectModule,
		MatSlideToggleModule,
		MatInputModule,
		RatingModule
	],
	declarations: [AutoFocusDirective],
	exports: [
		AutoFocusDirective,
		CommonModule,
		NgxSpinnerModule,
		FlexLayoutModule,
		FormsModule,
    MatMenuModule,
    MatToolbarModule,
    MatSidenavModule,
		MatStepperModule,
    MatGridListModule,
    MatListModule,
		MatTableModule,
    MatCardModule,
    MatDividerModule,
    MatExpansionModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
		MatSlideToggleModule,
		MatInputModule,
		RatingModule
	]
})
export class SharedModule {}
