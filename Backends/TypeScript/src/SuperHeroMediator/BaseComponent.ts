/**
 * The Base Component provides the basic functionality of storing a mediator's
 * instance inside component objects.
 */

import {Mediator} from "./Mediator";

 export class BaseComponent {
    protected mediator: Mediator;

    constructor(mediator: Mediator) {
        this.mediator = mediator;
    }

    public setMediator(mediator: Mediator): void {
        this.mediator = mediator;
    }
}
