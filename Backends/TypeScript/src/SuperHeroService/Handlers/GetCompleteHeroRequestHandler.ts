/**
 * Concrete Components implement various functionality. They don't depend on
 * other components. They also don't depend on any concrete mediator classes.
 */
 
 import { ProccessOk } from "../../SuperHeroCore/Config/ProccessStatus";
import { GetCompleteHeroRequest } from "../../SuperHeroDomain/QueryModel/GetCompleteHeroRequest";
 import { GetCompleteHeroResult } from "../../SuperHeroDomain/QueryModel/GetCompleteHeroResult";
 import { Mediator } from "../../SuperHeroMediator/Mediator";
 import { CompleteHeroLookup } from "../../SuperHeroRepository/Lookup/CompleteHeroLookup";
  
  
  export class GetCompleteHeroRequestHandler implements Mediator<GetCompleteHeroRequest, GetCompleteHeroResult> {
      
      private _completeHeroLookup: CompleteHeroLookup;
  
      constructor(){
          this._completeHeroLookup = new CompleteHeroLookup()
      }
      
      async handle(getCompleteHeroRequest: GetCompleteHeroRequest): Promise<GetCompleteHeroResult> {
         
         let _getCompleteHeroResult: GetCompleteHeroResult = new GetCompleteHeroResult();

         const response = await this._completeHeroLookup.getCompleteHero(getCompleteHeroRequest.publicHeroId);
  
         if(response.length !=0 ){
             _getCompleteHeroResult.complete_hero = response.HERO;
            _getCompleteHeroResult.SetOk();
            _getCompleteHeroResult.status_description = ProccessOk;
         }
 
         return _getCompleteHeroResult;
      }
   }
  