import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {AlbumRoutingModule} from './album-routing.module';
import {AlbumComponent} from './album/album.component';
import {SharedModule} from '@shared/shared.module';
import {AlbumCardWideComponent} from './album-card-wide/album-card-wide.component';

@NgModule({
	declarations: [AlbumComponent, AlbumCardWideComponent],
	imports: [CommonModule, SharedModule, AlbumRoutingModule],
	exports: [AlbumCardWideComponent]
})
export class AlbumModule {}
