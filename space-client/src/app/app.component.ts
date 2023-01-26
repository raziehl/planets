import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbMenuService } from '@nebular/theme';
import { filter, map } from 'rxjs';
import { AuthService } from './core/auth.service';
import { BreakpointService } from './core/breakpoint.service';
import { HttpService } from './core/http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client';
  path = '';



  constructor(
    public breakpoint: BreakpointService,
    public auth: AuthService,
    private http: HttpService,
    public router: Router,
    private nbMenuService: NbMenuService
  ) {}

  ngOnInit() {
    this.path = window.location.pathname;

    this.nbMenuService.onItemClick()
    .pipe(
      filter(({ tag }) => tag === 'my-context-menu'),
      map(({ item: { title } }) => title),
    ).subscribe(title => {
      switch(title) {
        case 'Profile':
          this.router.navigate(['/profile']);
          break;
        case 'Logout':
          this.auth.logout();
          this.router.navigate(['/login']);
          break;
      }
    });
    
    this.http.checkAuth().then().catch(() => this.auth.logout());
  }

  updateSingleSelectGroupValue(value: any): void {
    // this.singleSelectGroupValue = value;
    // console.log(value);
    // this.cd.markForCheck();
  }

}
