import { RealEstateCatalog } from "./realEstateCatalog";

export class RealEstateCatalogType {
    id: number  = 0;
    name: string = "";
    catalogs: RealEstateCatalog[] = [];

    createdDate!: Date;
    createdUser: string = "";
    modifiedDate!: Date;
    modifiedUser: string = "";

    constructor() {

    }
}
