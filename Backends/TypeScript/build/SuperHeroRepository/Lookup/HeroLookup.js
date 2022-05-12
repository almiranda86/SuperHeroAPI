"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
var HeroLookup_1;
Object.defineProperty(exports, "__esModule", { value: true });
exports.HeroLookup = void 0;
const axios_1 = __importDefault(require("axios"));
const typeorm_1 = require("typeorm");
const Constants_1 = require("../../SuperHeroCore/Config/Constants");
const HeroModel_1 = require("../../SuperHeroDomain/Model/HeroModel");
let HeroLookup = HeroLookup_1 = class HeroLookup extends typeorm_1.Repository {
    finHeroById(sender) {
        return __awaiter(this, void 0, void 0, function* () {
            const URL = `${Constants_1.API_URI}${Constants_1.API_TOKEN}`;
            const response = Promise.resolve(yield axios_1.default.get(`${URL}/1`))
                .then((promiseResponse) => promiseResponse.data)
                .then((posts) => {
                return posts;
            });
            return response;
        });
    }
    listAllHeroes() {
        return __awaiter(this, void 0, void 0, function* () {
            this._respository = (0, typeorm_1.getCustomRepository)(HeroLookup_1);
            let result = yield this._respository.createQueryBuilder('hero').getMany();
            return result;
        });
    }
    listAllHeroesPaginated(currentPage, pageSize) {
        return __awaiter(this, void 0, void 0, function* () {
            const take = pageSize || 10;
            const page = currentPage || 1;
            const skip = (page - 1) * take;
            this._respository = (0, typeorm_1.getCustomRepository)(HeroLookup_1);
            let result = yield this._respository.findAndCount({ take: take, skip: skip });
            return result;
        });
    }
};
HeroLookup = HeroLookup_1 = __decorate([
    (0, typeorm_1.EntityRepository)(HeroModel_1.Hero)
], HeroLookup);
exports.HeroLookup = HeroLookup;
