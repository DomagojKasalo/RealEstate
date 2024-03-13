
import { Company } from "./company";

export class Status {

  id: number;
  name: string;
  companies: Company[] = [];

  constructor (){
    this.id = 0;
    this.name = '';
  }
}
