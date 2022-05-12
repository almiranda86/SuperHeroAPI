"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ServiceResponse = void 0;
const HttpStatusCode_1 = __importDefault(require("./Config/HttpStatusCode"));
class ServiceResponse {
    constructor() {
        this.issued_on = new Date();
        this.status = HttpStatusCode_1.default.I_AM_A_TEAPOT;
        this.status_description = "";
    }
    SetOk() { this.status = HttpStatusCode_1.default.OK; }
    ;
    SetInternalServerError() { this.status = HttpStatusCode_1.default.INTERNAL_SERVER_ERROR; }
    ;
}
exports.ServiceResponse = ServiceResponse;
