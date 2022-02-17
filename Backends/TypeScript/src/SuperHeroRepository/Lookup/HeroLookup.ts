import axios from 'axios';
import { EntityRepository, getCustomRepository, Repository } from 'typeorm';
import { API_URI, API_TOKEN } from "../../SuperHeroCore/Config/Constants";
import { Hero } from '../../SuperHeroDomain/Model/HeroModel';

@EntityRepository(Hero)
export class HeroLookup extends Repository<Hero> {

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


    async listAllHeroes() {
        this._respository = getCustomRepository(HeroLookup);
        let result = await this._respository.createQueryBuilder('hero').getMany();

        return result;
    }

    async listAllHeroesPaginated(currentPage: number, pageSize: number) {
        const take = pageSize || 10
        const page = currentPage || 1;
        const skip = (page-1) * take ;

        this._respository = getCustomRepository(HeroLookup);
        let result = await this._respository.findAndCount({ take: take, skip: skip });

        return result;
    }
}