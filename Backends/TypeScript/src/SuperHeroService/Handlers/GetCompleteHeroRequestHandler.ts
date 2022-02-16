/**
 * Concrete Components implement various functionality. They don't depend on
 * other components. They also don't depend on any concrete mediator classes.
 */
 
import { getConnection } from "typeorm";
import { DATA_BASE_CONNECTION_NAME } from "../../SuperHeroCore/Config/Constants";
import {BaseComponent} from "../../SuperHeroMediator/BaseComponent";
import { Mediator } from "../../SuperHeroMediator/Mediator";
import { HeroLookup } from '../../SuperHeroRepository/Lookup/HeroLookup';


export class GetCompleteHeroRequestHandler extends BaseComponent {
    
    private _heroLookup: HeroLookup;

    constructor(mediator: Mediator){
        super(mediator)
        // this._heroLookup = getConnection(DATA_BASE_CONNECTION_NAME).getCustomRepository(HeroLookup);
        this._heroLookup = new HeroLookup()
    }

    async handleRequest(sender: object) {

        const response = await this._heroLookup.getAllHeroes(sender);

        return response;
    }
 }

