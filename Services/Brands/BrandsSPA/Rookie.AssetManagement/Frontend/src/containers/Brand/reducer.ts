import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "src/constants/status";

import IError from "src/interfaces/IError";
import IPagedModel from "src/interfaces/IPagedModel";
import IQueryBrandModel from "src/interfaces/Brand/IQueryBrandModel";
import IBrand from "src/interfaces/Brand/IBrand";
import IBrandForm from "src/interfaces/Brand/IBrandForm";

type BrandState = {
    loading: boolean;
    brandResult?: IBrand;
    brands: IPagedModel<IBrand> | null;
    status?: number;
    error?: IError;
    disable: boolean;
}

export type CreateAction = {
    handleResult: Function,
    formValues: IBrandForm,
}

export type DisableAction = {
    handleResult: Function,
    brandId: number,
}

const initialState: BrandState = {
    brands: null,
    loading: false,
    disable: false,
};

const brandReducerSlice = createSlice({
    name: 'home',
    initialState,
    reducers: {
        getBrands: (state, action: PayloadAction<IQueryBrandModel>): BrandState => {
// alert("da goi  getbrands");
            return {
                ...state,
                loading: true,
            }
        },
        setBrands: (state, action: PayloadAction<IPagedModel<IBrand>>): BrandState => {
            const brands = action.payload;
            // alert("da goi setbrands1");
            return {
                ...state,
                brands,
                loading: false,
            }
        },
        createBrand: (state, action: PayloadAction<CreateAction>): BrandState => {
            return {
                ...state,
                loading: true,
            }
        },
        updateBrand: (state, action: PayloadAction<CreateAction>): BrandState => {
            return {
                ...state,
                loading: true,
            }
        },
        disableBrand: (state, action: PayloadAction<DisableAction>): BrandState => {
            return {
                ...state,
                loading: true,
            }
        },
        setBrand: (state, action: PayloadAction<IBrand>): BrandState => {
            const brandResult = action.payload;

            return {
                ...state,
                brandResult,
                loading: false,
            }
        },
        setStatus: (state, action: PayloadAction<SetStatusType>): BrandState => {
            const { status, error } = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            }
        },
        cleanUp: (state): BrandState => ({
            ...state,
            loading: false,
            brandResult: undefined,
            status: undefined,
            error: undefined,
        }),
    }
});

export const {
    createBrand, setBrand, setStatus, cleanUp, getBrands, setBrands, updateBrand, disableBrand
} = brandReducerSlice.actions;

export default brandReducerSlice.reducer;
