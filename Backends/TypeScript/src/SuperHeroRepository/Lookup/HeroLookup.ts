import axios from 'axios';
import { EntityRepository, getConnection, getCustomRepository, Repository } from 'typeorm';
import {API_URI, API_TOKEN, DATA_BASE_CONNECTION_NAME} from "../../SuperHeroCore/Config/Constants";
import { Hero } from '../../SuperHeroDomain/Model/HeroModel';

@EntityRepository(Hero)
export class HeroLookup extends Repository<Hero> {

    _databaseConnection: any;
    _respository: any;

    async finHeroById(sender: object) {

        const URL = `${API_URI}${API_TOKEN}`;

        const response = Promise.resolve(await axios.get(`${URL}/1`))
                        .then((promiseResponse) => promiseResponse.data)
                        .then((posts) => { 
                            return posts;
                         });

        return response;
    }


    async getAllHeroes(sender: object) {
        this._respository = getCustomRepository(HeroLookup);
        let result = this._respository.createQueryBuilder('hero').getMany();
        return result;
    }
}