/** source/controllers/hero.ts */
import { Request, Response, NextFunction } from 'express';
import { ListAllHeroesPaginatedRequestHanlder } from '../../SuperHeroService/Handlers/ListAllHeroesPaginatedRequestHanlder';
import { ListAllHeroesRequestHandler } from "../../SuperHeroService/Handlers/ListAllHeroesRequestHandler";

// get a full hero information
const getCompletHero = async (req: Request, res: Response, next: NextFunction) => {

    let _listAllHeroesRequestHandler = new ListAllHeroesRequestHandler();
    
    let response = await _listAllHeroesRequestHandler.handle(req);

    return res.status(response.status).json({
        data: response
    });
};


export default { getCompletHero };