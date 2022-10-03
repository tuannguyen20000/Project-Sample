import React, { useState } from "react";
import { PencilFill, XCircle } from "react-bootstrap-icons";
import { useNavigate } from "react-router";
import ButtonIcon from "src/components/ButtonIcon";
import { NotificationManager } from 'react-notifications';

import Table, { SortType } from "src/components/Table";
import IColumnOption from "src/interfaces/IColumnOption";
import IPagedModel from "src/interfaces/IPagedModel";
import IBrand from "src/interfaces/Brand/IBrand";
import formatDateTime from "src/utils/formatDateTime";
import Info from "../Info";
import { EDIT_BRAND_ID } from "src/constants/pages";
import ConfirmModal from "src/components/ConfirmModal";
import { useAppDispatch } from "src/hooks/redux";
import { 
  NormalBrandType,
  NormalBrandTypeLabel,
  LuxuryBrandType, 
  LuxyryBrandTypeLabel 
} from "src/constants/Brand/BrandConstants";
import { disableBrand } from "../reducer";

const columns: IColumnOption[] = [
  { columnName: "id", columnValue: "Id" },
  { columnName: "name", columnValue: "Name" },
  { columnName: "type", columnValue: "Type" }
];

type Props = {
  brands: IPagedModel<IBrand> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  fetchData: Function;
};

const BrandTable: React.FC<Props> = ({
  brands,
  handlePage,
  handleSort,
  sortState,
  fetchData,
}) => {
  const dispatch = useAppDispatch();

  const [showDetail, setShowDetail] = useState(false);
  const [brandDetail, setBrandDetail] = useState(null as IBrand | null);
  const [disableState, setDisable] = useState({
    isOpen: false,
    id: 0,
    title: '',
    message: '',
    isDisable: true,
  });

  const handleShowInfo = (id: number) => {
    const brand = brands?.items.find((item) => item.id === id);

    if (brand) {
      setBrandDetail(brand);
      setShowDetail(true);
    }
  };

  const getBrandTypeName = (id: number) => {
    return id == LuxuryBrandType ? LuxyryBrandTypeLabel : NormalBrandTypeLabel;
  }

  const handleShowDisable = async (id: number) => {
    setDisable({
      id,
      isOpen: true,
      title: 'Are you sure',
      message: 'Do you want to disable this Brand?',
      isDisable: true,
    });
  };

  const handleCloseDisable = () => {
    setDisable({
      isOpen: false,
      id: 0,
      title: '',
      message: '',
      isDisable: true,
    });
  };

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      handleCloseDisable();
      fetchData();
      NotificationManager.success(
        `Remove Brand Successful`,
        `Remove Successful`,
        2000,
    );
    } else {
      setDisable({
        ...disableState,
        title: 'Can not disable Brand',
        message,
        isDisable: result
      });
    }
  };
    
  const handleConfirmDisable = () => {
    dispatch(disableBrand({
      handleResult,
      brandId: disableState.id,
    }));
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  };

  const navigate = useNavigate();
  const handleEdit = (id: number) => {
    navigate(EDIT_BRAND_ID(id));
  };

  return (
    <>
      <Table
        columns={columns}
        handleSort={handleSort}
        sortState={sortState}
        page={{
          currentPage: brands?.currentPage,
          totalPage: brands?.totalPages,
          handleChange: handlePage,
        }}
      >
        {brands?.items.map((data, index) => (
          <tr key={index} className="" onClick={() => handleShowInfo(data.id)}>
            <td>{data.id}</td>
            <td>{data.name}</td>
            <td>{getBrandTypeName(data.type)}</td>

            <td className="d-flex">
              <ButtonIcon onClick={() => handleEdit(data.id)}>
                <PencilFill className="text-black" />
              </ButtonIcon>
              <ButtonIcon onClick={() => handleShowDisable(data.id)}>
                <XCircle className="text-danger mx-2" />
              </ButtonIcon>
            </td>
          </tr>
        ))}
      </Table>
      {brandDetail && showDetail && (
        <Info brand={brandDetail} handleClose={handleCloseDetail} />
      )}
      <ConfirmModal
        title={disableState.title}
        isShow={disableState.isOpen}
        onHide={handleCloseDisable}
      >
        <div>

          <div className="text-center">
            {disableState.message}
          </div>
          {
            disableState.isDisable && (
              <div className="text-center mt-3">
                <button
                  className="btn btn-danger mr-3"
                  onClick={handleConfirmDisable}
                  type="button"
                >
                  Disable
            </button>

                <button
                  className="btn btn-outline-secondary"
                  onClick={handleCloseDisable}
                  type="button"
                >
                  Cancel
            </button>
              </div>
            )
          }
        </div>
      </ConfirmModal>
    </>
  );
};

export default BrandTable;
