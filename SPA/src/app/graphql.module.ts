import {NgModule} from '@angular/core';
import {ApolloModule, APOLLO_OPTIONS} from 'apollo-angular';
import {HttpLinkModule, HttpLink} from 'apollo-angular-link-http';
import {setContext} from 'apollo-link-context';
import {InMemoryCache} from 'apollo-cache-inmemory';
import {AuthService} from '@core/authentication/auth.service';
import {ApolloLink} from 'apollo-link';
import {resolvers} from '@gql/resolvers';
import {Settings} from '@gql/types.graphql-gen';
import {SettingsService} from './modules/settings/settings.service';

const uri = 'api/graphql';

@NgModule({
	exports: [ApolloModule, HttpLinkModule],
	providers: [
		{
			provide: APOLLO_OPTIONS,
			useFactory: (
				httpLink: HttpLink,
				authService: AuthService
			) => {
				const auth = authService.isAuthenticated
					? setContext((_operation, _context) => ({
							headers: {
								Authorization: authService.authorizationHeaderValue
							}
					  }))
					: null;

				const cache = new InMemoryCache();

				const defaultSettings = {
					__typename: 'Settings',
					theme: 'dark-theme',
					stickyHeader: true
				} as Settings;
				cache.writeData({data: {settings: defaultSettings}});

				return {
					link: ApolloLink.from([auth, httpLink.create({uri})]),
					cache,
					resolvers,
					typeDefs: {}
				};
			},
			deps: [HttpLink, AuthService]
		}
	]
})
export class GraphQLModule {}
