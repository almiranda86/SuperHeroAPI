import { EntityRepository, getCustomRepository, Repository } from 'typeorm';
import { CompleteHero } from '../../SuperHeroDomain/Model/CompleteHeroModel';


@EntityRepository(CompleteHero)
export class CompleteHeroLookup extends Repository<CompleteHero> {

    _respository: any;

    async getCompleteHero(public_hero_id: string) {
        this._respository = getCustomRepository(CompleteHeroLookup);
        let result = await this._respository.createQueryBuilder('complete_hero')
                                            .where("complete_hero.PUBLIC_ID = :publicheroid", { publicheroid: public_hero_id }).getOne();
        
        return result;
    }
}