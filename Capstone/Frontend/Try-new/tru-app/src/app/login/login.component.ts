import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  userID: number=0;
  username: string="";
  password:string="";
  role: string="";
  constructor(private authService: AuthService, private router: Router) {}
  login() {
    console.log('inlogin');
    this.authService.login(this.userID,this.username, this.password, this.role).subscribe(() => {
        // Redirect to desired route after successful login
        this.router.navigate(['/invoice']);
        
        
    })
  }
    
    onSubmit(event: Event) {
        event.preventDefault(); // Prevent default form submission
        this.login(); // Call login method explicitly
      }

}
