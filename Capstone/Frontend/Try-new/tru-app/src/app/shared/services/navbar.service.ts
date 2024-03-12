import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NavbarService {

  constructor(private http: HttpClient) { }
  getTaxCalc(inpAmount: number, taxType: string): Observable<number> {
    console.log("in service");
    // Adjust this URL to match your actual endpoint
    const apiUrl = `https://localhost:7047/api/Tax?amount=${inpAmount}&taxType=${taxType}`;

    return this.http.get<number>(apiUrl);
  }
  getccCalc(inpCCAmount: number, currType: string): Observable<number> {
    console.log("in service");
    // Adjust this URL to match your actual endpoint
    const apiUrl = `https://localhost:7047/api/CC?amount=${inpCCAmount}&currType=${currType}`;

    return this.http.get<number>(apiUrl);
  }

}
