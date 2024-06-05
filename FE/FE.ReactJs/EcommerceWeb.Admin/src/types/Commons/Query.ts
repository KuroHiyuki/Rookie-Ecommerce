export type Query = {
	searchTerm?: string;
	sortOrder?: string;
	sortColumn?: string;
	page: number;
	pageSize: number;
};

export const defaultQuery: Query = {
	page: 1,
	pageSize: 8,
};