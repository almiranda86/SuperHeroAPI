"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ListAllHeroesPaginatedResponse = void 0;
const PagedServiceResponseBase_1 = require("../Infrastructure/PagedServiceResponseBase");
class ListAllHeroesPaginatedResponse extends PagedServiceResponseBase_1.PagedServiceResponseBase {
    constructor() {
        super();
        this.heroes = new Array();
    }
}
exports.ListAllHeroesPaginatedResponse = ListAllHeroesPaginatedResponse;
