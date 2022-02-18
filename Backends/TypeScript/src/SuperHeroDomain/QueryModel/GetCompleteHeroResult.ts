import { ServiceResponse } from "../../SuperHeroCore/ServiceResponse";
import { FullHero } from "../Model/FullHero";

export class GetCompleteHeroResult extends ServiceResponse{
    CompleteHero: FullHero = new FullHero()
}