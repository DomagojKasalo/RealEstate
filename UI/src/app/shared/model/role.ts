export class Role {
  name: string;
  roleValue: boolean;

  constructor(roleName: string) {
    this.name = roleName;
    this.roleValue = false;
  }
}