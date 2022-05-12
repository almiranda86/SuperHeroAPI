/**
 * Concrete Components implement various functionality. They don't depend on
 * other components. They also don't depend on any concrete mediator classes.
 */
 
import { ProccessOk } from "../../SuperHeroCore/Config/ProccessStatus";
import { ListAllHeroesRequest } from "../../SuperHeroDomain/QueryModel/ListAllHeroesRequest";
import { ListAllHeroesResponse } from "../../SuperHeroDomain/QueryModel/ListAllHeroesResponse";
import { Mediator } from "../../SuperHeroMediator/Mediator";
import { HeroLookup } from '../../SuperHeroRepository/Lookup/HeroLookup';
 
 
 export class ListAllHeroesRequestHandler implements Mediator<ListAllHeroesRequest, ListAllHeroesResponse> {
     
     private _heroLookup: HeroLookup;
 
     constructor(){
         this._heroLookup = new HeroLookup()
     }
     
     async handle(requestObject: ListAllHeroesRequest): Promise<ListAllHeroesResponse> {
        
        let _listAllHeroesResponse: ListAllHeroesResponse = new ListAllHeroesResponse();

        const response = await this._heroLookup.listAllHeroes();
 
        if(response.length !=0 ){
            _listAllHeroesResponse.heroes.push(response);
            _listAllHeroesResponse.SetOk();
            _listAllHeroesResponse.status_description = ProccessOk;
        }

        return _listAllHeroesResponse;
     }
  }
 