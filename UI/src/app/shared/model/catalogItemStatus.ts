import { RealEstateCatalogItem } from "./realEstateCatalogItem";

export class RealEstateCatalogItemStatus {
    id: number = 0;
    name: string = "";
    catalogItems: RealEstateCatalogItem[] = [];

    createdDate!: Date;
    createdUser: string = "";
    modifiedDate!: Date;
    modifiedUser: string = "";

    constructor() {

    }
}
