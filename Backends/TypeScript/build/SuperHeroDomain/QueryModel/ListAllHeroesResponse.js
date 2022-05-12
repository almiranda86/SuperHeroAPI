"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ListAllHeroesResponse = void 0;
const ServiceResponse_1 = require("../../SuperHeroCore/ServiceResponse");
class ListAllHeroesResponse extends ServiceResponse_1.ServiceResponse {
    constructor() {
        super();
        this.heroes = new Array();
    }
}
exports.ListAllHeroesResponse = ListAllHeroesResponse;
