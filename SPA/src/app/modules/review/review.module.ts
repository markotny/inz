import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {ReviewRoutingModule} from './review-routing.module';
import {SharedModule} from '@shared/shared.module';

import {AddReviewComponent} from './add-review/add-review.component';
import {AlbumSearchComponent} from './add-review/album-search/album-search.component';
import {AlbumModule} from '@modules/album/album.module';

@NgModule({
	declarations: [AddReviewComponent, AlbumSearchComponent],
	imports: [CommonModule, SharedModule, ReviewRoutingModule, AlbumModule]
})
export class ReviewModule {}
