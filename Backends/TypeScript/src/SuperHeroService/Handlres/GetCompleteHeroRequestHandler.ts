/**
 * Concrete Components implement various functionality. They don't depend on
 * other components. They also don't depend on any concrete mediator classes.
 */
 
import axios, { AxiosResponse } from 'axios';

import {BaseComponent} from "../../SuperHeroMediator/BaseComponent";
import { Mediator } from "../../SuperHeroMediator/Mediator";
import { HeroLookup } from '../../SuperHeroRepository/Lookup/HeroLookup';


export class GetCompleteHeroRequestHandler extends BaseComponent {
    
    private _heroLookup: HeroLookup = new HeroLookup();

    constructor(mediator: Mediator){
        super(mediator)
    }

    async handleRequest(sender: object) {

        const response = await this._heroLookup.getAllHeroes(sender);

        return response;
    }
 }

