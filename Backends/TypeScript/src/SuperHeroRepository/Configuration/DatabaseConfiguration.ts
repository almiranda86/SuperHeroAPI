import { ConnectionOptions } from "typeorm";
import { CompleteHero } from "../../SuperHeroDomain/Model/CompleteHeroModel";
import { Hero } from "../../SuperHeroDomain/Model/HeroModel";

const DatabaseConfiguration: ConnectionOptions = { 
        type: "postgres",
        host: "localhost",
        port: 5432,
        username: "root",
        password: "pwd@123",
        database: "dbHero",
        entities: [Hero, CompleteHero],
        synchronize: false
}

export default DatabaseConfiguration;