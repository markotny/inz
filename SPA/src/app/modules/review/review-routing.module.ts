import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {AddReviewComponent} from './add-review/add-review.component';

const routes: Routes = [{path: '', component: AddReviewComponent}];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class ReviewRoutingModule {}
