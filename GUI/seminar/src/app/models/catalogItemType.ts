import { CatalogItem } from "./CatalogItem";

export class CatalogItemType {
    id: number = 0;
    name: string = "";
    catalogItems: CatalogItem[] = [];

    createdDate!: Date;
    createdUser: string = "";
    modifiedDate!: Date;
    modifiedUser: string = "";

    constructor() {

    }
}
