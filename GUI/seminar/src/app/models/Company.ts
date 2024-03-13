import { User } from "./User";

export class Company {
  statusId: number = 0;
  companyTypeId: number = 0;
  companyName: string = "";
  description: string = "";
  phone: string = "";
  webSite: string = "";
  email: string = "";
  billingAddress: string = "";
  shipingAddress: string = "";
  billingCityId: number = 0;
  shipingCityId: number = 0;
  billingZip: string = "";
  shipingZip: string = "";
  leadId: number = 0;
  registrationDate: Date | null = null;
  gid: string = "";
  gvat: string = "";
  fax: string = "";
  billingCityStateId: number = 0;
  billingCityStateCountryId: number = 0;
  shippingCityStateId: number = 0;
  shippingCityStateCountryId: number = 0;
  companyTypeName: string = "";
  companyAcronym: string = "";
  id: number = 0;
  createdDate: Date | null = null;
  createdUser: string = "";
  modifiedDate: Date | null = null;
  modifiedUser: string = "";
  imagePath: string = "";
  imageFile?: File;

  users: User[] = [];

  constructor() {
    this.id = 0;
  }
}
