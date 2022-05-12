"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.GetCompleteHeroResult = void 0;
const ServiceResponse_1 = require("../../SuperHeroCore/ServiceResponse");
const FullHero_1 = require("../Model/FullHero");
class GetCompleteHeroResult extends ServiceResponse_1.ServiceResponse {
    constructor() {
        super(...arguments);
        this.complete_hero = new FullHero_1.FullHero();
    }
}
exports.GetCompleteHeroResult = GetCompleteHeroResult;
