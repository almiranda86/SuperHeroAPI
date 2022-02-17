/**
 * Concrete Components implement various functionality. They don't depend on
 * other components. They also don't depend on any concrete mediator classes.
 */
 
import { ProccessOk } from "../../SuperHeroCore/Config/ProccessStatus";
import { ListAllHeroesPaginatedResponse } from "../../SuperHeroDomain/QueryModel/ListAllHeroesPaginatedResponse";
import { Mediator } from "../../SuperHeroMediator/Mediator";
import { HeroLookup } from '../../SuperHeroRepository/Lookup/HeroLookup';
 
 
 export class ListAllHeroesPaginatedRequestHanlder implements Mediator<ListAllHeroesPaginatedResponse> {
     
     private _heroLookup: HeroLookup;
 
     constructor(){
         this._heroLookup = new HeroLookup()
     }
     
     async handle(requestObject: any): Promise<ListAllHeroesPaginatedResponse> {
        
        let _listAllHeroesPaginatedResponse: ListAllHeroesPaginatedResponse = new ListAllHeroesPaginatedResponse();

        const response = await this._heroLookup.listAllHeroesPaginated(requestObject.page, requestObject.pageSize);

        if(response.length !=0 ){
            _listAllHeroesPaginatedResponse.heroes.push(response[0]);
            _listAllHeroesPaginatedResponse.current_page = +requestObject.page;
            _listAllHeroesPaginatedResponse.page_count = Math.ceil((response[1] / requestObject.pageSize));
            _listAllHeroesPaginatedResponse.total_items = response[1];
            _listAllHeroesPaginatedResponse.page_size = +requestObject.pageSize;
            _listAllHeroesPaginatedResponse.SetOk();
            _listAllHeroesPaginatedResponse.status_description = ProccessOk;
        }

        return _listAllHeroesPaginatedResponse;
     }
  }
 