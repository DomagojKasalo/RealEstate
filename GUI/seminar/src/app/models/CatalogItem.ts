import { Catalog } from "./Catalog";
import { CatalogItemImages } from "./catalogItemImages";

export class CatalogItem {
    id: number;
    name: string;
    catalogId: number = 0;
    catalogName: string ="";
    catalog: Catalog;
    description: string = "";
    companyId: number = 0;
    companyName: string = "";
    isEnabled!: boolean;
    catalogItemTypeId: number = 0;
    catalogItemStatusId: number = 0;
    lamella: string;
    floor: number;
    units: number;


    created!: Date;
    createdUser: number = 0;
    modified!: Date;
    modifiedUser: number = 0;

    versionIdentifier: string = "";
    floors: number; 
    rooms: number;
    bathrooms: number;
    garagePlaces: number;
    dimensions: string = "";
    netArea: number; 
    bruttoArea: number; 
    isFeatured!: boolean;

    catalogItemImages: CatalogItemImages[] = []; 

    disclaimer: string;
    isDisclamer: boolean;
    approvedUser: string;
    deploymentStatusId: number = 0;

    constructor() {
        this.id = 0;
        this.name = '';

        this.catalog = new Catalog();
        this.companyName = '';
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
