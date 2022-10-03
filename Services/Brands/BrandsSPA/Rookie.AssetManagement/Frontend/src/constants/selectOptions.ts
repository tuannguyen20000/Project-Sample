import ISelectOption from "src/interfaces/ISelectOption";

export const UserTypeOptions: ISelectOption[] = [
    { id: 1, label: 'All', value: 'All' },
    { id: 2, label: 'Admin', value: 'ADMIN' },
    { id: 3, label: 'Staff', value: 'STAFF' },
];

import { 
    NormalBrandType, 
    LuxuryBrandType,
    AllBrandType,
    NormalBrandTypeLabel,
    LuxyryBrandTypeLabel,
    AllBrandTypeLabel
} from "src/constants/Brand/BrandConstants";

export const BrandTypeOptions: ISelectOption[] = [
    { id: 1, label: NormalBrandTypeLabel, value: NormalBrandType },
    { id: 2, label: LuxyryBrandTypeLabel, value: LuxuryBrandType },
];

export const FilterBrandTypeOptions: ISelectOption[] = [
    { id: 1, label: AllBrandTypeLabel, value: AllBrandType },
    { id: 2, label: NormalBrandTypeLabel, value: NormalBrandType },
    { id: 3, label: LuxyryBrandTypeLabel, value: LuxuryBrandType },
];