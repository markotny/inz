import {AlbumComponent} from '@modules/album/album/album.component';

export enum LastFmApiMethod {
	AlbumSearch = 'album.search',
	ArtistSearch = 'artist.search',
	TopByArtist = 'artist.gettopalbums',
	AlbumInfo = 'album.getInfo'
}

export enum CoverImageSize {
	Small = 'small',
	Medium = 'medium',
	Large = 'large',
	ExtraLarge = 'extralarge',
	Mega = 'mega'
}

export interface LastFmApiQueryResults {
	results?: {
		albummatches?: {
			album: LastFmAlbum[];
		};
	};
	topalbums?: {
		album: LastFmAlbum[];
	};
	album?: LastFmAlbumDetailed;
}

export interface LastFmAlbum {
	artist: string | LastFmArtist;
	name: string;
	mbid: string;
	url: string;
	image: {
		'#text': string;
		size: CoverImageSize;
	}[];
}

export type LastFmAlbumDetailed = LastFmAlbum & {
	listeners: string;
	playcount: string;
	tracks: {
		track: LastFmTrack[];
	};
	tags: {
		tag: LastFmTag[];
	};
	wiki: LastFmWiki;
};

export interface LastFmTrack {
	name: string;
	url: string;
	duration: string;
	'@attr': {
		rank: string;
	};
	artist: LastFmArtist;
}

export interface LastFmArtist {
	name: string;
	mbid: string;
	url: string;
}

export interface LastFmTag {
	name: string;
	url: string;
}

export interface LastFmWiki {
	published: string;
	summary: string;
	content: string;
}

export interface LastFmApiArtist {
	artist: string;
	name: string;
	mbid: string;
	url: string;
	image: {
		'#text': string;
		size: CoverImageSize;
	}[];
}

export function getAlbumArtistName(artist: LastFmAlbum['artist']): string {
	if (typeof artist === 'string') {
		return artist;
	} else {
		return artist.name;
	}
}

export function getAlbumArtistMbid(artist: LastFmAlbum['artist']): string | null {
	if (typeof artist === 'string') {
		return null;
	} else {
		return artist.mbid;
	}
}

export function getCoverImage(images: LastFmAlbum['image'], size: CoverImageSize): string {
	return images.find(img => img.size === size)['#text'];
}
