import { Company } from "./company";

export class CompanyType {

  id: number;
  name: string;
  companies: Company[] = [];

  constructor (){
    this.id = 0;
    this.name = '';
  }
}
