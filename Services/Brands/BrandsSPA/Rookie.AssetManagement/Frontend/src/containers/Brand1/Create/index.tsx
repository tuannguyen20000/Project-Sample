import React, { useState, useEffect } from "react";

import BrandFormContainer from "../BrandForm";

const CreateBrandContainer = () => {
  return (
    <div className='ml-5'>
      <div className='primaryColor text-title intro-x'>
        Create New Brand
      </div>

      <div className='row'>
        <BrandFormContainer />
      </div>

    </div>
  );
};

export default CreateBrandContainer;
