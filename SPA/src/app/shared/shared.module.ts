import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {NgxSpinnerModule} from 'ngx-spinner';
import {AutoFocusDirective} from './directives/auto-focus.directive';

@NgModule({
  imports: [CommonModule, NgxSpinnerModule],
  declarations: [AutoFocusDirective],
  exports: [NgxSpinnerModule, AutoFocusDirective]
})
export class SharedModule {}
