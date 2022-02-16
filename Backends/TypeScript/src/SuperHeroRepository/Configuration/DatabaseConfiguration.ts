import { ConnectionOptions } from "typeorm";
import { Hero } from "../../SuperHeroDomain/Model";

const DatabaseConfiguration: ConnectionOptions = { 
        type: "postgres",
        host: "localhost",
        port: 5432,
        username: "root",
        password: "pwd@123",
        database: "dbHero",
        entities: [Hero],
        synchronize: false
}

export default DatabaseConfiguration;