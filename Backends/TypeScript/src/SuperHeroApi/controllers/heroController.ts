/** source/controllers/hero.ts */
import { Request, Response, NextFunction } from 'express';
import { ListAllHeroesPaginatedRequest } from '../../SuperHeroDomain/QueryModel/ListAllHeroesPaginatedRequest';
import { ListAllHeroesRequest } from '../../SuperHeroDomain/QueryModel/ListAllHeroesRequest';
import { ListAllHeroesPaginatedRequestHanlder } from '../../SuperHeroService/Handlers/ListAllHeroesPaginatedRequestHanlder';
import { ListAllHeroesRequestHandler } from "../../SuperHeroService/Handlers/ListAllHeroesRequestHandler";

// getting all heroes
const listAllHeroes = async (req: Request, res: Response, next: NextFunction) => {

    let _listAllHeroesRequest = new ListAllHeroesRequest();
    _listAllHeroesRequest.request = req;

    let _listAllHeroesRequestHandler = new ListAllHeroesRequestHandler();
    
    let response = await _listAllHeroesRequestHandler.handle(_listAllHeroesRequest);

    return res.status(response.status).json({
        data: response
    });
};

// getting all heroes with pagination
const getAllHeroesPaginated = async (req: Request, res: Response, next: NextFunction) => {
    
    let _listAllHeroesPaginatedRequest = new ListAllHeroesPaginatedRequest();
    _listAllHeroesPaginatedRequest.page = Number(req.query.page);
    _listAllHeroesPaginatedRequest.pageSize = Number(req.query.pageSize);

    let _listAllHeroesPaginatedRequestHanlder = new ListAllHeroesPaginatedRequestHanlder();
    
    let response = await _listAllHeroesPaginatedRequestHanlder.handle(_listAllHeroesPaginatedRequest);

    return res.status(response.status).json({
        data: response
    });
};



export default { listAllHeroes, getAllHeroesPaginated };