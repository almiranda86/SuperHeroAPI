import { ServiceResponse } from "../../SuperHeroCore/ServiceResponse";
import { FullHero } from "../Model/FullHero";

export class GetCompleteHeroRequest{
    publicHeroId: string;

    constructor() {
        this.publicHeroId = "";      
    }
}