import React, { lazy } from 'react';
import { Route, Routes } from 'react-router-dom';

import { CREATE_BRAND, BRAND_LIST, EDIT_BRAND } from 'src/constants/pages';
import LayoutRoute from 'src/routes/LayoutRoute';

const NotFound = lazy(() => import("../NotFound"));
const CreateBrand = lazy(() => import("./Create"));
const ListBrand = lazy(() => import("./List"));
const UpdateBrand = lazy(() => import("./Update"))

const Brand = () => {
    return (
        <Routes>
            <Route path={BRAND_LIST} element={<ListBrand />} />
            <Route path={CREATE_BRAND} element={<CreateBrand />} />
            <Route path={EDIT_BRAND} element={<UpdateBrand />} />
        </Routes>
    )
};

export default Brand;