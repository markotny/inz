import {Component, OnInit, ViewChild} from '@angular/core';
import {
	LastFmAlbum,
	getAlbumArtistName,
	getCoverImage,
	CoverImageSize,
	getAlbumArtistMbid
} from 'app/services/last-fm-api.interfaces';
import {MatHorizontalStepper} from '@angular/material';
import {
	SearchAlbumsGQL,
	AlbumBasicFragment,
	Rating,
	RatingInput,
	AddRatingGQL,
	SearchArtistsGQL,
	AddAlbumGQL,
	AlbumInput
} from '@gql/types.graphql-gen';
import {ReplaySubject, of, Subject} from 'rxjs';
import {map, switchMap, tap, share, shareReplay, catchError, take, mergeMap} from 'rxjs/operators';
import {AuthService} from '@core/authentication/auth.service';
import {Router} from '@angular/router';

@Component({
	selector: 'app-add-review',
	templateUrl: './add-review.component.html',
	styleUrls: ['./add-review.component.scss']
})
export class AddReviewComponent implements OnInit {
	@ViewChild('stepper', {static: false}) private stepper: MatHorizontalStepper;

	// private selectedAlbum: LastFmAlbum;
	private isNewAlbum: boolean;
	private albumSource = new ReplaySubject<LastFmAlbum>(1);
	priv;

	albumArtist$ = this.albumSource.pipe(
		switchMap(album =>
			this.searchArtists
				.fetch({
					mbid: getAlbumArtistMbid(album.artist),
					name: getAlbumArtistName(album.artist)
				})
				.pipe(
					map(res => {
						if (res.errors) {
							console.log('albumArtist$ error:', res.errors);
						}
						const searchResult = res.data.searchArtists;
						if (searchResult.length > 0) {
							if (searchResult.length > 1) {
								console.log(
									'Warning - artist search returned more than one result - returning first: ',
									searchResult
								);
							}
							return searchResult[0];
						} else {
							console.log('artist not found in db', album);
							return null;
						}
					})
				)
		),
		tap(res => console.log('artist observable', res)),
		shareReplay(1)
	);

	album$ = this.albumSource.pipe(
		switchMap(lastFmAlbum => {
			return this.searchAlbums
				.fetch({
					mbid: lastFmAlbum.mbid,
					title: lastFmAlbum.name,
					artist: getAlbumArtistName(lastFmAlbum.artist)
				})
				.pipe(
					tap(res => console.log('res', res)),
					map(res => {
						if (res.errors) {
							console.log('album$ error:', res.errors);
						}
						const searchResult = res.data.searchAlbums;
						if (searchResult.length > 0) {
							this.isNewAlbum = false;
							if (searchResult.length > 1) {
								console.log(
									'Warning - album search returned more than one result - returning first: ',
									searchResult
								);
							}
							const album = searchResult[0];
							if (!album.coverSrc) {
								album.coverSrc = getCoverImage(lastFmAlbum.image, CoverImageSize.Large);
							}
							return album;
						} else {
							console.log('Album not found in db', lastFmAlbum);
							this.isNewAlbum = true;
							return {
								mbid: lastFmAlbum.mbid,
								title: lastFmAlbum.name,
								coverSrc: getCoverImage(lastFmAlbum.image, CoverImageSize.Large),
								albumArtist: {
									mbid: getAlbumArtistMbid(lastFmAlbum.artist),
									name: getAlbumArtistName(lastFmAlbum.artist)
								}
							} as AlbumBasicFragment;
						}
					})
				);
		}),
		shareReplay(1),
		tap(res => console.log('album observable: ', res))
	);

	rating: RatingInput = {stars: null};

	constructor(
		private router: Router,
		private authService: AuthService,
		private searchAlbums: SearchAlbumsGQL,
		private searchArtists: SearchArtistsGQL,
		private addRating: AddRatingGQL,
		private addAlbum: AddAlbumGQL
	) {}

	ngOnInit() {
		this.rating.userId = this.authService.id;
	}

	onAlbumSelect(lastFmAlbum: LastFmAlbum) {
		this.albumSource.next(lastFmAlbum);
		this.stepper.next();
	}

	onRate({newValue}) {
		this.rating.stars = newValue;
	}

	isFormValid() {
		return this.rating.stars && this.rating.review;
	}

	onSubmit() {
		console.log('submitting', this.rating);
		this.album$
			.pipe(
				take(1),
				tap(album => (this.rating.albumId = album.id)),
				switchMap(album => {
					return this.isNewAlbum
						? this.albumArtist$.pipe(
								switchMap(artist => {
									const albumInput: AlbumInput = {
										ratings: [this.rating],
										...album
									};
									console.log('received artist:', artist);

									if (artist) {
										albumInput.albumArtist = null;
										albumInput.albumArtistId = artist.id;
									}
									console.log('adding album', albumInput);
									return this.addAlbum.mutate({
										album: albumInput
									});
								})
						  )
						: this.addRating.mutate({rating: this.rating});
				}),
				tap(res => console.log('mutation result: ', res))
			)
			.subscribe({
				error: err => console.log('sub err', err),
				complete: () => this.router.navigate(['/home'])
			});
	}
}
