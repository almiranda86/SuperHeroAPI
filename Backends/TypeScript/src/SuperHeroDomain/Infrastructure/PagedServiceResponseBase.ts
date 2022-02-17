import { ServiceResponse } from "../../SuperHeroCore/ServiceResponse";
import { IPagedResponse } from "./Query/PagedResponse.interface";

export class PagedServiceResponseBase extends ServiceResponse implements IPagedResponse{
    current_page: number = 0;
    page_count: number = 0;
    page_size: number = 0;
    total_items: number = 0;
}
    