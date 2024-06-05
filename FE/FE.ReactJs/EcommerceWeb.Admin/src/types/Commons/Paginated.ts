export type Paginated<T> = {
	items: T[];
	page: number;
	pageSize: number;
	totalCount: number;
	hasNextPage: boolean;
	hasPreviousPage: boolean;
};