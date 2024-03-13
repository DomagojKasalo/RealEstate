import { CatalogItemImages } from "./catalogItemImages";
import { RealEstateCatalog } from "./realEstateCatalog";

export class RealEstateCatalogItem {
    id: number;
    name: string;
    catalogId: number = 0;
    catalogName: string ="";
    catalog: RealEstateCatalog;
    description: string = "";
    companyId: number = 0;
    companyName: string = "";
    isEnabled!: boolean;
    catalogItemTypeId: number = 0;
    catalogItemTypeName: string = "";
    catalogItemStatusId: number = 0;
    lamella: string;
    floor: number;
    units: number;
    quote: string = "";


    createdDate!: Date;
    createdUser: number = 0;
    modifiedDate!: Date;
    modifiedUser: number = 0;

    versionIdentifier: string = "";

    floors: number; //float
    rooms: number;
    bathrooms: number;
    garagePlaces: number;
    dimensions: string = "";
    netArea: number; //float
    bruttoArea: number; //float
    isFeatured!: boolean;

    disclaimer: string;
    isDisclamer: boolean;
    approvedUser: string;
    deploymentStatusId: number = 0;

    
    catalogItemImages: CatalogItemImages[] = []; 


    constructor() {
        this.id = 0;
        this.name = '';
        this.catalogId = 0;
        this.catalog = new RealEstateCatalog();
        this.description = '';
        this.floors = 0;
        this.bathrooms = 0;
        this.rooms = 0;
        this.garagePlaces = 0;
        this.netArea = 0;
        this.bruttoArea = 0;
        this.floor = 0;
        this.lamella = '';
        this.units = 0;
        this.disclaimer = '';
        this.isDisclamer = false;
        this.approvedUser = '';
    }
}
