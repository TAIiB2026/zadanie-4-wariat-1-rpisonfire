import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { GetDataInterface } from './interfaces/get-data.interface';
import { ProduktClass } from './classes/produkt.class';

@Injectable()
export class RepozytoriumWebApiService implements GetDataInterface {
  private readonly apiUrl = 'http://localhost:5110/api/produkty';

  constructor(private http: HttpClient) {}

  Get(): Observable<ProduktClass[]> {
    return this.http.get<any[]>(this.apiUrl).pipe(
      map(items => items.map(i => new ProduktClass(i.id, i.nazwa, i.cena, new Date(i.dataWaznosci))))
    );
  }

  GetByID(id: number): Observable<ProduktClass> {
    return this.http.get<any>(`${this.apiUrl}/${id}`).pipe(
      map(i => new ProduktClass(i.id, i.nazwa, i.cena, new Date(i.dataWaznosci)))
    );
  }

  Delete(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`);
  }
}
