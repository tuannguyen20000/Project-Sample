const Endpoints = {
    authorize: 'api/authorize',
    me: 'api/authorize/me',

    brand: 'api/brands',
    brandId: (id: number | string): string => `api/brands/${id}`,
};

export default Endpoints;