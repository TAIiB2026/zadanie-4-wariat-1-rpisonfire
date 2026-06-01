import { Observable } from "rxjs";
import { ProduktClass } from "../classes/produkt.class";

export interface GetDataInterface {
    Get(): Observable<ProduktClass[]>;
    GetByID(id: number): Observable<ProduktClass>;
    Delete(id: number): Observable<boolean>;
}