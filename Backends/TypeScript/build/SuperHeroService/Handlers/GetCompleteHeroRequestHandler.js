"use strict";
/**
 * Concrete Components implement various functionality. They don't depend on
 * other components. They also don't depend on any concrete mediator classes.
 */
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.GetCompleteHeroRequestHandler = void 0;
const ProccessStatus_1 = require("../../SuperHeroCore/Config/ProccessStatus");
const GetCompleteHeroResult_1 = require("../../SuperHeroDomain/QueryModel/GetCompleteHeroResult");
const CompleteHeroLookup_1 = require("../../SuperHeroRepository/Lookup/CompleteHeroLookup");
class GetCompleteHeroRequestHandler {
    constructor() {
        this._completeHeroLookup = new CompleteHeroLookup_1.CompleteHeroLookup();
    }
    handle(requestObject) {
        return __awaiter(this, void 0, void 0, function* () {
            let _getCompleteHeroResult = new GetCompleteHeroResult_1.GetCompleteHeroResult();
            const response = yield this._completeHeroLookup.getCompleteHero(requestObject.params.public_hero_id);
            if (response.length != 0) {
                _getCompleteHeroResult.complete_hero = response.HERO;
                _getCompleteHeroResult.SetOk();
                _getCompleteHeroResult.status_description = ProccessStatus_1.ProccessOk;
            }
            return _getCompleteHeroResult;
        });
    }
}
exports.GetCompleteHeroRequestHandler = GetCompleteHeroRequestHandler;
