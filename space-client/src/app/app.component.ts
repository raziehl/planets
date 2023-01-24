import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './core/auth.service';
import { BreakpointService } from './core/breakpoint.service';

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
    public router: Router
  ) {}

  ngOnInit() {
    this.path = window.location.pathname;
  }

  updateSingleSelectGroupValue(value: any): void {
    // this.singleSelectGroupValue = value;
    // console.log(value);
    // this.cd.markForCheck();
  }

}
