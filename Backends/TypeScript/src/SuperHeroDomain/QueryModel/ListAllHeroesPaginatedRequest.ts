import { PagedServiceResponseBase } from "../Infrastructure/PagedServiceResponseBase";
import { Hero } from "../Model/HeroModel";


export class ListAllHeroesPaginatedRequest {
    page: number;
    pageSize: number;

    constructor(){
        this.page = 1;
        this.pageSize = 10;
    }
}