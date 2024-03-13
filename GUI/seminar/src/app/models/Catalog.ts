import { CatalogItem } from "./CatalogItem";
import { Company } from "./Company";

export class Catalog {
    id: number;
    name: string;
    description: string = "";
    companyId: number;
    company!: Company;
    companyName: string = "";
    catalogItems!: CatalogItem;

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
        this.companyName = "";
        this.company = new Company();
        this.isEnabled = false;
        this.description = '';
    }
}
