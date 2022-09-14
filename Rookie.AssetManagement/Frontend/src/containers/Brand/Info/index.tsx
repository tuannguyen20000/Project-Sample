import React from "react";
import { Modal, } from "react-bootstrap";

import IBrand from "src/interfaces/Brand/IBrand";
import formatDateTime from "src/utils/formatDateTime";
import { 
  NormalBrandType,
  NormalBrandTypeLabel,
  LuxuryBrandType, 
  LuxyryBrandTypeLabel 
} from "src/constants/Brand/BrandConstants";

type Props = {
  brand: IBrand;
  handleClose: () => void;
};

const Info: React.FC<Props> = ({ brand, handleClose }) => {
  const getBrandTypeName = (id: number) => {
    return id == LuxuryBrandType ? LuxyryBrandTypeLabel : NormalBrandTypeLabel;
  }

  return (
    <>
      <Modal
        show={true}
        onHide={handleClose}
        dialogClassName="modal-90w"
      >
        <Modal.Header closeButton>
          <Modal.Title id="login-modal">
            Detailed Brand Infomation
          </Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <div>
            <div className='row -intro-y'>
              <div className='col-4'>Id:</div>
              <div>{brand.id}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>Name:</div>
              <div>{brand.name}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>Type:</div>
              <div>{getBrandTypeName(brand.type)}</div>
            </div>

          </div>
        </Modal.Body>
      </Modal>
    </>
  );
}

export default Info;