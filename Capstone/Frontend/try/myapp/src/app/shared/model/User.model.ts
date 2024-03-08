export interface User {
    UserID: number;
    Username: string;
    Password: string;
    Role: string
}
export class UserImpl implements User {
    constructor(
      public UserID: number,
      public Username: string,
      public Password: string,
      public Role: string
    ) {}
  }