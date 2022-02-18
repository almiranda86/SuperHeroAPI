import { ServiceResponse } from "../../SuperHeroCore/ServiceResponse";
import { Hero } from "../Model/HeroModel";


export class ListAllHeroesResponse extends ServiceResponse{
    heroes: Array<Hero>;

    constructor(){
        super();
        this.heroes = new Array();
    }
}