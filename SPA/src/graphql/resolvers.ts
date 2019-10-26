import {Settings} from '@gql/types.graphql-gen';

export const resolvers = {
	Mutation: {
		updateSettings: (_, {input}, {cache}) => {
			const settings = {
				__typename: 'Settings',
				...input
			} as Settings;
			cache.writeData({data: {settings}});

			return null;
		}
	}
};
