import { extend } from "webdriver-js-extender";

export class UserLogin {
  UserName: string
  Password: string
}

export class RegisterUser {
  UserName: string
  Password: string
  Email: string
}
export class RegisterUserResponse extends RegisterUser {
  isSuccess: boolean
}

export class UserLoginResponse {
  userName: string
  password: string
  token:string
}
