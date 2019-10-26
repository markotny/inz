import {Settings} from '@gql/types.graphql-gen';

export const resolvers = {
	Mutation: {
		setTheme: (_, {input}, {cache}) => {
			const settings = {
				__typename: 'Settings',
				theme: input
			} as Settings;
			cache.writeData({data: {settings}});

			return settings;
		}
	}
};
