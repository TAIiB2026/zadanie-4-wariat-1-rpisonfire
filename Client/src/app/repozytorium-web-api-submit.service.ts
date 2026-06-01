import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FormSubmitInterface } from './interfaces/form-submit.interface';

@Injectable()
export class RepozytoriumWebApiSubmitService implements FormSubmitInterface {
  private readonly apiUrl = 'http://localhost:5110/api/produkty';

  constructor(private http: HttpClient) {}

  Post(nazwa: string, cena: number, data: Date): Observable<boolean> {
    return this.http.post<boolean>(this.apiUrl, { nazwa, cena, dataWaznosci: data });
  }

  Put(id: number, nazwa: string, cena: number, data: Date): Observable<boolean> {
    return this.http.put<boolean>(`${this.apiUrl}/${id}`, { nazwa, cena, dataWaznosci: data });
  }
}
