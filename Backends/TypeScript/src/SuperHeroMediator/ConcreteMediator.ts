/**
 * Concrete Mediators implement cooperative behavior by coordinating several
 * components.
 */

 import { Mediator } from "./Mediator";
 
 export class ConcreteMediator implements Mediator {
     
     public async handle(callback: Promise<any>): Promise<object | null> {
          let response = null;
            
          let handleResult = await callback.then((resultPromisse) => { return resultPromisse });
          
          response = handleResult;
              
          return response;
     }
 }