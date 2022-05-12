/** source/controllers/hero.ts */
import { Request, Response, NextFunction } from 'express';
import { GetCompleteHeroRequest } from '../../SuperHeroDomain/QueryModel/GetCompleteHeroRequest';
import { GetCompleteHeroRequestHandler } from '../../SuperHeroService/Handlers/GetCompleteHeroRequestHandler';

// get a full hero information
const getCompletHero = async (req: Request, res: Response, next: NextFunction) => {

    let _getCompleteHeroRequest = new GetCompleteHeroRequest();
    _getCompleteHeroRequest.publicHeroId = req.params.public_hero_id;

    let _getCompleteHeroRequestHandler = new GetCompleteHeroRequestHandler();
    
    let response = await _getCompleteHeroRequestHandler.handle(_getCompleteHeroRequest);

    return res.status(response.status).json({
        data: response
    });
};


export default { getCompletHero };