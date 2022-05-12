"use strict";
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
const ListAllHeroesPaginatedRequestHanlder_1 = require("../../SuperHeroService/Handlers/ListAllHeroesPaginatedRequestHanlder");
const ListAllHeroesRequestHandler_1 = require("../../SuperHeroService/Handlers/ListAllHeroesRequestHandler");
// getting all heroes
const listAllHeroes = (req, res, next) => __awaiter(void 0, void 0, void 0, function* () {
    let _listAllHeroesRequestHandler = new ListAllHeroesRequestHandler_1.ListAllHeroesRequestHandler();
    let response = yield _listAllHeroesRequestHandler.handle(req);
    return res.status(response.status).json({
        data: response
    });
});
// getting all heroes with pagination
const getAllHeroesPaginated = (req, res, next) => __awaiter(void 0, void 0, void 0, function* () {
    let _listAllHeroesPaginatedRequestHanlder = new ListAllHeroesPaginatedRequestHanlder_1.ListAllHeroesPaginatedRequestHanlder();
    let response = yield _listAllHeroesPaginatedRequestHanlder.handle({ page: req.query.page, pageSize: req.query.pageSize });
    return res.status(response.status).json({
        data: response
    });
});
exports.default = { listAllHeroes, getAllHeroesPaginated };
