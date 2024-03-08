import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthgardService implements CanActivate {


  constructor(private router: Router, private authService: AuthService) {}
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {
        const token = localStorage.getItem('token');
        if (token) {
  // Logic to decode JWT token and check user roles
  /*Retrieve the JWT token from the request headers
        string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        // Decode the JWT token
        var handler = new JwtSecurityTokenHandler();
        var decodedToken = handler.ReadJwtToken(token);
        // Extract claims from the token
var claims = decodedToken.Claims;
        // Check if the user has the "Admin" role
        bool isAdmin = claims.Any(c => c.Type == "role" && c.Value == "Admin");
        // Example: Return user's roles
        var userRoles = claims.Where(c => c.Type == "role").Select(c => c.Value).ToList();
        return Ok(new { isAdmin, userRoles });  */
            return true;
        }
        // Not authenticated, redirect to login page
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}
