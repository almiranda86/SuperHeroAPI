/** source/controllers/hero.ts */
import { Request, Response, NextFunction } from 'express';
import { GetCompleteHeroRequestHandler } from '../../SuperHeroService/Handlers/GetCompleteHeroRequestHandler';

// get a full hero information
const getCompletHero = async (req: Request, res: Response, next: NextFunction) => {

    let _getCompleteHeroRequestHandler = new GetCompleteHeroRequestHandler();
    
    let response = await _getCompleteHeroRequestHandler.handle(req);

    return res.status(response.status).json({
        data: response
    });
};


export default { getCompletHero };