/** source/controllers/hero.ts */
import { Request, Response, NextFunction } from 'express';
import { ListAllHeroesPaginatedRequestHanlder } from '../../SuperHeroService/Handlers/ListAllHeroesPaginatedRequestHanlder';
import { ListAllHeroesRequestHandler } from "../../SuperHeroService/Handlers/ListAllHeroesRequestHandler";

// getting all heroes
const listAllHeroes = async (req: Request, res: Response, next: NextFunction) => {

    let _listAllHeroesRequestHandler = new ListAllHeroesRequestHandler();
    
    let response = await _listAllHeroesRequestHandler.handle(req);

    return res.status(response.status).json({
        data: response
    });
};

// getting all heroes with pagination
const getAllHeroesPaginated = async (req: Request, res: Response, next: NextFunction) => {
    
    let _listAllHeroesPaginatedRequestHanlder = new ListAllHeroesPaginatedRequestHanlder();
    
    let response = await _listAllHeroesPaginatedRequestHanlder.handle({page: req.query.page, pageSize: req.query.pageSize});

    return res.status(response.status).json({
        data: response
    });
};



export default { listAllHeroes, getAllHeroesPaginated };