import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs';
import { User, UserImpl } from './model/User.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }
  private baseUrl = "https://localhost:7047/api/auth/login";
  login(userID: number, username: string, password: string, role:string): Observable<any> {
    let user= new UserImpl(userID, username,password,role);
    return this.http.post<any>(this.baseUrl, user)
                .pipe(map(response => {
                    if (response && response.token) {
                        localStorage.setItem('token', JSON.stringify(response.token));
                    }
                    return response;
                }));
        }
        logout() {
            localStorage.removeItem('token');
        }
}
