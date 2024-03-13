import { Catalog } from "./Catalog";

export class CatalogType {
    id: number  = 0;
    name: string = "";
    catalogs: Catalog[] = [];

    createdDate!: Date;
    createdUser: string = "";
    modifiedDate!: Date;
    modifiedUser: string = "";

    constructor() {

    }
}
