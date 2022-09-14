export const LOGIN = 'login';

export const HOME = '/';

export const BRAND = 'brand/*';
export const BRAND_LIST = '*';
export const CREATE_BRAND = 'create';
export const EDIT_BRAND = 'edit/:id';
export const EDIT_BRAND_ID = (id: string | number) => `edit/${id}`;
export const BRAND_LIST_LINK = '/brand';
export const BRAND_PARENT_ROOT = '..';

export const NOTFOUND = '/notfound';