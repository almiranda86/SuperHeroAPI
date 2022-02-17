import { ServiceResponse } from "../../SuperHeroCore/ServiceResponse";
import { PagedServiceResponseBase } from "../Infrastructure/PagedServiceResponseBase";
import { Hero } from "../Model";


export class ListAllHeroesResponse extends ServiceResponse{
    heroes: Array<Hero>;

    constructor(){
        super();
        this.heroes = new Array();
    }
}