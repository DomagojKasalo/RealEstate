import { Role } from "./role";

export class UserLight {
  identityId: string ="";
  roleName: string ="";
  roles!: Role;

  constructor (){
  }
}
