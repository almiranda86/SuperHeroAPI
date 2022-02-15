/**
 * Concrete Mediators implement cooperative behavior by coordinating several
 * components.
 */

import { Mediator } from "./Mediator";
import { GetCompleteHeroRequestHandler } from "../SuperHeroService/Handlres/GetCompleteHeroRequestHandler";

export class ConcreteMediator implements Mediator {
    public _listAllHeroesRequestHandler: GetCompleteHeroRequestHandler;

    constructor(listAllHeroesRequestHandler: GetCompleteHeroRequestHandler) {
        this._listAllHeroesRequestHandler = listAllHeroesRequestHandler;
        this._listAllHeroesRequestHandler.setMediator(this);
    }

    public async notify(sender: object, event: string): Promise<object | null> {
       let response = null;
        
        if (event === 'A') {
            let handleResult = await this._listAllHeroesRequestHandler.handleRequest(sender);
            
            response = handleResult;
        }
        
        return response;
    }
}