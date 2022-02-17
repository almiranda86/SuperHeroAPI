import { PagedServiceResponseBase } from "../Infrastructure/PagedServiceResponseBase";
import { Hero } from "../Model";


export class ListAllHeroesPaginatedResponse extends PagedServiceResponseBase{
    heroes: Array<Hero>;

    constructor(){
        super();
        this.heroes = new Array();
    }
}