import { Company } from "./Company";

export class User {
    id: string = "";
    email: string = "";
    userName: string = "";
    password: string = "";
    confirmPassword: string = "";
    firstName: string = "";
    lastName: string = "";
    phoneNumber: string = "";
    address: string = "";
    roles: Array<string> = [];
    companyId: number = 0;
    company!: Company;
  
    constructor() {
      this.id = "";
      this.password = "";
      this.confirmPassword = "";
      this.userName = "";
      this.firstName = "";
      this.lastName = "";
    }
  }
  