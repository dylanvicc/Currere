export interface User {
  userID: number;
  emailAddress: string;
  firstName: string;
  lastName: string;
  password: string;
  registrationDateUTC: Date;
  lastLoginDateUTC: Date;
  confirmedEmailAddress: boolean;
  locked: boolean;
  roleID: number;
}
