import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {ExploreRoutingModule} from './explore-routing.module';
import {ExploreComponent} from './components/explore.component';
import {AlbumGridComponent} from './components/album-grid/album-grid.component';
import {AlbumListComponent} from './components/album-list/album-list.component';
import {AlbumDetailedComponent} from './components/album-detailed/album-detailed.component';

@NgModule({
	declarations: [AlbumGridComponent, AlbumListComponent, ExploreComponent, AlbumDetailedComponent],
	imports: [CommonModule, ExploreRoutingModule]
})
export class ExploreModule {}
