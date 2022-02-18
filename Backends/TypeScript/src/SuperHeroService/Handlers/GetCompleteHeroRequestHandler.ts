/**
 * Concrete Components implement various functionality. They don't depend on
 * other components. They also don't depend on any concrete mediator classes.
 */
 
 import { ProccessOk } from "../../SuperHeroCore/Config/ProccessStatus";
 import { GetCompleteHeroResult } from "../../SuperHeroDomain/QueryModel/GetCompleteHeroResult";
 import { Mediator } from "../../SuperHeroMediator/Mediator";
 import { CompleteHeroLookup } from "../../SuperHeroRepository/Lookup/CompleteHeroLookup";
  
  
  export class GetCompleteHeroRequestHandler implements Mediator<GetCompleteHeroResult> {
      
      private _completeHeroLookup: CompleteHeroLookup;
  
      constructor(){
          this._completeHeroLookup = new CompleteHeroLookup()
      }
      
      async handle(requestObject: any): Promise<GetCompleteHeroResult> {
         
         let _getCompleteHeroResult: GetCompleteHeroResult = new GetCompleteHeroResult();

         const response = await this._completeHeroLookup.getCompleteHero(requestObject.params.public_hero_id);
  
         if(response.length !=0 ){
             _getCompleteHeroResult.CompleteHero = response.HERO;
            _getCompleteHeroResult.SetOk();
            _getCompleteHeroResult.status_description = ProccessOk;
         }
 
         return _getCompleteHeroResult;
      }
   }
  