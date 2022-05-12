"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PagedServiceResponseBase = void 0;
const ServiceResponse_1 = require("../../SuperHeroCore/ServiceResponse");
class PagedServiceResponseBase extends ServiceResponse_1.ServiceResponse {
    constructor() {
        super(...arguments);
        this.current_page = 0;
        this.page_count = 0;
        this.page_size = 0;
        this.total_items = 0;
    }
}
exports.PagedServiceResponseBase = PagedServiceResponseBase;
