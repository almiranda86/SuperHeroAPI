"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const CompleteHeroModel_1 = require("../../SuperHeroDomain/Model/CompleteHeroModel");
const HeroModel_1 = require("../../SuperHeroDomain/Model/HeroModel");
const DatabaseConfiguration = {
    type: "postgres",
    host: "localhost",
    port: 5432,
    username: "root",
    password: "pwd@123",
    database: "dbHero",
    entities: [HeroModel_1.Hero, CompleteHeroModel_1.CompleteHero],
    synchronize: false
};
exports.default = DatabaseConfiguration;
