"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var UserLogin = /** @class */ (function () {
    function UserLogin() {
    }
    return UserLogin;
}());
exports.UserLogin = UserLogin;
var RegisterUser = /** @class */ (function () {
    function RegisterUser() {
    }
    return RegisterUser;
}());
exports.RegisterUser = RegisterUser;
var RegisterUserResponse = /** @class */ (function (_super) {
    __extends(RegisterUserResponse, _super);
    function RegisterUserResponse() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return RegisterUserResponse;
}(RegisterUser));
exports.RegisterUserResponse = RegisterUserResponse;
var UserLoginResponse = /** @class */ (function () {
    function UserLoginResponse() {
    }
    return UserLoginResponse;
}());
exports.UserLoginResponse = UserLoginResponse;
//# sourceMappingURL=UserComponentViewModel.js.map