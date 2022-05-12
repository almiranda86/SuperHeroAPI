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
exports.ListAllHeroesPaginatedRequestHanlder = void 0;
const ProccessStatus_1 = require("../../SuperHeroCore/Config/ProccessStatus");
const ListAllHeroesPaginatedResponse_1 = require("../../SuperHeroDomain/QueryModel/ListAllHeroesPaginatedResponse");
const HeroLookup_1 = require("../../SuperHeroRepository/Lookup/HeroLookup");
class ListAllHeroesPaginatedRequestHanlder {
    constructor() {
        this._heroLookup = new HeroLookup_1.HeroLookup();
    }
    handle(requestObject) {
        return __awaiter(this, void 0, void 0, function* () {
            let _listAllHeroesPaginatedResponse = new ListAllHeroesPaginatedResponse_1.ListAllHeroesPaginatedResponse();
            const response = yield this._heroLookup.listAllHeroesPaginated(requestObject.page, requestObject.pageSize);
            if (response.length != 0) {
                _listAllHeroesPaginatedResponse.heroes.push(response[0]);
                _listAllHeroesPaginatedResponse.current_page = +requestObject.page;
                _listAllHeroesPaginatedResponse.page_count = Math.ceil((response[1] / requestObject.pageSize));
                _listAllHeroesPaginatedResponse.total_items = response[1];
                _listAllHeroesPaginatedResponse.page_size = +requestObject.pageSize;
                _listAllHeroesPaginatedResponse.SetOk();
                _listAllHeroesPaginatedResponse.status_description = ProccessStatus_1.ProccessOk;
            }
            return _listAllHeroesPaginatedResponse;
        });
    }
}
exports.ListAllHeroesPaginatedRequestHanlder = ListAllHeroesPaginatedRequestHanlder;
