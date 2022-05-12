"use strict";
/**
 * The Base Component provides the basic functionality of storing a mediator's
 * instance inside component objects.
 */
Object.defineProperty(exports, "__esModule", { value: true });
exports.BaseComponent = void 0;
class BaseComponent {
    constructor(mediator) {
        this.mediator = mediator;
    }
    setMediator(mediator) {
        this.mediator = mediator;
    }
}
exports.BaseComponent = BaseComponent;
