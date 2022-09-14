import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";
import { Status } from "src/constants/status";

import IError from "src/interfaces/IError";
import IQueryBrandModel from "src/interfaces/Brand/IQueryBrandModel";
import { setBrand, disableBrand, CreateAction, setBrands, setStatus, DisableAction } from "../reducer";

import { createBrandRequest, DisableBrandRequest, getBrandsRequest, UpdateBrandRequest } from './requests';
import IBrand from "src/interfaces/Brand/IBrand";

export function* handleCreateBrand(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        console.log('handleCreateBrand');
        console.log(formValues);
        
        const { data } = yield call(createBrandRequest, formValues);

        if (data)
        {
            handleResult(true, data.name);
        }

        yield put(setBrand(data));
        
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleGetBrands(action: PayloadAction<IQueryBrandModel>) {
    const query = action.payload;
    try {
        console.log('handleGetBrands');
        console.log(query);
        // alert("da goi handleGetBrands");
        const { data } = yield call(getBrandsRequest, query);
        
        console.log(data);
        yield put(setBrands(data));
        // alert("da goi setBrands 2");

    } catch (error: any) {
        const errorModel = error.response.data as IError;
        
        console.log(errorModel);
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleUpdateBrand(action : PayloadAction<CreateAction>){
    const { handleResult, formValues } = action.payload; 

    try {
        const { data } = yield call(UpdateBrandRequest, formValues);

        handleResult(true, data.name.toString());
        
        yield put(setBrand(data));

    }catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleDisableBrand(action: PayloadAction<DisableAction>) {
    const { handleResult, brandId } = action.payload;

    try {
        const {data} = yield call(DisableBrandRequest, brandId);

        handleResult(data, '');

    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}
