import { Company } from "./company";
import { RealEstateCatalogItem } from "./realEstateCatalogItem";

export class RealEstateCatalog {
    id: number;
    name: string;
    description: string = "";
    companyId: number;
    company!: Company;
    catalogItems: RealEstateCatalogItem[] = [];

    catalogTypeId: number = 0;
    catalogTypeName: string = "";
    isEnabled: boolean;
    
    created!: Date;
    createdUser: number  = 0;
    modified!: Date;
    modifiedUser: number = 0;


    constructor() {
        this.id = 0;
        this.name = '';
        this.companyId = 0;
        this.company = new Company();
        this.isEnabled = false;
        this.description = '';
    }
}
