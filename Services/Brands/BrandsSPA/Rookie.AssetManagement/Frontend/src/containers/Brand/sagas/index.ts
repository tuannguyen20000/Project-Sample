import { takeLatest } from 'redux-saga/effects';

import { createBrand, getBrands, updateBrand, disableBrand } from '../reducer';
import { handleCreateBrand, handleGetBrands, handleUpdateBrand, handleDisableBrand } from './handles';

export default function* BrandSagas() {
    yield takeLatest(createBrand.type, handleCreateBrand);
    yield takeLatest(getBrands.type, handleGetBrands);
    yield takeLatest(updateBrand.type, handleUpdateBrand);
    yield takeLatest(disableBrand.type, handleDisableBrand);
}
