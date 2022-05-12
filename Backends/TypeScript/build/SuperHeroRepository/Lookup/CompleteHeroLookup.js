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
var CompleteHeroLookup_1;
Object.defineProperty(exports, "__esModule", { value: true });
exports.CompleteHeroLookup = void 0;
const typeorm_1 = require("typeorm");
const CompleteHeroModel_1 = require("../../SuperHeroDomain/Model/CompleteHeroModel");
let CompleteHeroLookup = CompleteHeroLookup_1 = class CompleteHeroLookup extends typeorm_1.Repository {
    getCompleteHero(public_hero_id) {
        return __awaiter(this, void 0, void 0, function* () {
            this._respository = (0, typeorm_1.getCustomRepository)(CompleteHeroLookup_1);
            let result = yield this._respository.createQueryBuilder('complete_hero')
                .where("complete_hero.PUBLIC_ID = :publicheroid", { publicheroid: public_hero_id }).getOne();
            return result;
        });
    }
};
CompleteHeroLookup = CompleteHeroLookup_1 = __decorate([
    (0, typeorm_1.EntityRepository)(CompleteHeroModel_1.CompleteHero)
], CompleteHeroLookup);
exports.CompleteHeroLookup = CompleteHeroLookup;
