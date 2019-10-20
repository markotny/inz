import {NgModule} from '@angular/core';
import {ApolloModule, APOLLO_OPTIONS} from 'apollo-angular';
import {HttpLinkModule, HttpLink} from 'apollo-angular-link-http';
import {setContext} from 'apollo-link-context';
import {InMemoryCache} from 'apollo-cache-inmemory';
import {AuthService} from '@core/authentication/auth.service';
import {ApolloLink} from 'apollo-link';

const uri = 'api/graphql';
export function createApollo(httpLink: HttpLink, authService: AuthService) {
	// const auth = setContext((_operation, _context) => ({
	// 	headers: {
	// 		Authorization: authService.authorizationHeaderValue
	// 	}
	// }));

	return {
		// link: ApolloLink.from([auth, httpLink.create({uri})]),
		link: httpLink.create({uri}),
		cache: new InMemoryCache()
	};
}

@NgModule({
	exports: [ApolloModule, HttpLinkModule],
	providers: [
		{
			provide: APOLLO_OPTIONS,
			useFactory: createApollo,
			deps: [HttpLink, AuthService]
		}
	]
})
export class GraphQLModule {}
