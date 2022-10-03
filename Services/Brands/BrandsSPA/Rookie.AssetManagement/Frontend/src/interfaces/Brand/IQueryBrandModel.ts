export default interface IQueryBrandModel {
    search: string;
    sortOrder: string;
    sortColumn: string;
    limit: number;
    page: number;
    types: number[];
}