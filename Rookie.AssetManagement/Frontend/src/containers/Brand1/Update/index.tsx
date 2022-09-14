import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router';

import { NOTFOUND } from 'src/constants/pages';
import { useAppSelector } from 'src/hooks/redux';
import IBrandForm from 'src/interfaces/Brand/IBrandForm';
import BrandForm from '../BrandForm';

const UpdateBrandContainer = () => {
  const { brands } = useAppSelector(state => state.brandReducer);
  
  const [brand, setBrand] = useState(undefined as IBrandForm | undefined);

  const { id } = useParams<{ id: string }>();
  
  const existBrand = brands?.items.find(item => item.id === Number(id));

  useEffect(() => {

    if (existBrand) {
      setBrand({
        id: existBrand.id,
        name: existBrand.name,
        type: existBrand.type
      });
    }
  }, [existBrand]);

  return (
    <div className='ml-5'>
      <div className='primaryColor text-title intro-x'>
        Update Brand {existBrand?.name}
      </div>

      <div className='row'>
        {
          brand && (<BrandForm
            initialBrandForm={brand}
  
          />)
        }
      </div>
    </div>
  )
};

export default UpdateBrandContainer;
