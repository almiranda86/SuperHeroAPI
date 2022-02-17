import HttpStatusCode from "./Config/HttpStatusCode";

export class ServiceResponse{

    issued_on: Date = new Date();
    status: HttpStatusCode = HttpStatusCode.I_AM_A_TEAPOT;
    status_description: string = "";
    
    public SetOk(): void { this.status = HttpStatusCode.OK };
    public SetInternalServerError(): void {this.status = HttpStatusCode.INTERNAL_SERVER_ERROR};
}

