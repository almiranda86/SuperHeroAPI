import { ServiceResponse } from "../../SuperHeroCore/ServiceResponse";
import { FullHero } from "../Model/FullHero";

export class GetCompleteHeroResult extends ServiceResponse{
    complete_hero: FullHero = new FullHero()
}