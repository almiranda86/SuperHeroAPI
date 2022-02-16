/** source/controllers/hero.ts */
import { Request, Response, NextFunction } from 'express';
import { Mediator } from '../../SuperHeroMediator/Mediator';

import{ ConcreteMediator } from "../../SuperHeroMediator/ConcreteMediator";
import {GetCompleteHeroRequestHandler} from "../../SuperHeroService/Handlers/GetCompleteHeroRequestHandler";

let _mediator: Mediator;
let _concreteMediator: ConcreteMediator;
let _getCompleteHeroRequestHandler: GetCompleteHeroRequestHandler;

// getting all heroes
const getAllHeroes = async (req: Request, res: Response, next: NextFunction) => {
    // get some posts

    _getCompleteHeroRequestHandler= new GetCompleteHeroRequestHandler(_mediator);
    _concreteMediator=new ConcreteMediator(_getCompleteHeroRequestHandler);
    
    let responseHandler = await _concreteMediator.notify(req, "A");

    return res.status(200).json({
        message: responseHandler
    });
};

export default { getAllHeroes };