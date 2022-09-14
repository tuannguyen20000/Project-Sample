import React, { useEffect, useState } from 'react';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { Link, useNavigate } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';

import TextField from 'src/components/FormInputs/TextField';
import DateField from 'src/components/FormInputs/DateField';
import CheckboxField from 'src/components/FormInputs/CheckboxField';
import SelectField from 'src/components/FormInputs/SelectField';
import { BRAND_PARENT_ROOT } from 'src/constants/pages';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import { createBrand, updateBrand } from './reducer';
import IBrandForm from 'src/interfaces/Brand/IBrandForm';
import { Status } from 'src/constants/status';
import { NormalBrandType } from "src/constants/Brand/BrandConstants";
import { BrandTypeOptions } from "src/constants/selectOptions";

const initialFormValues: IBrandForm = {
    name: '',
    type: NormalBrandType
};

const validationSchema = Yup.object().shape({
    name: Yup.string().required('Required'),
    type: Yup.string().required('Required')
});

type Props = {
    initialBrandForm?: IBrandForm;
};

const BrandFormContainer: React.FC<Props> = ({ initialBrandForm = {
    ...initialFormValues
} }) => {
    const [loading, setLoading] = useState(false);

    const dispatch = useAppDispatch();

    const isUpdate = initialBrandForm.id ? true : false;

    const navigate = useNavigate();

    const handleResult = (result: boolean, message: string) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Brand ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                2000,
            );

            setTimeout(() => {
                navigate(BRAND_PARENT_ROOT);
            }, 1000);

        } else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    }

    return (
        <Formik
            initialValues={initialBrandForm}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit={(values) => {
                setLoading(true);

                setTimeout(() => {
                    if (isUpdate) {
                        dispatch(updateBrand({ handleResult, formValues: values }));
                    }
                    else {
                        dispatch(createBrand({ handleResult, formValues: values }));
                    }

                    setLoading(false);
                }, 1000);
            }}
        >
            {(actions) => (
                <Form className='intro-y col-lg-6 col-12'>
                    <TextField 
                        name="name"
                        label="Name" 
                        placeholder="input brand name" 
                        isrequired 
                        disabled={isUpdate ? true : false} />
                    <SelectField 
                        name="type" 
                        label="Type" 
                        options={BrandTypeOptions} 
                        isrequired />
                    
                    <div className="d-flex">
                        <div className="ml-auto">
                            <button className="btn btn-danger"
                                type="submit" disabled={loading}
                            >
                                Save {(loading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                            </button>

                            <Link to={BRAND_PARENT_ROOT} className="btn btn-outline-secondary ml-2">
                                Cancel
                            </Link>
                        </div>
                    </div>
                </Form>
            )}
        </Formik>
    );
}

export default BrandFormContainer;
